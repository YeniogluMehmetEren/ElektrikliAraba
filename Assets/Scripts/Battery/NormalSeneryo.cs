using UnityEngine;

public class NormalSeneryo : ISeneryo
{
    const int min_sicaklik = SicaklikDurumHesaplayici.min_normal_sicaklik;
    const int max_sicaklik = SicaklikDurumHesaplayici.max_normal_sicaklik;

    


    public HucreSicakligi[] SicaklikOlustur()
    {
        HucreSicakligi[] hucre_sicakligi = new HucreSicakligi[12];
        
        for(int i = 0; i < hucre_sicakligi.Length; i++)
        {
            hucre_sicakligi[i] = new HucreSicakligi();
            float sicaklik = 0f;
            int flag = 0;
            sicaklik = SonrakiGunSicakligi(sicaklik, flag);
            hucre_sicakligi[i].BirinciGun = sicaklik;
            flag++;
            sicaklik = SonrakiGunSicakligi(sicaklik, flag);
            hucre_sicakligi[i].IkinciGun = sicaklik;
            flag++;
            sicaklik = SonrakiGunSicakligi(sicaklik, flag);
            hucre_sicakligi[i].UcuncuGun = sicaklik;
        }

        return hucre_sicakligi;
    }

    private float SonrakiGunSicakligi(float mevcutSicaklik, int flag)
    {
        if (flag == 0)
        {
            return Mathf.Round(Random.Range((float)min_sicaklik, (float)max_sicaklik) * 10f) / 10f;
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
}
