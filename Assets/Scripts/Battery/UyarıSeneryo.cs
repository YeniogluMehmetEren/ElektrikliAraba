using System.Collections.Generic;
using UnityEngine;

public class UyarıSeneryo : ISeneryo
{
    const int min_uyari_sicaklik = SicaklikDurumHesaplayici.min_uyari_sicaklik;
    const int max_uyari_sicaklik = SicaklikDurumHesaplayici.max_uyari_sicaklik;

    const int min_normal_sicaklik = SicaklikDurumHesaplayici.min_normal_sicaklik;
    const int max_normal_sicaklik = SicaklikDurumHesaplayici.max_normal_sicaklik;


    public int uyari_hucre_sayisi;

    public HashSet<int> uyari_hücre_id = new HashSet<int>();

    public HucreSicakligi[] SicaklikOlustur()
    {
        uyariHucreIdsiBul();

        HucreSicakligi[] hucre_sicakligi = new HucreSicakligi[12];

        for (int i = 0; i < hucre_sicakligi.Length; i++)
        {
            hucre_sicakligi[i] = new HucreSicakligi();

            float sicaklik = 0f;
            int gun = 0;

            if (uyari_hücre_id.Contains(i))
            {
                sicaklik = UyariSonrakiGunSicakligi(sicaklik, gun);
                hucre_sicakligi[i].BirinciGun = sicaklik;

                gun++;
                sicaklik = UyariSonrakiGunSicakligi(sicaklik, gun);
                hucre_sicakligi[i].IkinciGun = sicaklik;

                gun++;
                sicaklik = UyariSonrakiGunSicakligi(sicaklik, gun);
                hucre_sicakligi[i].UcuncuGun = sicaklik;
            }
            else
            {
                sicaklik = NormalSonrakiGunSicakligi(sicaklik, gun);
                hucre_sicakligi[i].BirinciGun = sicaklik;

                gun++;
                sicaklik = NormalSonrakiGunSicakligi(sicaklik, gun);
                hucre_sicakligi[i].IkinciGun = sicaklik;

                gun++;
                sicaklik = NormalSonrakiGunSicakligi(sicaklik, gun);
                hucre_sicakligi[i].UcuncuGun = sicaklik;
            }
        }

        return hucre_sicakligi;
    }

    private float UyariSonrakiGunSicakligi(float mevcutSicaklik, int gun)
    {
        if (gun == 0)
        {
            bool normaldenBasla = Random.value < 0.6f;

            if (normaldenBasla)
            {
                mevcutSicaklik = Random.Range(30f, 35f);
            }
            else
            {
                mevcutSicaklik = Random.Range(min_uyari_sicaklik, 42f);
            }
        }
        else
        {
            if (mevcutSicaklik < min_uyari_sicaklik)
            {
                mevcutSicaklik += Random.Range(4f, 8f);
            }
            else if (mevcutSicaklik < 45f)
            {
                mevcutSicaklik += Random.Range(3f, 6f);
            }
            else if (mevcutSicaklik < 52f)
            {
                mevcutSicaklik += Random.Range(1f, 3f);
            }
            else
            {
                mevcutSicaklik += Random.Range(-1f, 1f);
            }
        }

        mevcutSicaklik = Mathf.Clamp(mevcutSicaklik, min_normal_sicaklik, max_uyari_sicaklik);

        return Mathf.Round(mevcutSicaklik * 10f) / 10f;
    }

    private float NormalSonrakiGunSicakligi(float mevcutSicaklik, int gun)
    {
        if (gun == 0)
        {
            return Mathf.Round(Random.Range((float)min_normal_sicaklik, (float)max_normal_sicaklik) * 10f) / 10f;
        }

        if (mevcutSicaklik >= 34f)
        {
            mevcutSicaklik -= Random.Range(0.5f, 1.5f);
        }
        else if (mevcutSicaklik >= 31f)
        {
            mevcutSicaklik += Random.Range(-1.5f, 0.5f);
        }
        else if (mevcutSicaklik >= 28f)
        {
            mevcutSicaklik += Random.Range(-1f, 3f);
        }
        else if (mevcutSicaklik >= 22f)
        {
            mevcutSicaklik += Random.Range(-1f, 4f);
        }
        else
        {
            mevcutSicaklik += Random.Range(1f, 5f);
        }

        return Mathf.Round(mevcutSicaklik * 10f) / 10f;
    }

    public void uyariHucreSayisi()
    {
        uyari_hucre_sayisi = Random.Range(1, 5);
    }

    public void uyariHucreIdsiBul()
    {
        uyari_hücre_id.Clear();
        uyariHucreSayisi();
        while (uyari_hücre_id.Count < uyari_hucre_sayisi)
        {
            int cell_id = Random.Range(0,12);
            uyari_hücre_id.Add(cell_id);
        }
        
    }
}
