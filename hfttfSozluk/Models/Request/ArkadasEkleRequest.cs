using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hfttfSozluk.Models.Request
{
    public class ArkadasEkleRequest
    {
        public int takipEdenId { get; set; }
        public int takipEdilenId { get; set; }
    }
}