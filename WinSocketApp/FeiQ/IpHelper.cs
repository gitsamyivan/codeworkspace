using System;
using System.Collections.Generic;
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

    }
}
