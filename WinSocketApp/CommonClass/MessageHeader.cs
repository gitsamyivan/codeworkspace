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


        public static byte[] WriteMsgWithHeader(MessageHead type, string name, string msgstr, byte[] fs = null, string FromId = "",string ToId ="")
        {
            byte[] buffer;
            List<byte> data = new List<byte>();
            if (type == MessageHead.File)
            {
                MsgHeader obj = new MsgHeader { fromId = FromId, fromName = name, toId = ToId, Msg = msgstr, File = fs, type = (int)type };
                string package = jss.Serialize(obj);
                byte[] msg = Encoding.UTF8.GetBytes(package);
                data.AddRange(msg);

            }
            else
            {
                MsgHeader obj = new MsgHeader { fromId = FromId, fromName = name, toId = ToId, Msg = msgstr, type = (int)type };
                string package = jss.Serialize(obj);
                byte[] msg = Encoding.UTF8.GetBytes(package);
                data.AddRange(msg);
            }



            buffer = data.ToArray();
            return buffer;
        }

        /// <summary>
        /// This Home Change
        /// </summary>
        /// <param name="type"></param>
        /// <param name="FromId"></param>
        /// <param name="ToId"></param>
        /// <param name="msgstr"></param>
        /// <param name="fs"></param>
        /// <returns></returns>
        public static byte[] FeiQWritePackage(MessageHead type, string FromId,string ToId, string msgstr, byte[] fs = null)
        {
            byte[] buffer;
            List<byte> data = new List<byte>();
            if (type == MessageHead.File)
            {
                MsgHeader obj = new MsgHeader { fromId = FromId, toId = ToId, Msg = msgstr,File=fs, type = (int)type };
                string package = jss.Serialize(obj);
                byte[] msg = Encoding.UTF8.GetBytes(package);
                data.AddRange(msg);
           
            }
            else
            {
                MsgHeader obj = new MsgHeader { fromId = FromId, toId = ToId, Msg = msgstr, type = (int)type };
                string package = jss.Serialize(obj);
                byte[] msg = Encoding.UTF8.GetBytes(package);
                data.AddRange(msg);
            }


            buffer = data.ToArray();
            return buffer;

        }

    }
}
