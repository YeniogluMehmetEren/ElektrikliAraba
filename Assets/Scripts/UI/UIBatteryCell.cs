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

    private int hucreID;

    public int GetHucreID() {  return hucreID; }
    public void Setup(int id)
    {
        hucreID = id;
        idText.text = $"#{id:D2}"; // #01, #02 þeklinde gösterir
        tempText.text = "--°C";
        hucreArkaPlan.color = olculmediRenk;
    }
}
