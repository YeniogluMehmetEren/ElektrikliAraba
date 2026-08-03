using UnityEngine;

public class RowUretme : MonoBehaviour
{
    [Header("Tablo Ayarlarý")]
    public Transform contentKutusu;
    public GameObject satirPrefab;

    [Header("Sonuç Tablosu")]
    public Transform contentKutusuGun1;
    public Transform contentKutusuGun2;
    public Transform contentKutusuGun3;
    public Transform contentKutusuGercekDegerGun1;
    public Transform contentKutusuGercekDegerGun2;
    public Transform contentKutusuGercekDegerGun3;
    public GameObject sonucSatirPrefab;

    public void YeniOlcumEkle()
    {
        GameObject yeniSatir = Instantiate(satirPrefab, contentKutusu);
        
        ScrollViewRowUI satirKodu = yeniSatir.GetComponent<ScrollViewRowUI>();

        if (satirKodu != null)
        {
            satirKodu.SatiriKur();
        }
    }

    public void SonucEkranýOlustur()
    {
        UIBataryaVeriGirisi veriKaydetme = FindAnyObjectByType<UIBataryaVeriGirisi>();

        foreach (var item in veriKaydetme.batteryCellDataGun1)
        {
            GameObject yeniSatir = Instantiate(sonucSatirPrefab, contentKutusuGun1);
            ScrollViewSonucRowUI satirKodu = yeniSatir.GetComponent<ScrollViewSonucRowUI>();

            if (satirKodu != null)
            {
                satirKodu.SatiriKur(item.idText.text.ToString(), item.tempText.text.ToString());
            }
        }
        foreach (var item in veriKaydetme.batteryCellDataGun2)
        {
            GameObject yeniSatir = Instantiate(sonucSatirPrefab, contentKutusuGun2);
            ScrollViewSonucRowUI satirKodu = yeniSatir.GetComponent<ScrollViewSonucRowUI>();

            if (satirKodu != null)
            {
                satirKodu.SatiriKur(item.idText.text.ToString(), item.tempText.text.ToString());
            }
        }
        foreach (var item in veriKaydetme.batteryCellDataGun3)
        {
            GameObject yeniSatir = Instantiate(sonucSatirPrefab, contentKutusuGun3);
            ScrollViewSonucRowUI satirKodu = yeniSatir.GetComponent<ScrollViewSonucRowUI>();

            if (satirKodu != null)
            {
                satirKodu.SatiriKur(item.idText.text.ToString(), item.tempText.text.ToString());
            }
        }

        BataryaYoneticisi gercekVeriler = FindAnyObjectByType<BataryaYoneticisi>();
        BataryaDegiskenleri[] hucreler = gercekVeriler.HucreleriGetir();

        foreach (var item in hucreler)
        {
            GercekDegerSonucYazdýr(item);
        }
    }

    void GercekDegerSonucYazdýr(BataryaDegiskenleri item)
    {
        if (item.birinci_sicaklik >= 35)
        {
            GameObject yeniSatir = Instantiate(sonucSatirPrefab, contentKutusuGercekDegerGun1);
            ScrollViewSonucRowUI satirKodu = yeniSatir.GetComponent<ScrollViewSonucRowUI>();
            if (satirKodu != null)
            {
                //SicaklikRenkDegistir(satirKodu);
                satirKodu.SatiriKur(item.cell_id.ToString(), item.birinci_sicaklik.ToString() + " °C");
            }
        }
        if (item.ikinci_sicaklik >= 35)
        {
            GameObject yeniSatir = Instantiate(sonucSatirPrefab, contentKutusuGercekDegerGun2);
            ScrollViewSonucRowUI satirKodu = yeniSatir.GetComponent<ScrollViewSonucRowUI>();
            if (satirKodu != null)
            {
                //SicaklikRenkDegistir(satirKodu);
                satirKodu.SatiriKur(item.cell_id.ToString(), item.ikinci_sicaklik.ToString() + " °C");
            }
        }
        if (item.ucuncu_sicaklik >= 35)
        {
            GameObject yeniSatir = Instantiate(sonucSatirPrefab, contentKutusuGercekDegerGun3);
            ScrollViewSonucRowUI satirKodu = yeniSatir.GetComponent<ScrollViewSonucRowUI>();
            if (satirKodu != null)
            {
                //SicaklikRenkDegistir(satirKodu);
                satirKodu.SatiriKur(item.cell_id.ToString(), item.ucuncu_sicaklik.ToString() + " °C");
            }
        }
    }
    void SicaklikRenkDegistir(ScrollViewSonucRowUI satir)
    {
        Debug.Log(satir.tempText.text);
        if (float.Parse(satir.tempText.text) >= 55f)
            satir.tempText.color = Color.red;
        else if (float.Parse(satir.tempText.text) >= 35f)
            satir.tempText.color = Color.yellow;
    }
}
