using UnityEngine;

public class RowUretme : MonoBehaviour
{
    [Header("Tablo Ayarlarý")]
    public Transform contentKutusu;
    public GameObject satirPrefab;

    public void YeniOlcumEkle()
    {
        // 1. Content kutusunun içine yeni bir satýr üret
        GameObject yeniSatir = Instantiate(satirPrefab, contentKutusu);

        // 2. Üretilen satýrýn üzerindeki koda ulaþ
        ScrollViewRowUI satirKodu = yeniSatir.GetComponent<ScrollViewRowUI>();

        // 3. Verileri satýra gönder
        if (satirKodu != null)
        {
            satirKodu.SatiriKur();
        }
    }
}
