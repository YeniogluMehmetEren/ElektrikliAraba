using System.Collections;
using UnityEngine;

public class NesneGorevVurgulama : MonoBehaviour
{
    private Outline nesne_sari_renk;
    private Coroutine yanip_sonme_rutini;

    [Header("Yanıp Sönme Ayarları")]
    [SerializeField] private float bekleme_suresi = 0.5f;

    private void Awake()
    {
        nesne_sari_renk = GetComponent<Outline>();

        if (nesne_sari_renk != null)
        {
            nesne_sari_renk.enabled = false; 
        }
    }

    public void GorevBasladi()
    {
        if (nesne_sari_renk == null)
            return;

        if (yanip_sonme_rutini == null)
        {
            yanip_sonme_rutini = StartCoroutine(YanipSon());
        }
    }

    public void GorevBitti()
    {
        if (nesne_sari_renk == null)
            return;

        if (yanip_sonme_rutini != null)
        {
            StopCoroutine(yanip_sonme_rutini);
            yanip_sonme_rutini = null;
        }

        nesne_sari_renk.enabled = false;
    }

    private IEnumerator YanipSon()
    {
        while (true)
        {
            nesne_sari_renk.enabled = true;
            yield return new WaitForSeconds(bekleme_suresi);

            nesne_sari_renk.enabled = false;
            yield return new WaitForSeconds(bekleme_suresi);
        }
    }
}