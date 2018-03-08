using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hfttfSozluk.Models.Response
{
    public class KullaniciResponse
    {
        public string kulAdi { get; set; }
        public string parola { get; set; }
        public string kulAciklama { get; set; }
        public int id { get; set; }
        public bool girisYapildiMi { get; set; }
    }
}