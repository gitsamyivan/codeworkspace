using CommonClass.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass
{
 public  class UserDatas
    {

     public static List<Users> users = new List<Users>(){
         new Users(){Userid ="00001",Nickname="Steven",Age=15,Gender="Man"},
         new Users(){Userid ="00002",Nickname="Lili",Age=25,Gender="Woman"},
         new Users(){Userid ="00003",Nickname="Sam",Age=33,Gender="Woman"},
         new Users(){Userid ="00004",Nickname="Demo",Age=21,Gender="Man"},
         new Users(){Userid ="00005",Nickname="Teswt",Age=11,Gender="Woman"},
         new Users(){Userid ="00006",Nickname="Kiven",Age=58,Gender="Man"},
     };

    }
}
