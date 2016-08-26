using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass
{
   public class MethodHlper
    {

        static char[] ch = new char[]{
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        };


        public static string CreateId()
        {
            StringBuilder sb= new StringBuilder(62);
            Random r = new Random();
            for (int i = 0; i < 9; i++)
			{
                int temp = r.Next(0,61);
			    sb.Append(ch[temp]);
			}
            return sb.ToString();
        }


        public static string RandomLenth(int length)
        {
            StringBuilder sb = new StringBuilder(62);
            Random r = new Random();
            for (int i = 0; i < length-1; i++)
            {
                int temp = r.Next(0, 61);
                sb.Append(ch[temp]);
            }
            return sb.ToString();
        }
    }
}
