using hfttfSozluk.BusinessLayer;
using hfttfSozluk.Models.Request;
using hfttfSozluk.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hfttfSozluk.Controllers
{
    
    public class ValuesController : ApiController
    {
        business b = new business();
        [HttpPost]
        public KullaniciResponse Login([FromBody]LoginRequest lr)
        {
            return b.GirisYap(lr.kulAdi, lr.sifre);
        }

        [HttpGet]
        public List<GonderiResponse> AnasayfaGonderiler()
        {
            return b.TariheGoreGonderiGetir();
        }

        [HttpPost]
        public List<GonderiResponse> KullaniciGonderileriGetir([FromBody]KullaniciGonderiRequest kg)
        {
            return b.KullaniciGonderileriGetir(kg.kulAdi);
        }

        [HttpPost]
        public List<YorumResponse> YorumGetir([FromBody]GonderiIdRequest gr)
        {
            return b.YorumGetir(gr.gonderiId);
        }

        [HttpPost]
        public List<AltYorumGetirResponse> AltYorumGetir([FromBody]AltYorumGetirRequest ar)
        {
            return b.AltYorumGetir(ar.yorumId);
        }

        [HttpGet]
        public List<EtiketResponse> TumEtiketleriGetir()
        {
            return b.TumEtiketleriGetir();
        }

        [HttpPost]
        public List<GonderiResponse> EtiketeGoreAra([FromBody]EtiketeGoreAraRequest er)
        {
            return b.EtiketlereGoreAra(er.etiketAdi);

        }

        [HttpPost]
        public KullaniciResponse ProfilGetir([FromBody]ProfilRequest pr)
        {
            return b.ProfilBilgileriGetir(pr.kulAdi);
        }

        [HttpPost]
        public List<EtiketResponse> GonderininEtiketleriniGetir([FromBody]GonderiIdRequest gr)
        {
            return b.GonderininEtiketleriniGetir(gr.gonderiId);
        }

        [HttpPost]
        public List<MedyaResponse> MedyalarıGetir([FromBody]GonderiIdRequest gr)
        {
            return b.MedyalarıGetir(gr.gonderiId);
        }

        [HttpPost]
        public bool GonderiEkle([FromBody]GonderiEkleRequest gr)
        {
            return b.GonderiEkle(gr.gonderiBaslik, gr.gonderiIcerik, gr.gonderiTarihi, gr.kullaniciId);
        }

        [HttpPost]
        public bool YorumEkle([FromBody]YorumEkleRequest yr)
        {
            return b.YorumEkle(yr.yorumIcerik, yr.kullaniciId, yr.gonderiId, yr.yorumTarih);
        }

        [HttpPost]
        public bool AltYorumEkle([FromBody]AltYorumEkleRequest ayr)
        {
            return b.AltYorumEkle(ayr.altYorumIcerik, ayr.yorumId, ayr.kullaniciId, ayr.altYorumTarih);
        }

        [HttpPost]
        public bool ArkadasEkle([FromBody]ArkadasEkleRequest aer)
        {
            return b.ArkadasEkle(aer.takipEdenId, aer.takipEdilenId);
        }

        [HttpPost]
        public bool KayitOl([FromBody]KaydolRequest kr)
        {
            return b.KayitOl(kr.kullaniciAdi, kr.kullaniciParola, kr.kullaniciEmail, kr.kullaniciAciklama);
        }

        [HttpPost]
        public List<ArkadasResponse> ArkadaslariGetir([FromBody]ArkadaslariGetirRequest ar)
        {
            return b.ArkadaslariGetir(ar.kullaniciId);
        }

        [HttpPost]
        public bool BegeniEkle([FromBody]BegeniEkleRequest br)
        {
            return b.begeniEkle(br.gonderiId, br.kullaniciId);
        }



        [HttpPost]
        public GonderiResponse GonderiGetir([FromBody]GonderiIdRequest gr)
        {
            return b.GonderiGetir(gr.gonderiId);
        }
    }
}
