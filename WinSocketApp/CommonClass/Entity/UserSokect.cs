using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommonClass.Entity
{
  public  class UserSokect
    {
      public Users UserInfo { get; set; }
      public Socket UserSocket { get; set; }
      public EndPoint IpEndpoint { get; set; }


    }
}
