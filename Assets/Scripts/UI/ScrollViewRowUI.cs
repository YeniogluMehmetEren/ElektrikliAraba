using System;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewRowUI : MonoBehaviour
{
    [Header("Satýr Elemanlarý")]
    public TextMeshProUGUI idDropdown;
    public Button tempButton;
    public TextMeshProUGUI tempText;
    public Button silButonu;

    private void Start()
    {
        tempButton.onClick.AddListener(ManualVeriGirisiDinleme);
    }

    private void Update()
    {
        BatteryCellUIGonderme(Convert.ToInt32(idDropdown.text), tempText.text);
    }

    public void SatiriKur()
    {
        tempText.text = "Bilinmiyor °C";

        /*if (sicaklik < 35)
        {
            tempText.color = Color.green;
        }
        else if (sicaklik < 55)
        {
            tempText.color = Color.yellow;
        }
        else if (sicaklik <= 70)
        {
            tempText.color = Color.red;
        }*/
    }

    public void SatiriSil()
    {
        Destroy(gameObject);
    }

    public void ManualVeriGirisiDinleme()
    {
        ManualVeriGirisiUI kod = FindAnyObjectByType<ManualVeriGirisiUI>();

        if (kod != null)
        {
            kod.NumpadPaneliniAcKapa();
            if (!kod.NumpadPaneliAcikMi())
            {
                tempText.text = kod.GirilenSýcaklýðýSatýraYolla();
            }
        }
        else
        {
            Debug.Log("Kod NULLmuþ");
        }
    }

    public void BatteryCellUIGonderme(int id, string sicaklik)
    {
        BatteryGridManager kod = FindAnyObjectByType<BatteryGridManager>();

        if (kod != null)
        {
            kod.IDBulSicaklikGuncelle(id, sicaklik);
        }
    }
}
