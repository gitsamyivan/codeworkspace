using CommonClass;
using CommonClass.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FeiQ
{
    public partial class MainForm : Form
    {
        public static Users UserInfo;
        private List<Users> OnlineClients = new List<Users>();
        public Dictionary<string, UserSokect> userdic = new Dictionary<string, UserSokect>();
        private static string BindPort = ConfigurationManager.AppSettings["BindPort"];
        //private static string IPaddressstr = ConfigurationManager.AppSettings["BindPort"];
        private int Udpport = string.IsNullOrEmpty(BindPort) ? 9000 : Convert.ToInt32(BindPort);


        private JavaScriptSerializer jss = new JavaScriptSerializer();
        public Socket ServerSokect;
        public MainForm(string Id)
        {
            this.Text = Id;
            CheckForIllegalCrossThreadCalls = false;
            UserInfo = new Users() { Userid = Id };
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            StarListener();
            MessageBox.Show("StarListener");

            ScanClients();
            MessageBox.Show("broadcast : " + Udpport);
       
            //RunServerSokect();     

        }

        #region  scanip

        private void ScanClients()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, 9001);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            List<byte> data = new List<byte>();
            data.Add(0);
            data.AddRange(Encoding.UTF8.GetBytes(UserInfo.Userid));
            sock.SendTo(data.ToArray(), iep);
            sock.Close();
        }

        public void StarListener()
        {

            Thread th = new Thread(() =>
            {
                try
                {
                    using (UdpClient udpclient = new UdpClient(Udpport))
                    {
                        IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 0);
                        while (true)
                        {
                            Byte[] receiveBytes = udpclient.Receive(ref ipendpoint);
                            byte[] bytes = udpclient.Receive(ref ipendpoint);
                            string ipaddress = ipendpoint.Address.ToString();

                            byte flag = bytes[0];
                            //scan
                            if (flag == 0)
                            {
                                string Message = Encoding.UTF8.GetString(bytes, 1, bytes.Length - 1);
                                userdic.Add(Message, new UserSokect()
                                {
                                    UserInfo = new Users() { Userid = Message, IpAddress = ipaddress },
                                    IpEndpoint = ipendpoint
                                });



                                this.Invoke(new Action(() =>
                                {

                                    RefreshFriendlist();
                                }));


                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
            th.IsBackground = true;
            th.Start();



         
            //UdpClient udpclient = new UdpClient(Udpport);
            //IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, Udpport);
            //try
            //{
            //    while (true)
            //    {
            //        byte[] bytes = udpclient.Receive(ref ipendpoint);
            //        string ipaddress = ipendpoint.Address.ToString();
                 
            //        byte flag = bytes[0];
            //        //scan
            //        if (flag == 0)
            //        {
            //            string Message = Encoding.UTF8.GetString(bytes, 1, bytes.Length-1);
            //            userdic.Add(Message, new UserSokect()
            //            {
            //                UserInfo = new Users() { Userid = Message, IpAddress = ipaddress },
            //                IpEndpoint = ipendpoint
            //            });

            //            RefreshFriendlist();

            //        }
                  
            //    }
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.ToString());
            //}


        }


        private void RefreshFriendlist()
        {
            //lstvw_myfirends.Columns.Clear();
            //lstvw_myfirends.Items.Clear();
            lstvw_myfirends.Controls.Clear();
            this.lstvw_myfirends.Columns.Add("在线好友列表", 300, HorizontalAlignment.Left);
            int i = 0;
            foreach (var friend in userdic)
            {

                var link = new MyLinklable();
                link.Firiend = friend.Value.UserInfo;
                link.Click += LinkClickFirend;
                link.ImageIndex = i;
                link.Text = friend.Value.UserInfo.Userid;
                //lstvw_myfirends.BeginUpdate();
                this.lstvw_myfirends.Controls.Add(link);
                //lstvw_myfirends.EndUpdate();

                //var item = new ListViewItem();
                //item.ImageIndex = i;
                //item.Text = friend.Value.UserInfo.Userid;
                //lstvw_myfirends.BeginUpdate();
                //lstvw_myfirends.Add(link);
              
                //lstvw_myfirends.Items[lstvw_myfirends.Items.Count - 1].EnsureVisible(); //滚动到最后  
                //lstvw_myfirends.EndUpdate();
                i++;
            }
        }

        private  void LinkClickFirend(object sender, EventArgs e)
        {
            MyLinklable my = (MyLinklable)sender;
            SendMessage friendform = new SendMessage(this, my.Firiend);
            friendform.ShowDialog();

        }


        #endregion


        private void RunServerSokect()
        {
            try
            {
                ServerSokect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipaddr = IPAddress.Parse(IpHelper.GetLocalIp());
                Random r = new Random();
                IPEndPoint ipport = new IPEndPoint(ipaddr,r.Next(9000,10000));
                //绑定接口
                ServerSokect.Bind(ipport);
                //同一时间最大连接数
                ServerSokect.Listen(10);

                
                //this.lstbox_state.Items.Add("监听成功 \r\n");

                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(ServerSokect);
            }
            catch (Exception ex)
            {
                MessageBox.Show("RunServerSokect error"+ex.Message);
            }


        }



        private void Listen(object obj)
        {
            try
            {
                Socket con = obj as Socket;

                while (true)
                {

                    Socket client = con.Accept();
                    string ipaddress = client.RemoteEndPoint.ToString();
                    //string Uid = MethodHlper.CreateId();
                    //userdic.Add(ipaddress, client);
                    //userdic.Add(Uid, new UserSokect()
                    //{
                    //    UserSocket = client,
                    //    UserInfo = new Users() { Userid = Uid, IpAddress = ipaddress },
                    //    IpEndpoint = client.RemoteEndPoint
                    //});

                    //this.Invoke(new Action(() =>
                    //{
                    //    this.lstbox_state.Items.Add(ipaddress + " : 上线  \r\n");

                    //}));

                    Thread th = new Thread(ReciveMsg);
                    th.IsBackground = true;
                    //th.Start(client);
                    th.Start(client);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Listen error" + ex.Message);
                this.Invoke(new Action(() =>
                {

                    //this.lstbox_state.Items.Add("客服端连接错误: " + ex.Message + " \r\n");
                }));
            }
        }



        /// <summary>
        /// 接收客服端信息
        /// </summary>
        /// <param name="socket"></param>
        private void ReciveMsg(object sock)
        {
            try
            {
                Socket accept = sock as Socket;
                byte[] buffer = new byte[1024 * 1024 * 10];

                while (true)
                {
                    int length = accept.Receive(buffer);
                    string ipaddress = accept.RemoteEndPoint.ToString();

                    if (length == 0)
                    {
                        Users User =null;
                        foreach (var item in userdic)
                        {
                            if (item.Value.IpEndpoint == accept.RemoteEndPoint)
                            {
                                User = item.Value.UserInfo;
                                break;
                            }
                        }
                       

                        //SetStatemsg(ipaddress + "下线断开连接");
                        accept.Close();
                        if (User!=null)
                            userdic.Remove(User.Userid);
                        break;
                    }
                    int header = buffer[0];
                    //判断登录
                        switch (header)
                        {
                            case (int)CommonClass.MessageHeader.MessageHead.Login:
                                {
                                    string userid = Encoding.UTF8.GetString(buffer, 1, length - 1);
                                    userdic.Add(userid, new UserSokect()
                                    {
                                        UserSocket = accept,
                                        UserInfo = new Users() { Userid = userid, IpAddress = ipaddress },
                                        IpEndpoint = accept.RemoteEndPoint
                                    });

                                    break;
                                }
                            case (int)CommonClass.MessageHeader.MessageHead.Message:
                                {
                                    string msg = Encoding.UTF8.GetString(buffer, 1, length - 1);
                                    //SetStatemsg(user.Nickname + ": " + msg);
                                    break;
                                }
                            case (int)CommonClass.MessageHeader.MessageHead.File:
                                {
                                    string msg = Encoding.UTF8.GetString(buffer, 1, buffer.Length - 1);
                                    //SetStatemsg(user.Nickname + "发送文件 ");
                                    break;
                                }
                            case (int)CommonClass.MessageHeader.MessageHead.Shaken:
                                {
                                    //Shaken();
                                    break;
                                }

                        }

               


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReciveMsg error" + ex.Message);
                //this.Invoke(new Action(() =>
                //{

                  
                //}));

            }




        }

        private void Reset()
        {
            if (ServerSokect != null && ServerSokect.Connected)
            {
                ServerSokect.Shutdown(SocketShutdown.Both);
                ServerSokect.Close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reset();
            Environment.Exit(2);
            //Application.Exit();
        }

        private void btn_change_Click(object sender, EventArgs e)
        {

            ScanClients();
            MessageBox.Show("broadcast : " + Udpport);
        }
















    }

    public class MyLinklable:LinkLabel
    {
        public Users Firiend;

    }
}
