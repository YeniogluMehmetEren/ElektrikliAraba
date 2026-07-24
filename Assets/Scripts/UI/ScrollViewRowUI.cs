using System;
using TMPro;
using UnityEditor;
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

    private int ID;
    private string sicaklik;
    private int eskiID = 1;

    private void Start()
    {
        tempButton.onClick.AddListener(ManualVeriGirisiDinleme);
    }

    private void Update()
    {
        BatteryGridManager gridManager = FindAnyObjectByType<BatteryGridManager>();
        UIBataryaVeriGirisi veriKaydetme = FindAnyObjectByType<UIBataryaVeriGirisi>();

        if (idDropdown.text != "Hücre Seç")
        {
            if (eskiID == Convert.ToInt32(idDropdown.text))
            {
                BatteryCellUIGonderme(Convert.ToInt32(idDropdown.text), tempText.text);
                BatteryCellUI yeniHucre = gridManager.IDdenHucreBulma(Convert.ToInt32(idDropdown.text)); veriKaydetme.AddBatteryData(yeniHucre);
            }
            else
            {
                BatteryCellUIGonderme(Convert.ToInt32(idDropdown.text), tempText.text);
                BatteryCellUI yeniHucre = gridManager.IDdenHucreBulma(Convert.ToInt32(idDropdown.text)); veriKaydetme.AddBatteryData(yeniHucre);
                BatteryCellUIGonderme(eskiID, "Bilinmiyor");
                BatteryCellUI eskiHucre = gridManager.IDdenHucreBulma(eskiID); veriKaydetme.DeleteBatteryData(eskiHucre);
                eskiID = Convert.ToInt32(idDropdown.text);
            }
        }
    }

    public void SatiriKur()
    {
        tempText.text = "Bilinmiyor";
    }

    public void SatiriSil()
    {
        BatteryGridManager kod = FindAnyObjectByType<BatteryGridManager>();
        if (kod != null)
        {
            kod.IDBulSicaklikSýfýrla(ID, this.sicaklik);
        }
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
            ID = id;
            this.sicaklik = sicaklik;
            kod.IDBulSicaklikGuncelle(id, sicaklik);
        }
    }
}
