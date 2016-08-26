using CommonClass.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace CommonClass
{
    public class MessageHeader
    {
       private static JavaScriptSerializer jss = new JavaScriptSerializer();
        public enum MessageHead
        {
            Login =0,
            Message =1,
            File =2,
            Shaken =3,
            ChatFriend =4,

        }


        public static byte[] WriteMsgWithHeader(MessageHead type, string msgstr, byte[] fs = null, string FromId = "",string ToId ="")
        {
            byte[] buffer;
            List<byte> data = new List<byte>();
            //data.Add((byte)type);
            //if (type == MessageHead.File)
            //{
            //  //byte[]  file= new byte[fs.Length];
            //  //fs.Read(file, 0, file.Length);
            //  byte[] filename = new byte[30];
            //  byte[] temp= Encoding.UTF8.GetBytes(msgstr);
            //    int length =temp.Length;
            //    if (length > 30)
            //  {
            //      //取数组后30位元素
            //      filename = temp.Reverse().Take(30).Reverse().ToArray();
            //  }
            //  else {
            //      for (int i = 0; i < 30; i++)
            //      {
            //          if (i < length)
            //              filename[i] = temp[i];
            //          else
            //              filename[i] = 0;
            //      }
            //  }

            //  data.AddRange(filename);
            //  data.AddRange(fs);
            //}
            //else
            //{
            //    data.AddRange(Encoding.UTF8.GetBytes(msgstr));
            //}


            MsgHeader obj = new MsgHeader { fromId = FromId, toId = ToId, Msg = msgstr, type = (int)type };
            string package = jss.Serialize(obj);
            byte[] msg = Encoding.UTF8.GetBytes(package);
            data.AddRange(msg);


            buffer = data.ToArray();
            return buffer;
        }


        public static byte[] FeiQWritePackage(MessageHead type, string msgstr, byte[] fs = null)
        {
            byte[] buffer;
            List<byte> data = new List<byte>();
            data.Add((byte)type);
            if (type == MessageHead.File)
            {
                //byte[]  file= new byte[fs.Length];
                //fs.Read(file, 0, file.Length);
                byte[] filename = new byte[30];
                byte[] temp = Encoding.UTF8.GetBytes(msgstr);
                int length = temp.Length;
                if (length > 30)
                {
                    //取数组后30位元素
                    filename = temp.Reverse().Take(30).Reverse().ToArray();
                }
                else
                {
                    for (int i = 0; i < 30; i++)
                    {
                        if (i < length)
                            filename[i] = temp[i];
                        else
                            filename[i] = 0;
                    }
                }

                data.AddRange(filename);
                data.AddRange(fs);
            }
            else
            {
                data.AddRange(Encoding.UTF8.GetBytes(msgstr));
            }


            buffer = data.ToArray();
            return buffer;

        }

    }
}
