using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hfttfSozluk.Models.Request
{
    public class YorumEkleRequest
    {
        public string yorumIcerik { get; set; }
        public int kullaniciId { get; set; }
        public int gonderiId { get; set; }
        public DateTime yorumTarih { get; set; }
    }
}