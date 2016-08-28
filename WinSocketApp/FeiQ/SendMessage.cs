using CommonClass.Entity;
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

namespace FeiQ
{
    public partial class SendMessage : Form
    {
        private MainForm MainForm;
        private Users Friend;
        private Socket UdpSocket;
        public const int port = 11000;
        public SendMessage(MainForm _MainForm,Users _Friend)
        {
            MainForm = _MainForm;
            Friend = _Friend;

            UdpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            StarListener();
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string content = this.rch_sendtxt.Text;
            if (content != "")
            {
                UdpSend(Friend.IpAddress, content);
            }
        }


        public void StarListener()
        {
            UdpClient udpclient = new UdpClient(port);
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, port);
            Thread Listenthread = new Thread(() =>
            {


            try
            {
                while (true)
                {
                    byte[] bytes = udpclient.Receive(ref ipendpoint);
                    string strIP = "信息来自" + ipendpoint.Address.ToString();
                    string strInfo = Encoding.GetEncoding("gb2312").GetString(bytes, 0, bytes.Length);
                    this.rch_recivetxt.AppendText(strIP+strInfo);
                    MessageBox.Show(strIP + strInfo);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


            });
            Listenthread.IsBackground = true;
            Listenthread.Start();
        }
        public string UdpSend(string strServer, string strContent)
        {
            try
            {

                IPAddress ipaddress = IPAddress.Parse(strServer);
                byte[] btContent = Encoding.GetEncoding("gb2312").GetBytes(strContent);
                IPEndPoint ipendpoint = new IPEndPoint(ipaddress, port);
                UdpSocket.SendTo(btContent, ipendpoint);
                //CloseSocket();
                return "发送成功！";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void CloseSocket()
        {
            if(UdpSocket != null && UdpSocket.Connected)
                   UdpSocket.Close();
        }

        private void SendMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseSocket();
        }

        private void SendMessage_Load(object sender, EventArgs e)
        {

        }


    }
}
