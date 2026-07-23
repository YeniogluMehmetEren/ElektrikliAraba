using UnityEngine;

public class RowUretme : MonoBehaviour
{
    [Header("Tablo Ayarlarý")]
    public Transform contentKutusu;
    public GameObject satirPrefab;

    public void YeniOlcumEkle()
    {
        GameObject yeniSatir = Instantiate(satirPrefab, contentKutusu);

        ScrollViewRowUI satirKodu = yeniSatir.GetComponent<ScrollViewRowUI>();

        if (satirKodu != null)
        {
            satirKodu.SatiriKur();
        }
    }
}
