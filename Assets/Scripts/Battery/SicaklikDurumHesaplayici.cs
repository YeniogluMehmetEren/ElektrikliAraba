using UnityEngine;

public class SicaklikDurumHesaplayici
{
    public const int min_normal_sicaklik = 20;
    public const int max_normal_sicaklik = 35;

    public const int min_uyari_sicaklik = 36;
    public const int max_uyari_sicaklik = 55;

    public const int min_kritik_sicaklik = 56;
    public const int max_kritik_sicaklik = 75;

    public static HucreDurumu Hesapla(float sicaklik)
    {
        if (sicaklik >= min_normal_sicaklik && sicaklik <= max_normal_sicaklik)
            return HucreDurumu.Normal;

        if (sicaklik >= min_uyari_sicaklik && sicaklik <= max_uyari_sicaklik)
            return HucreDurumu.Uyarı;

        return HucreDurumu.Kritik;
    }
}