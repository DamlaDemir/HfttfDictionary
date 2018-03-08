using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hfttfSozluk.Models.Request
{
    public class AltYorumEkleRequest
    {
        public string altYorumIcerik { get; set; }
        public int yorumId { get; set; }
        public int kullaniciId { get; set; }
        public DateTime altYorumTarih { get; set; }
    }
}