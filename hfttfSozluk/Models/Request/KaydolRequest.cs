using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hfttfSozluk.Models.Request
{
    public class KaydolRequest
    {
        public string kullaniciAdi { get; set; }
        public string kullaniciParola { get; set; }
        public string kullaniciEmail { get; set; }
        public string kullaniciAciklama { get; set; }
    }
}