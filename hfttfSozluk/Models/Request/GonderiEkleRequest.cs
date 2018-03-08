using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hfttfSozluk.Models.Request
{
    public class GonderiEkleRequest
    {
        public string gonderiBaslik { get; set; }
        public string gonderiIcerik { get; set; }
        public DateTime gonderiTarihi { get; set; }
        public int kullaniciId { get; set; }
    }
}