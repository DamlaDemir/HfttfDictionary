using hfttfSozluk.Models.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace hfttfSozluk.BusinessLayer
{
    public class business
    {
        string conStrig = WebConfigurationManager.ConnectionStrings["Local_DatabaseConnection"].ConnectionString;

        public KullaniciResponse GirisYap(string kulAdi, string parola)
        {
            KullaniciResponse lk = new KullaniciResponse();
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();

                SqlCommand cmdd = new SqlCommand("spGirisYap", conn);
                cmdd.Parameters.Add(new SqlParameter("@kulAdi", kulAdi));
                cmdd.Parameters.Add(new SqlParameter("@kulParola", parola));

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    rd.Read();
                    lk.id = (int)rd["kullaniciId"];
                    lk.girisYapildiMi = true;

                }
                conn.Dispose();
                conn.Close();
            }
            return lk;
        }

        public List<GonderiResponse> TariheGoreGonderiGetir()
        {
            List<GonderiResponse> lg = new List<GonderiResponse>();
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spTariheGoreGonderileriGetir", conn);


                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        GonderiResponse g = new GonderiResponse();
                        g.id = (int)rd["gonderiId"];
                        g.baslik = rd["gonderiBaslik"].ToString();
                        g.icerik = rd["gonderiIcerik"].ToString();
                        g.tarih = rd["gonderiTarihi"].ToString();
                        g.kullaniciAdi = rd["kullaniciAdi"].ToString();
                        g.begeni = (int)rd["begeniSayi"];
                        g.etiketler = GonderininEtiketleriniGetir(g.id);
                        lg.Add(g);
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return lg;
        }

        public List<GonderiResponse> KullaniciGonderileriGetir(string kulAdi)
        {
            List<GonderiResponse> lg = new List<GonderiResponse>();
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spKullaniciGonderileriniGetir", conn);
                cmdd.Parameters.Add(new SqlParameter("@kullaniciAdi", kulAdi));

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        GonderiResponse g = new GonderiResponse();
                        g.baslik = rd["gonderiBaslik"].ToString();
                        g.icerik = rd["gonderiIcerik"].ToString();
                        g.tarih = rd["gonderiTarihi"].ToString();
                        g.begeni = (int)rd["begeniSayi"];
                        lg.Add(g);
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return lg;
        }

        public List<YorumResponse> YorumGetir(int gonderiId)
        {
            List<YorumResponse> ly = new List<YorumResponse>();
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spGonderiYorumlariGetir", conn);
                cmdd.Parameters.Add(new SqlParameter("@gonderiId", gonderiId));

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        YorumResponse y = new YorumResponse();
                        y.yorumIcerik = rd["yorumIcerik"].ToString();
                        y.yorumTarih = rd["YorumTarih"].ToString();
                        y.kulAdi = rd["kullaniciAdi"].ToString();
                        ly.Add(y);
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return ly;
        }

        public List<AltYorumGetirResponse> AltYorumGetir(int yorumId)
        {
            List<AltYorumGetirResponse> ly = new List<AltYorumGetirResponse>();
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spAltYorumlarıGetir", conn);
                cmdd.Parameters.Add(new SqlParameter("@yorumId", yorumId));

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        AltYorumGetirResponse y = new AltYorumGetirResponse();
                        y.altYorumIcerik = rd["altYorumIcerik"].ToString();
                        y.altYorumTarih = rd["altYorumTarih"].ToString();
                        y.kulAdi = rd["kullaniciAdi"].ToString();
                        ly.Add(y);

                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return ly;
        }


        public List<EtiketResponse> TumEtiketleriGetir()
        {
            List<EtiketResponse> le = new List<EtiketResponse>();
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spTariheGoreEtiketGetir", conn);

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        EtiketResponse e = new EtiketResponse();
                        e.etiketAdi = rd["etiketAdi"].ToString();
                        le.Add(e);
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return le;
        }

        public List<GonderiResponse> EtiketlereGoreAra(string etiketAdi)
        {
            List<GonderiResponse> lg = new List<GonderiResponse>();
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spEtiketeGoreGonderiGetir", conn);
                cmdd.Parameters.Add(new SqlParameter("@etiketAdi", etiketAdi));


                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        GonderiResponse g = new GonderiResponse();
                        g.baslik = rd["gonderiBaslik"].ToString();
                        g.icerik = rd["gonderiIcerik"].ToString();
                        g.tarih = rd["gonderiTarihi"].ToString();
                        g.kullaniciAdi = rd["kullaniciAdi"].ToString();
                        lg.Add(g);
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return lg;
        }

        public KullaniciResponse ProfilBilgileriGetir(string kulAdi)
        {
            KullaniciResponse k = new KullaniciResponse();

            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spProfilGetir", conn);
                cmdd.Parameters.Add(new SqlParameter("@kulAdi", kulAdi));

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    rd.Read();
                    k.kulAciklama = rd["kullaniciAciklama"].ToString();

                }
                conn.Dispose();
                conn.Close();
            }
            return k;
        }

        public List<EtiketResponse> GonderininEtiketleriniGetir(int gonderiId)
        {
            List<EtiketResponse> le = new List<EtiketResponse>();

            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spGonderiyeGoreEtiketGetir", conn);
                cmdd.Parameters.Add(new SqlParameter("@gonderiId", gonderiId));

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        EtiketResponse e = new EtiketResponse();
                        e.etiketAdi = rd["etiketAdi"].ToString();
                        le.Add(e);
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return le;
        }

        public List<MedyaResponse> MedyalarıGetir(int gonderiId)
        {
            List<MedyaResponse> lm = new List<MedyaResponse>();

            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spMedyalariGetir", conn);
                cmdd.Parameters.Add(new SqlParameter("@gonderiId", gonderiId));

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        MedyaResponse m = new MedyaResponse();
                        m.yol = rd["yol"].ToString();
                        lm.Add(m);
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return lm;
        }

        public bool GonderiEkle(string gonderiBaslik, string gonderiIcerik, DateTime gonderiTarihi, int kullaniciId)
        {
            bool sonuc = false;

            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spGonderiEkle", conn);
                cmdd.CommandType = CommandType.StoredProcedure;

                cmdd.Parameters.Add(new SqlParameter("@gonderiBaslik", gonderiBaslik));
                cmdd.Parameters.Add(new SqlParameter("@gonderiIcerik", gonderiIcerik));
                cmdd.Parameters.Add(new SqlParameter("@gonderiTarihi", gonderiTarihi));
                cmdd.Parameters.Add(new SqlParameter("@kullaniciId", kullaniciId));
                cmdd.CommandTimeout = 600;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        sonuc = (bool)rd["durum"];
                    }
                }

                conn.Dispose();
                conn.Close();
            }
            return sonuc;
        }

        public bool YorumEkle(string yorumIcerik, int kullaniciId, int gonderiId, DateTime yorumTarih)
        {

            bool sonuc = false;
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spYorumEkle", conn);
                cmdd.CommandType = CommandType.StoredProcedure;

                cmdd.Parameters.Add(new SqlParameter("@yorumIcerik", yorumIcerik));
                cmdd.Parameters.Add(new SqlParameter("@kullaniciId", kullaniciId));
                cmdd.Parameters.Add(new SqlParameter("@gonderiId", gonderiId));
                cmdd.Parameters.Add(new SqlParameter("@yorumTarih", yorumTarih));
                cmdd.CommandTimeout = 600;

                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        sonuc = (bool)rd["durum"];
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return sonuc;

        }

        public bool AltYorumEkle(string altYorumIcerik, int yorumId, int kullaniciId, DateTime altYorumTarih)
        {
            bool sonuc = false;
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spAltYorumEkle", conn);
                cmdd.CommandType = CommandType.StoredProcedure;

                cmdd.Parameters.Add(new SqlParameter("@altYorumIcerik", altYorumIcerik));
                cmdd.Parameters.Add(new SqlParameter("@yorumId", yorumId));
                cmdd.Parameters.Add(new SqlParameter("@kullaniciId", kullaniciId));
                cmdd.Parameters.Add(new SqlParameter("@altYorumTarih", altYorumTarih));
                cmdd.CommandTimeout = 600;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        sonuc = (bool)rd["durum"];
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return sonuc;

        }

        public bool ArkadasEkle(int takipEdenId, int takipEdilenId)
        {
            bool sonuc = false;
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spArkadasEkle", conn);
                cmdd.CommandType = CommandType.StoredProcedure;

                cmdd.Parameters.Add(new SqlParameter("@takipEdenId", takipEdenId));
                cmdd.Parameters.Add(new SqlParameter("@takipEdilenId", takipEdilenId));
                cmdd.CommandTimeout = 600;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        sonuc = (bool)rd["durum"];
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return sonuc;
        }

        public GonderiResponse GonderiGetir(int gonderiId)
        {
            GonderiResponse g = new GonderiResponse();
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spGonderiGetir", conn);
                cmdd.CommandType = CommandType.StoredProcedure;

                cmdd.Parameters.Add(new SqlParameter("@gonderiId", gonderiId));

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        g.baslik = rd["gonderiBaslik"].ToString();
                        g.icerik = rd["gonderiIcerik"].ToString();
                        g.tarih = rd["gonderiTarihi"].ToString();
                        g.kullaniciAdi = rd["kullaniciAdi"].ToString();
                    }
                }
                conn.Dispose();
                conn.Close();

            }
            return g;
        }

        public bool KayitOl(string kullaniciAdi, string kullaniciParola, string kullaniciEmail, string kullaniciAciklama)
        {
            bool sonuc = false;
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spKayitOl", conn);
                cmdd.CommandType = CommandType.StoredProcedure;

                cmdd.Parameters.Add(new SqlParameter("@kullaniciAdi", kullaniciAdi));
                cmdd.Parameters.Add(new SqlParameter("@kullaniciParola", kullaniciParola));
                cmdd.Parameters.Add(new SqlParameter("@kullaniciEmail", kullaniciEmail));
                cmdd.Parameters.Add(new SqlParameter("@kullaniciAciklama", kullaniciAciklama));
                cmdd.CommandTimeout = 600;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        sonuc = (bool)rd["durum"];
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return sonuc;

        }

        public List<ArkadasResponse> ArkadaslariGetir(int kullaniciId)
        {
            List<ArkadasResponse> la = new List<ArkadasResponse>();
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spArkadaslariGetir", conn);

                cmdd.CommandTimeout = 600;
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        ArkadasResponse a = new ArkadasResponse();
                        a.kullaniciId = (int)rd["kullaniciId"];
                        a.kullaniciAdi = rd["kullaniciAdi"].ToString();

                        la.Add(a);
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return la;
        }

        public bool begeniEkle(int gonderiId, int kullaniciId)
        {
            bool sonuc = false;
            using (SqlConnection conn = new SqlConnection(conStrig))
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("spBegeniEkle", conn);
                cmdd.CommandType = CommandType.StoredProcedure;

                cmdd.Parameters.Add(new SqlParameter("@gonderiId", gonderiId));
                cmdd.Parameters.Add(new SqlParameter("@kullaniciId", kullaniciId));
                cmdd.CommandTimeout = 600;
                SqlDataReader rd = cmdd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    while (rd.Read())
                    {
                        sonuc = (bool)rd["durum"];
                    }
                }
                conn.Dispose();
                conn.Close();
            }
            return sonuc;

        }


    }

}