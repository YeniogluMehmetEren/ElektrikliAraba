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

        int[] IDSýrasý = { 1, 3, 5, 7, 9, 11, 2, 4, 6, 8, 10, 12};
        for (int i = 0; i < toplamHucre; i++)
        {
            GameObject yeniHucre = Instantiate(hucrePrefab, gridContainer);
            BatteryCellUI cellScript = yeniHucre.GetComponent<BatteryCellUI>();

            int hucreID = IDSýrasý[i]; 
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
                hucre.tempText.text = sicaklik + " °C";

                if (sicaklik != "Bilinmiyor" && sicaklik != "Bilinmiyor °C")
                {
                    if (float.Parse(sicaklik) >= 55f)
                        hucre.hucreArkaPlan.color = hucre.kritikRenk;
                    else if (float.Parse(sicaklik) >= 35f)
                        hucre.hucreArkaPlan.color = hucre.uyariRenk;
                    else
                        hucre.hucreArkaPlan.color = hucre.normalRenk;
                }
                else
                {
                    hucre.hucreArkaPlan.color = hucre.olculmediRenk;
                }
            }
        }
        
    }

    public void IDBulSicaklikSýfýrla(int id, string sicaklik)
    {
        foreach (var hucre in hucreListesi)
        {
            if (id == hucre.GetHucreID())
            {
                hucre.tempText.text = "Bilinmiyor °C";
                hucre.hucreArkaPlan.color = hucre.olculmediRenk;
                
            }
        }
    }
}
