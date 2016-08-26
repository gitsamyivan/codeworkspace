using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using CommonClass;
using System.IO;
using CommonClass.Entity;
using System.Web.Script.Serialization;

namespace WinsocketClient
{
    public partial class ClientMainFrm : Form
    {
        private JavaScriptSerializer jss = new JavaScriptSerializer();
        private Socket clientsocket;
        private Users UserInfo = new Users();
        public ClientMainFrm()
        {
            InitializeComponent();
        }

        private void SOcketConnect()
        {
            clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ip = IPAddress.Parse(this.txt_ip.Text);

            IPEndPoint ipend = new IPEndPoint(ip, Convert.ToInt32(this.txt_port.Text));

            clientsocket.Connect(ipend);
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientsocket == null)
                {
                    SOcketConnect();
                    this.btn_start.Enabled = false;
                    SetSateMsg(clientsocket.LocalEndPoint.ToString() + "连接成功");
                    Thread th = new Thread(ReciveMsg);
                    th.IsBackground = true;
                    th.Start();
                }
            }
            catch (Exception ex)
            {
                Reset();
                SetSateMsg("连接失败 " + ex.Message);
            }


        }


        private void ReciveMsg()
        {

            try
            {
                byte[] buffer = new byte[1024 * 1024 * 10];

                while (true)
                {
                    int length = clientsocket.Receive(buffer);
                    if (length == 0)
                    {
                        SetSateMsg("服务器关闭");
                        clientsocket.Close();
                        Reset();
                        break;
                    }

                    string msg = Encoding.UTF8.GetString(buffer, 0, length);
                    MsgHeader message = jss.Deserialize<MsgHeader>(msg);

                    if (message != null)
                    {
                        if (message.type == (int)CommonClass.MessageHeader.MessageHead.Login)
                        {
                            Users u = jss.Deserialize<Users>(message.Msg);
                            UserInfo.Userid = u.Userid;
                        }
                        else if (message.type == (int)CommonClass.MessageHeader.MessageHead.Message)
                        {
                            if(message.fromId =="0")
                                SetSateMsg("收到服务器消息: " + message.Msg);
                            else
                                SetSateMsg(message.fromId+": " + message.Msg);
                        }
                        else if (message.type == (int)CommonClass.MessageHeader.MessageHead.File)
                        {
                            this.Invoke(new Action(() =>
                            {
                                byte[] filebuffer = Encoding.UTF8.GetBytes(message.Msg);
                                string filename = Encoding.UTF8.GetString(filebuffer, 0, 30);
                                SetSateMsg("收到文件 " + filename);
                                SaveFileDialog save = new SaveFileDialog();
                                save.FileName = filename;
                                if (save.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                                {

                                    using (FileStream fs = new FileStream(save.FileName, FileMode.Create))
                                    {
                                        fs.Write(buffer, 30, length - 30);
                                    }
                                }

                            }));

                        }else if(message.type == (int)CommonClass.MessageHeader.MessageHead.Shaken)
                        {

                            Shaken();
                        }


                    }

                    #region protol

                    /*
                    int header = buffer[0];
                    switch (header)
                    {
                        case (int)CommonClass.MessageHeader.MessageHead.Message:
                            {
                                string msg = Encoding.UTF8.GetString(buffer, 1, length - 1);
                                //SetStatemsg(ipaddress + ": " + msg);
                               


                                //string msg = Encoding.UTF8.GetString(buffer, 1, length - 1);
                                //SetSateMsg("收到服务器消息: " + msg);
                                break;
                            }
                        case (int)CommonClass.MessageHeader.MessageHead.File:
                            {
                                //string msg = Encoding.UTF8.GetString(buffer, 1, buffer.Length - 1);
                            
                                this.Invoke(new Action(() =>
                                {
                                    string filename = Encoding.UTF8.GetString(buffer, 1, 30);
                                    SetSateMsg("收到文件 " + filename);
                                    SaveFileDialog save = new SaveFileDialog();
                                    save.FileName = filename;
                                    if (save.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                                    {

                                        using (FileStream fs = new FileStream(save.FileName, FileMode.Create))
                                        {
                                            fs.Write(buffer, 31, length - 31);
                                        }
                                    }

                                }));
                               
                                break;
                            }
                        case (int)CommonClass.MessageHeader.MessageHead.Shaken:
                            {
                                Shaken();
                                break;
                            }
                        case (int)CommonClass.MessageHeader.MessageHead.ChatFriend:
                            {
                                string msg = Encoding.UTF8.GetString(buffer, 1, length - 1);
                                SetSateMsg("收到朋友消息: " + msg);
                                break;
                            }
                    }

                    */
                    
                    #endregion
                  
                }
            }
            catch (Exception ex)
            {
                
                this.Invoke(new Action(() =>
                    {
                        this.lstbox_sate.Items.Add("接收消息发生错误:  " + ex.Message + "\n\r");
                    }));
                //Reset();
            }


        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(clientsocket != null && clientsocket.Connected)
            {
                clientsocket.Shutdown(SocketShutdown.Both);
                clientsocket.Close();
            }
        }
        
        private void btn_sendmsg_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(UserInfo.Userid))
                {
                    this.lstbox_sate.Items.Add("还没有登录");
                    return;
                }
                if (clientsocket != null && clientsocket.Connected)
                {
                    string msg = this.rchbox_sendmsg.Text;
                    byte[] buffer ;
                    //byte[] buffer = Encoding.UTF8.GetBytes(msg);
                    if (this.txt_firend.Text == "")
                    {
                        buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Message, msg, null, "0", "0");
                    }
                    else
                    {
                        buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Message, msg, null, UserInfo.Userid, this.txt_firend.Text);
                    }
                   if( clientsocket.Send(buffer) <=0)
                   {
                       clientsocket.Disconnect(true);
                       SOcketConnect();
                   }
                }
            }
            catch (Exception ex)
            {
                
                  this.Invoke(new Action(() =>
                    {
                        this.lstbox_sate.Items.Add("发送消息错误:  " + ex.Message + "\n\r");
                    }));
                  Reset();
            }

        }


        private void SetSateMsg(string msg)
        {
            this.Invoke(new Action(() =>
            {
                this.lstbox_sate.Items.Add(msg +"\n\r");
                this.lstbox_sate.TopIndex = lstbox_sate.Items.Count - 1;
            }));

        }

        private void Reset()
        {
            this.Invoke(new Action(() =>
            {
                clientsocket = null;
                this.btn_start.Enabled = true;

            }));
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

        private void rchbox_sendmsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_sendmsg_Click(sender, e);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                Users u = new Users()
                   {
                       Nickname = this.txt_NickName.Text
                   };
                string umsg = jss.Serialize(u);
                byte[] buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Login, umsg, null, "0", "0");
                clientsocket.Send(buffer);
                SetSateMsg("登录成功");
                this.btn_login.Enabled = false;
            }
            catch (Exception ex)
            {
                  SetSateMsg("登录失败"+ex.Message);
                  this.btn_login.Enabled = true;
                
            }
        }

        private void btn_shaken_Click(object sender, EventArgs e)
        {
            string toId = this.txt_firend.Text =="" ?"0":this.txt_firend.Text ;
            string fromId = "0";
            if(toId !="0") fromId =UserInfo.Userid;

            var buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Shaken, "", null, fromId, toId);
            clientsocket.Send(buffer);
        }

    }
}
