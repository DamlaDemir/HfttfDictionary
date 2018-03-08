using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hfttfSozluk.Models.Response
{
    public class GonderiResponse
    {
        public int id { get; set; }
        public string baslik { get; set; }
        public string icerik { get; set; }
        public string tarih { get; set; }
        public string kullaniciAdi { get; set; }
        public int begeni { get; set; }
        public List<EtiketResponse> etiketler { get; set; }
    }
}