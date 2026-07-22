using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatteryGridManager : MonoBehaviour
{
    [Header("Atamalar")]
    public Transform gridContainer; // Grid Layout Group olan panel
    public GameObject hucrePrefab;  // Hazýrladýðýmýz CellUI Prefab'i

    private List<BatteryCellUI> hucreListesi = new List<BatteryCellUI>();

    private void Start()
    {
        SemaOlustur(12);
    }

    void SemaOlustur(int toplamHucre)
    {
        foreach (Transform child in gridContainer)
        {
            Destroy(child.gameObject);
        }
        hucreListesi.Clear();

        for (int i = 0; i < toplamHucre; i++)
        {
            GameObject yeniHucre = Instantiate(hucrePrefab, gridContainer);
            BatteryCellUI cellScript = yeniHucre.GetComponent<BatteryCellUI>();

            int hucreID = i + 1; // 1'den 12'ye kadar ID
            cellScript.Setup(hucreID);

            hucreListesi.Add(cellScript);
        }
    }

    public void IDBulSicaklikGuncelle(int id, string sicaklik)
    {
        foreach (var hucre in hucreListesi)
        {
            if (id == hucre.GetHucreID())
            {
                hucre.tempText.text = sicaklik;

                if (sicaklik != "Bilinmiyor °C")
                {
                    if (float.Parse(sicaklik) >= 55f)
                        hucre.hucreArkaPlan.color = hucre.kritikRenk;
                    else if (float.Parse(sicaklik) >= 35f)
                        hucre.hucreArkaPlan.color = hucre.uyariRenk;
                    else
                        hucre.hucreArkaPlan.color = hucre.normalRenk;
                }
            }
        }
        
    }
}
