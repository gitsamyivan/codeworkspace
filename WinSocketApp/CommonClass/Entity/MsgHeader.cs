﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.Entity
{
   public class MsgHeader
    {
       public string fromId { get; set; }
       public string toId { get; set; }
       public int type { get; set; }
       public string Msg { get; set; }

    }
}
