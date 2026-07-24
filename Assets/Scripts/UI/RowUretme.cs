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
    }
}
