﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestAPp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Socket soc = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine(soc.GetHashCode());
                
            //}


            Console.WriteLine(GetLocalIp());
            Console.ReadKey();
        }



        public static string GetLocalIp()
        {
            try
            {
                string hostname = Dns.GetHostName();//得到本机名   
                IPHostEntry localhost = Dns.GetHostEntry(hostname);
                //IPHostEntry localhost = Dns.GetHostByName(hostname);
                //IPAddress localaddr = localhost.AddressList[1];
                foreach (IPAddress item in localhost.AddressList)
                {
                    if (item.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return item.ToString();
                    }
                }

                return "127.0.0.1";
            }
            catch (Exception)
            {
                   return "127.0.0.1";
            }
        } 
    }
}
