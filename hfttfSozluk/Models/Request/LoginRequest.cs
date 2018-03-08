using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hfttfSozluk.Models.Request
{
    public class LoginRequest
    {
        public string kulAdi { get; set; }
        public string sifre { get; set; }
    }
}