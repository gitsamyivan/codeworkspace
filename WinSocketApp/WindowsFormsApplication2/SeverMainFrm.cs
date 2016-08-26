using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CommonClass;
using System.IO;
using CommonClass.Entity;
using System.Web.Script.Serialization;

namespace WinsocketServer
{
    public partial class SeverMainFrm : Form
    {
        private JavaScriptSerializer jss = new JavaScriptSerializer();
        public Socket serversocket;
        public Dictionary<string, UserSokect> userdic = new Dictionary<string, UserSokect>();
        //public List<UserSokect> UserList = new List<UserSokect>();
        public SeverMainFrm()
        {
            InitializeComponent();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            try
            {
                serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipaddr = IPAddress.Parse(this.txt_ip.Text);

                IPEndPoint ipport = new IPEndPoint(ipaddr, Convert.ToInt32(this.txt_port.Text));
                //绑定接口
                serversocket.Bind(ipport);
                //同一时间最大连接数
                serversocket.Listen(10);

                this.btnstart.Enabled = false;
                this.lstbox_state.Items.Add("监听成功 \r\n");

                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(serversocket);
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    this.btnstart.Enabled = true;
                    this.lstbox_state.Items.Add("监听失败: " + ex.Message + " \r\n");
                }));
             
            }


        }

    

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(serversocket != null && serversocket.Connected)
            {
                serversocket.Shutdown(SocketShutdown.Both);
                serversocket.Close();
            }
        }
        /// <summary>
        /// 监听客服端连接
        /// </summary>
        /// <param name="obj"></param>
        private void Listen(object obj)
        {
            try
            {
                Socket con = obj as Socket;
             
                while (true)
                {

                    Socket client = con.Accept();
                    string ipaddress = client.RemoteEndPoint.ToString();
                    string Uid = MethodHlper.CreateId();
                    //userdic.Add(ipaddress, client);
                    userdic.Add(Uid, new UserSokect() { 
                        UserSocket = client,
                        UserInfo = new Users() { Userid = Uid, IpAddress = ipaddress } ,
                        IpEndpoint = client.RemoteEndPoint
                    });

                    this.Invoke(new Action(() =>
                    {
                        //this.combox_clients.Items.Add(ipaddress);
                        //if (this.combox_clients.SelectedIndex < 0)
                        //    this.combox_clients.SelectedIndex = 0;
                        this.lstbox_state.Items.Add(ipaddress + " : 上线  \r\n");
                        
                    }));

                    Thread th = new Thread(ReciveMsg);
                    th.IsBackground = true;
                    //th.Start(client);
                    th.Start(userdic[Uid]);

                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {

                    this.lstbox_state.Items.Add("客服端连接错误: " + ex.Message + " \r\n");
                }));
            }
        }

        /// <summary>
        /// 接收客服端信息
        /// </summary>
        /// <param name="socket"></param>
        private void ReciveMsg(object dic)
        {
            try
            {
                UserSokect user = dic as UserSokect;
                Socket accept = user.UserSocket;
                byte[] buffer = new byte[1024 * 1024*10];

                while (true)
                {
                   int length = accept.Receive(buffer);//字符丢失长度不正确第二次
                   string ipaddress = accept.RemoteEndPoint.ToString();

                    if (length == 0)
                    {
                        //SetStatemsg(ipaddress + "下线断开连接");
                        if (string.IsNullOrEmpty(user.UserInfo.Nickname))
                            SetStatemsg(ipaddress + "下线断开连接");
                        else
                            SetStatemsg(user.UserInfo.Nickname + "下线断开连接");
                        accept.Close();
                        //userdic.Remove(ipaddress);
                        userdic.Remove(user.UserInfo.Userid);
                        this.Invoke(new Action(() =>
                        {
                            this.combox_clients.Items.Remove(ipaddress);
                            if (this.combox_clients.Text == ipaddress)
                                    this.combox_clients.Text = "";
                        }));
                        break;
                    }

                    string msg = Encoding.UTF8.GetString(buffer, 0, length);
                    //SetStatemsg(ipaddress + ": " + msg);
                    MsgHeader message = jss.Deserialize<MsgHeader>(msg);
                    if (message != null)
                    {
                        if (message.type == (int)CommonClass.MessageHeader.MessageHead.Login)
                        {
                            Users u = jss.Deserialize<Users>(message.Msg);
                            if(u!=null)
                            {
                                user.UserInfo.Nickname = u.Nickname;
                                user.UserInfo.Gender = u.Gender;
                                user.UserInfo.Age = u.Age;
                            }
                            string umsg = jss.Serialize(user.UserInfo);
                            user.UserSocket.Send(MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Login, umsg, null, "0", "0"));

                            if (!string.IsNullOrEmpty(user.UserInfo.Nickname) && !string.IsNullOrEmpty(user.UserInfo.Userid))
                                AddUserToListBox(user.UserInfo.Nickname, user.UserInfo.Userid);
                        }
                        else 
                        {
                            //Users u = UserDatas.users.Single(c => c.Userid == message.sId);
                            //SetStatemsg(u.UserName + ": " + message.Msg);
                            if(userdic.ContainsKey(message.toId))
                            {
                                //直接转发
                                byte[] newbuf = buffer.Take(length).ToArray();
                                userdic[message.toId].UserSocket.Send(newbuf);
                            }
                            else if (message.toId == "0" && message.fromId =="0")
                            {
                                if (!string.IsNullOrEmpty(user.UserInfo.Nickname))
                                    SetStatemsg(user.UserInfo.Nickname + ": " + message.Msg);
                                else
                                    SetStatemsg(ipaddress+": "+message.Msg);
                            }
                            else
                            {
                                var fail = MessageHeader.WriteMsgWithHeader(MessageHeader.MessageHead.Message,"发送失败",null,"0","0");
                                userdic[message.fromId].UserSocket.Send(fail);
                            } 
                      
                        }

                    }
                 
                  

                    #region 协议

                    /*
                       int header = buffer[0];
                       switch (header)
                       {
                           case (int)CommonClass.MessageHeader.MessageHead.Message:
                               {
                                   string msg = Encoding.UTF8.GetString(buffer, 1, length - 1);
                                   //SetStatemsg(user.Nickname + ": " + msg);
                                   break;
                               }
                           case (int)CommonClass.MessageHeader.MessageHead.File:
                               {
                                   string msg = Encoding.UTF8.GetString(buffer, 1, buffer.Length - 1);
                                   //SetStatemsg(ipaddress + "发送文件 ");
                                   SetStatemsg(user.Nickname + "发送文件 ");
                                   break;
                               }
                           case (int)CommonClass.MessageHeader.MessageHead.Shaken:
                               {
                                   Shaken();
                                   break;
                               }
                           case (int)CommonClass.MessageHeader.MessageHead.ChatFriend:
                               {
                                   string msg = Encoding.UTF8.GetString(buffer, 1, buffer.Length - 1);
                                   string ip = msg.Split('|')[0];
                                   byte[] fmsg =MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.ChatFriend, msg.Split('|')[1]);
                                   ClientChat(ipaddress, ip, fmsg);
                                   break;
                               }
                     
                       }
                     * */
                    
                    #endregion

                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {

                    this.lstbox_state.Items.Add("接收消息错误: " + ex.Message + " \r\n");
                }));
               
            }




        }

        private void btnsendmsg_Click(object sender, EventArgs e)
        {

            if(this.combox_clients.SelectedIndex >= 0)
            {
                string user = this.combox_clients.Text;
                user = user.Split('_')[1];
                string msg = this.rchbox_sendmsg.Text;
                //byte[] buffer = Encoding.UTF8.GetBytes(msg);
                byte[] buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Message, msg,null,"0","0");

                //userdic[user].Send(buffer);
                userdic[user].UserSocket.Send(buffer);
            }
            else
            {

                MessageBox.Show("请选择要发送的用户");
            }


        }

        private void SetStatemsg(string msg)
        {
            this.Invoke(new Action(() =>
            {

                this.lstbox_state.Items.Add(msg + "  \r\n");
                this.lstbox_state.TopIndex = lstbox_state.Items.Count - 1;
            }));
        }

        private void btnselectfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtfile.Text = open.FileName;
            }
        }

        private void btnsendfile_Click(object sender, EventArgs e)
        {

            if (this.combox_clients.SelectedIndex >= 0)
            {
                string user = this.combox_clients.Text;
                user = user.Split('_')[1];
                string filepath = this.txtfile.Text;
                if (File.Exists(filepath))
                {
                    using (FileStream fs = new FileStream(this.txtfile.Text, FileMode.Open))
                    {
                        string filename = this.txtfile.Text;
                        filename = filename.Substring(filename.LastIndexOf(@"\") + 1);
                        if (filename.Length > 30)
                        {
                            MessageBox.Show("文件名过长");
                            return;
                        }

                        byte[] file = new byte[fs.Length];
                        fs.Read(file, 0, file.Length);
                        if (file.Length > 1024 * 1024 * 10)
                        {
                            MessageBox.Show("文件不能超过10M");
                            return;
                        }

                        //byte[] buffer = Encoding.UTF8.GetBytes(msg);
                        byte[] buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.File, filename, file,"0","0");

                        //userdic[user].Send(buffer);
                        if(userdic.ContainsKey(user))
                            userdic[user].UserSocket.Send(buffer);

                    }
                }
                else
                {
                    MessageBox.Show("文件不存在!路径不对..");
                    return;
                }
            }
            else
            {

                MessageBox.Show("请选择要发送的用户");
            }

        }

        int n = 1;
        void Shaken()
        {
       this.Invoke(new Action(() =>
       {
           this.TopMost = true;
           for (int i = 0; i < 20; i++)
           {
               this.Location = new Point(this.Location.X - 10 * n, this.Location.Y - 10 * n);
               n = n * -1;
               System.Threading.Thread.Sleep(40);
           }
       }));
        }

        private void btn_shaken_Click(object sender, EventArgs e)
        {

            if (this.combox_clients.SelectedIndex >= 0)
            {
                string user = this.combox_clients.Text;
                user = user.Split('_')[1];

               byte[] buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Shaken, "");

                //userdic[user].Send(buffer);
               if (userdic.ContainsKey(user))
                    userdic[user].UserSocket.Send(buffer);
               else
                   MessageBox.Show("发送失败");

               
            }
            else
            {

                MessageBox.Show("请选择要发送的用户");
            }

        }



        private void rchbox_sendmsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnsendmsg_Click(sender, e);
        }

        private void AddUserToListBox(string UserName,string UserId)
        {
            this.Invoke(new Action(() =>
            {

                //this.combox_clients.Items.Add(new { text = UserName, value = UserId });
                this.combox_clients.Items.Add(UserName + "_" + UserId);
                if (this.combox_clients.SelectedIndex < 0)
                    this.combox_clients.SelectedIndex = 0;

            }));
          

        }
      


    }
}
