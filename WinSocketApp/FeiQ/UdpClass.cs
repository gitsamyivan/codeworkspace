using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace FeiQ
{
    public enum SendMsgHead
    {
        Online =1,  //发送online消息
        AnOnline,   //应答online消息
        Offline,   //下线消息
        Login,    //Login消息
        AnLogin,  //Login消息应答
        SendMessages, //发送普通消息
        ReciveMessages, //发送普通消息
        SendFile,  //文件
        ReciveFile,  //文件
        Shaken,//震动
    }

   public class UdpClass
    {
        private Socket UdpSocket;
        public const int port = 11000;

       public UdpClass()
        {
            UdpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            StarListener();
        }
        public void StarListener()
        {
            UdpClient udpclient = new UdpClient(port);
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, port);
            try
            {
                while (true)
                {
                    byte[] bytes = udpclient.Receive(ref ipendpoint);
                    string strIP = "信息来自" + ipendpoint.Address.ToString();
                    string strInfo = Encoding.GetEncoding("gb2312").GetString(bytes, 0, bytes.Length);
                    MessageBox.Show(strInfo, strIP);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public string UdpSend(string strServer, string strContent)
        {
            IPAddress ipaddress = IPAddress.Parse(strServer);
            byte[] btContent = Encoding.GetEncoding("gb2312").GetBytes(strContent);
            IPEndPoint ipendpoint = new IPEndPoint(ipaddress, port);
            UdpSocket.SendTo(btContent, ipendpoint);
            CloseSocket();
            return "发送成功！";
        }

        private void CloseSocket()
        {
            if(UdpSocket != null && UdpSocket.Connected)
                   UdpSocket.Close();
        }


    }




}
