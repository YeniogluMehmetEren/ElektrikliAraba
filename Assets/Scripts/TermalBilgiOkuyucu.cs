using TMPro;
using UnityEngine;

public class TermalBilgiOkuyucu : MonoBehaviour
{

    [SerializeField] 
    private Transform firePoint;

    [SerializeField] 
    private TMP_Text ekranBilgiText;

    [SerializeField] 
    private LineRenderer isin;

    [SerializeField] 
    private float maxIsinMesafe = 3f;




    private void OnEnable()
    {
        if (isin != null)
        {
            isin.enabled = false;
        }

        if (ekranBilgiText != null)
        {
            ekranBilgiText.text = string.Empty;
        }
    }

    private void OnDisable()
    {
        if (isin != null)
        {
            isin.enabled = false;
        }

        if (ekranBilgiText != null)
        {
            ekranBilgiText.text = string.Empty;
        }
    }

    private void Update()
    {
        Ray ray = new Ray(firePoint.position, firePoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxIsinMesafe))
        {
            isin.enabled = true;

            isin.SetPosition(0, firePoint.position);
            isin.SetPosition(1, hit.point);

            BataryaDegiskenleri hucre =
                hit.collider.GetComponent<BataryaDegiskenleri>();

            if (hucre != null)
            {
                BilgiyiGoster(hucre);
            }
            else
            {
                BilgiyiTemizle();
            }
        }
        else
        {
            if (isin != null)
                isin.enabled = false;

            BilgiyiTemizle();
        }
    }

    private void BilgiyiGoster(BataryaDegiskenleri hucre)
    {
        ekranBilgiText.text =
                                $"CELL {hucre.cell_id}\n\n" +
                                $"{hucre.mevcut_sicaklik:0.0}°C\n\n" +
                                $"{hucre.hucre_durumu}";
    }

    private void BilgiyiTemizle()
    {
        ekranBilgiText.text = string.Empty;
    }


}
