using System.Linq;
using UnityEngine;

public class TermalHucrelerRenkYonetici : MonoBehaviour
{
    [SerializeField]
    private BataryaYoneticisi bataryaYoneticisi;

    private MeshRenderer[] termalHucreRenkMetarial;

    private BataryaDegiskenleri[] hucreler;

    private void Awake()
    {
        TermalHucreleriHazirla();
        CellHucreleriBul();
    }

    private void Start()
    {
        TermalHucreRenkleriniGuncelle();
    }
    private void TermalHucreleriHazirla()
    {
        termalHucreRenkMetarial = GetComponentsInChildren<MeshRenderer>();

        termalHucreRenkMetarial = termalHucreRenkMetarial
            .Where(h => h.gameObject.name.StartsWith("T_Cube"))
            .OrderBy(h => h.gameObject.name)
            .ToArray();
    }

    private void CellHucreleriBul()
    {
        hucreler = bataryaYoneticisi.HucreleriGetir();
    }

    public void TermalHucreRenkleriniGuncelle()
    {
        for (int i = 0; i < hucreler.Length; i++)
        {
            Color renk = HucreRenginiHesapla(hucreler[i].mevcut_sicaklik);

            termalHucreRenkMetarial[i].material.color = renk;
        }
    }

    private Color HucreRenginiHesapla(float sicaklik)
    {
        if (sicaklik >= SicaklikDurumHesaplayici.min_normal_sicaklik &&
            sicaklik <= SicaklikDurumHesaplayici.max_normal_sicaklik)
        {
            return Color.green;
        }

        if (sicaklik >= SicaklikDurumHesaplayici.min_uyari_sicaklik &&
            sicaklik <= SicaklikDurumHesaplayici.max_uyari_sicaklik)
        {
            return Color.yellow;
        }

        return Color.red;
    }



}

