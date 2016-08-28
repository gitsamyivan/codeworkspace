using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FeiQ
{
   public class IpHelper
    {
       public static string GetIpbyUrl(string Url){
        string strUrl = "提供IP查询的网站的链接";  
         Uri uri = new Uri(strUrl);  
         WebRequest webreq = WebRequest.Create(uri);  
         Stream s = webreq .GetResponse().GetResponseStream();  
         StreamReader sr = new StreamReader(s, Encoding.Default);  
         string all = sr.ReadToEnd();   
         int i = all.IndexOf("[") + 1;  
         //分析字符串得到IP   
         return "";
       }

       public static string GetLocalIp()  
        {  
            string hostname = Dns.GetHostName();//得到本机名   
            IPHostEntry localhost = Dns.GetHostByName(hostname);
            //IPHostEntry localhost = Dns.GetHostEntry(hostname);
            IPAddress localaddr = localhost.AddressList[0];  
            return localaddr.ToString();  
        }


       private void GetIP6()
       {
           Process cmd = new Process();
           cmd.StartInfo.FileName = "ipconfig.exe";//设置程序名   
           cmd.StartInfo.Arguments = "/all";  //参数   
           //重定向标准输出   
           cmd.StartInfo.RedirectStandardOutput = true;
           cmd.StartInfo.RedirectStandardInput = true;
           cmd.StartInfo.UseShellExecute = false;
           cmd.StartInfo.CreateNoWindow = true;//不显示窗口（控制台程序是黑屏）   
           //cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//暂时不明白什么意思   
           /* 
    收集一下 有备无患 
           关于:ProcessWindowStyle.Hidden隐藏后如何再显示？ 
           hwndWin32Host = Win32Native.FindWindow(null, win32Exinfo.windowsName); 
           Win32Native.ShowWindow(hwndWin32Host, 1);     //先FindWindow找到窗口后再ShowWindow 
           */
           cmd.Start();
           string info = cmd.StandardOutput.ReadToEnd();
           cmd.WaitForExit();
           cmd.Close();
           //textBox1.AppendText(info);
       }

    }
}
