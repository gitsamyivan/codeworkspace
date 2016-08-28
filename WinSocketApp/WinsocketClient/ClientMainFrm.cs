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

        private void SocketConnect()
        {
            try
            {
                clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ip = IPAddress.Parse(this.txt_ip.Text);

                IPEndPoint ipend = new IPEndPoint(ip, Convert.ToInt32(this.txt_port.Text));

                clientsocket.Connect(ipend);
            }
            catch (Exception)
            {

            }
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientsocket == null)
                {
                    SocketConnect();
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
                                SetSateMsg(message.fromName+": " + message.Msg);
                        }
                        else if (message.type == (int)CommonClass.MessageHeader.MessageHead.File)
                        {
                            this.Invoke(new Action(() =>
                            {
                                byte[] filebuffer = message.File;
                                string filename = message.Msg;
                                SetSateMsg("收到" + message.fromName + "文件 " + filename);
                                SaveFileDialog save = new SaveFileDialog();
                                save.FileName = filename;
                                if (save.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                                {

                                    using (FileStream fs = new FileStream(save.FileName, FileMode.Create))
                                    {
                                        fs.Write(filebuffer,0,filebuffer.Length);
                                    }
                                }

                            }));

                        }else if(message.type == (int)CommonClass.MessageHeader.MessageHead.Shaken)
                        {
                          
                            if (message.fromId == "0")
                                SetSateMsg("服务器给你发送了一个震动");
                            else
                                SetSateMsg(message.fromName + "给你发送了一个震动 ");
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
                this.Invoke(new Action(() => {
                    this.btn_login.Enabled = true;
                }));
                Thread th = new Thread(Reconnect);
                th.IsBackground = true;
                th.Start();

                SetSateMsg("接收消息发生错误:  " + ex.Message + "\n\r");
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
                        buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Message, UserInfo.Nickname, msg, null, "0", "0");
                    }
                    else
                    {
                        buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Message, UserInfo.Nickname, msg, null, UserInfo.Userid, this.txt_firend.Text);
                    }
                   if( clientsocket.Send(buffer) <=0)
                   {
                       clientsocket.Disconnect(true);
                       SocketConnect();
                   }
                }


            }
            catch (Exception ex)
            {
                
                 SetSateMsg("发送消息错误:  " + ex.Message + "\n\r");
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

        private void Reconnect()
        {

            if (!clientsocket.Connected)
            {
                SetSateMsg("服务器已经关闭,正在尝试重新连接");
                do
                {

                    SocketConnect();
                    if (clientsocket.Connected)
                    {
                        this.btn_start.Enabled = false;
                        SetSateMsg(clientsocket.LocalEndPoint.ToString() + "连接成功");
                        Thread th = new Thread(ReciveMsg);
                        th.IsBackground = true;
                        th.Start();

                        SetSateMsg("服务器重新连接");
                    }

                } while (!clientsocket.Connected);
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
                    this.Location = new Point(this.Location.X - 3 * n, this.Location.Y - 3 * n);
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
                if (clientsocket!= null && clientsocket.Connected)
                {
                    Users u = new Users()
                               {
                                   Nickname = this.txt_NickName.Text
                               };
                    UserInfo.Nickname = this.txt_NickName.Text;
                    string umsg = jss.Serialize(u);
                    byte[] buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Login, u.Nickname, umsg, null, "0", "0");
                    clientsocket.Send(buffer);
                    SetSateMsg("登录成功");
                    this.btn_login.Enabled = false; 
                }
            }
            catch (Exception ex)
            {
                  SetSateMsg("登录失败"+ex.Message);
                  this.btn_login.Enabled = true;
                
            }
        }

        private void btn_shaken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserInfo.Userid))
            {
                this.lstbox_sate.Items.Add("还没有登录");
                return;
            }

            string toId = this.txt_firend.Text =="" ?"0":this.txt_firend.Text ;
            string fromId = "0";
            if(toId !="0") fromId =UserInfo.Userid;

            var buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.Shaken, UserInfo.Nickname,"", null, fromId, toId);
            if(clientsocket != null && clientsocket.Connected)
            clientsocket.Send(buffer);
        }

        private void btnselectfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtfile.Text = open.FileName;
            }
        }

        private void btnsendfile_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(UserInfo.Userid))
                {
                    this.lstbox_sate.Items.Add("还没有登录");
                    return;
                }
                string friend = this.txt_firend.Text;
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
                        byte[] buffer = MessageHeader.WriteMsgWithHeader(CommonClass.MessageHeader.MessageHead.File, UserInfo.Nickname, filename, file, UserInfo.Userid, friend);

                        //userdic[user].Send(buffer);
                        if (clientsocket != null && clientsocket.Connected)
                            clientsocket.Send(buffer);

                    }
                }
                else
                {
                    MessageBox.Show("文件不存在!路径不对..");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送文件错误:"+ex.Message);
            }

        }
        

    }
}
