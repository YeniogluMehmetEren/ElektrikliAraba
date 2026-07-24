using System;
using TMPro;
using UnityEngine;

public class ScrollViewSonucRowUI : MonoBehaviour
{
    [Header("Satýr Elemanlarý")]
    public TextMeshProUGUI idText;
    public TextMeshProUGUI tempText;

    public void SatiriKur(string id, string sicaklik)
    {
        idText.text = id;
        tempText.text = sicaklik;
    }
}
