using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelSonucUI : MonoBehaviour
{
    public GameObject panel;
    public GameObject sonPanel;
    public TextMeshProUGUI IDgun1;
    public TextMeshProUGUI IDgun2;
    public TextMeshProUGUI IDgun3;
    public TextMeshProUGUI Sicaklikgun1;
    public TextMeshProUGUI Sicaklikgun2;
    public TextMeshProUGUI Sicaklikgun3;

    public int hangiID = 1;

    private List<BatteryCellUI> Gun1Degerleri;
    private List<BatteryCellUI> Gun2Degerleri;
    private List<BatteryCellUI> Gun3Degerleri;
    
    private BataryaDegiskenleri[] karsilastirilacakHucreler;

    void Start()
    {
        UIBataryaVeriGirisi uIBataryaVeriGirisi = FindAnyObjectByType<UIBataryaVeriGirisi>();
        Gun1Degerleri = uIBataryaVeriGirisi.batteryCellDataGun1;
        Gun2Degerleri = uIBataryaVeriGirisi.batteryCellDataGun2;
        Gun3Degerleri = uIBataryaVeriGirisi.batteryCellDataGun3;

        BataryaYoneticisi bataryaYoneticisi = FindAnyObjectByType<BataryaYoneticisi>();
        karsilastirilacakHucreler = bataryaYoneticisi.hucreler;

        IDyeGoreSatirDoldur(hangiID); //Baþladýðý gibi ilk id 1i doldurmuyodu direkt id 1i oldursun diye 
    }

    public void SonrakiIDyeGeç()
    {
        HangiIDArttir();
        if (hangiID > 12)
        {
            sonPanel.SetActive(true);
            panel.SetActive(false);
        }
        else
        {
            IDyeGoreSatirDoldur(hangiID);
        } 
    }

    public void IDyeGoreSatirDoldur(int ID)
    {
        foreach (var item in Gun1Degerleri)
        {
            if (item.hucreID == hangiID)
            {
                IDgun1.text = item.idText.text;
                Sicaklikgun1.text = item.tempText.text;
            }
        }
        foreach (var item in Gun2Degerleri)
        {
            if (item.hucreID == hangiID)
            {
                IDgun2.text = item.idText.text;
                Sicaklikgun2.text = item.tempText.text;
            }
        }
        foreach (var item in Gun3Degerleri)
        {
            if (item.hucreID == hangiID)
            {
                IDgun3.text = item.idText.text;
                Sicaklikgun3.text = item.tempText.text;
            }
        }
    }

    public void HangiIDArttir() { hangiID++; }


    public void BtnNormalBasildi()
    {
        SetHucreDurumu(HucreDurumu.Normal);
        SonrakiIDyeGeç();
    }
    public void BtnUyariBasildi()
    {
        SetHucreDurumu(HucreDurumu.Uyarý);
        SonrakiIDyeGeç();
    }
    public void BtnKritikBasildi()
    {
        SetHucreDurumu(HucreDurumu.Kritik);
        SonrakiIDyeGeç();
    }

    void SetHucreDurumu(HucreDurumu durum)  
    {
        foreach (var item in karsilastirilacakHucreler)
        {
            if (item.cell_id == hangiID)
            {
                item.secilen_hucre_durumu = durum;
                Debug.Log("ID : " + item.cell_id + " / Durum : " + item.hucre_durumu + " / Atanan Durum : " + durum);
            }
        }
    }
}