using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BatteryCellUI : MonoBehaviour
{
    [Header("UI Elemanlarý")]
    public RawImage hucreArkaPlan;
    public TextMeshProUGUI idText;
    public TextMeshProUGUI tempText;

    [Header("Renk Paleti")]
    public Color normalRenk = Color.green;
    public Color uyariRenk = Color.yellow;
    public Color kritikRenk = Color.red;
    public Color olculmediRenk = Color.gray;

    public int hucreID;
    public string hucreDurum;

    public int GetHucreID() {  return hucreID; }
    public void Setup(int id)
    {
        hucreID = id;
        idText.text = $"{id:D2}";
        tempText.text = "Bilinmiyor °C";
        hucreArkaPlan.color = olculmediRenk;
    }
}
