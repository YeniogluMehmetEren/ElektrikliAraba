using System.Collections.Generic;
using UnityEngine;

public class KritikSeneryo : ISeneryo
{

    const int min_kritik_sicaklik = SicaklikDurumHesaplayici.min_kritik_sicaklik;
    const int max_kritik_sicaklik = SicaklikDurumHesaplayici.max_kritik_sicaklik;

    const int min_normal_sicaklik = SicaklikDurumHesaplayici.min_normal_sicaklik;
    const int max_normal_sicaklik = SicaklikDurumHesaplayici.max_normal_sicaklik;



    public int kritik_hucre_sayisi;

    public HashSet<int> kritik_hücre_id = new HashSet<int>();

    public HucreSicakligi[] SicaklikOlustur()
    {
        kritikHucreIdsiBul();

        HucreSicakligi[] hucre_sicakligi = new HucreSicakligi[12];

        for (int i = 0; i < hucre_sicakligi.Length; i++)
        {
            hucre_sicakligi[i] = new HucreSicakligi();

            float sicaklik = 0f;
            int gun = 0;

            if (kritik_hücre_id.Contains(i))
            {
                sicaklik = KritikSonrakiGunSicakligi(sicaklik, gun);
                hucre_sicakligi[i].BirinciGun = sicaklik;

                gun++;
                sicaklik = KritikSonrakiGunSicakligi(sicaklik, gun);
                hucre_sicakligi[i].IkinciGun = sicaklik;

                gun++;
                sicaklik = KritikSonrakiGunSicakligi(sicaklik, gun);
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

    private float KritikSonrakiGunSicakligi(float mevcutSicaklik, int gun)
    {
        if (gun == 0)
        {
            return Mathf.Round(Random.Range(min_kritik_sicaklik, 60f) * 10f) / 10f;
            
        }

        if (mevcutSicaklik >= 72f)
        {
            mevcutSicaklik += Random.Range(-2f, 1f);
        }
        else if (mevcutSicaklik >= 66f)
        {
            mevcutSicaklik += Random.Range(-1f, 2f);
        }
        else if (mevcutSicaklik >= 60f)
        {
            mevcutSicaklik += Random.Range(0f, 3f);
        }
        else
        {
            mevcutSicaklik += Random.Range(1f, 4f);
        }

        mevcutSicaklik = Mathf.Clamp(mevcutSicaklik, min_kritik_sicaklik, max_kritik_sicaklik);

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

    public void kritikHucreSayisi()
    {
        kritik_hucre_sayisi = Random.Range(1, 5);
    }

    public void kritikHucreIdsiBul()
    {

        kritik_hücre_id.Clear();
        kritikHucreSayisi();
        while (kritik_hücre_id.Count < kritik_hucre_sayisi)
        {
            int cell_id = Random.Range(0, 12);
            kritik_hücre_id.Add(cell_id);
        }

    }
}