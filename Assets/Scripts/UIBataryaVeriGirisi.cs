using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBataryaVeriGirisi : MonoBehaviour
{
    [Header("Deðerler")]
    public int gun1Degeri;
    public int gun2Degeri;
    public int gun3Degeri;

    [Header("Panel Gün 1")]
    public GameObject panelGun1;
    public Slider slider1;
    public TextMeshProUGUI dispDegree1;
    [Header("Panel Gün 2")]
    public GameObject panelGun2;
    public Slider slider2;
    public TextMeshProUGUI dispDegree2;
    [Header("Panel Gün 3")]
    public GameObject panelGun3;
    public Slider slider3;
    public TextMeshProUGUI dispDegree3;
    [Header("Sonuç Paneli")]
    public GameObject panelSonuc;

    public void OnValueChanged()
    {
        if (panelGun1.activeInHierarchy)
        {
            if (slider1.value < 35)
            {
                dispDegree1.text = slider1.value.ToString() + " Normal";
                dispDegree1.color = Color.green;
            }
            else if (slider1.value < 55)
            {
                dispDegree1.text = slider1.value.ToString() + " Uyarý";
                dispDegree1.color = Color.yellow;
            }
            else if (slider1.value <= 70)
            {
                dispDegree1.text = slider1.value.ToString() + " Kritik";
                dispDegree1.color = Color.red;
            }
        }
        else if (panelGun2.activeInHierarchy)
        {
            if (slider2.value < 35)
            {
                dispDegree2.text = slider2.value.ToString() + " Normal";
                dispDegree2.color = Color.green;
            }
            else if (slider2.value < 55)
            {
                dispDegree2.text = slider2.value.ToString() + " Uyarý";
                dispDegree2.color = Color.yellow;
            }
            else if (slider2.value <= 70)
            {
                dispDegree2.text = slider2.value.ToString() + " Kritik";
                dispDegree2.color = Color.red;
            }
        }
        else if (panelGun3.activeInHierarchy)
        {
            if (slider3.value < 35)
            {
                dispDegree3.text = slider3.value.ToString() + " Normal";
                dispDegree3.color = Color.green;
            }
            else if (slider3.value < 55)
            {
                dispDegree3.text = slider3.value.ToString() + " Uyarý";
                dispDegree3.color = Color.yellow;
            }
            else if (slider3.value <= 70)
            {
                dispDegree3.text = slider3.value.ToString() + " Kritik";
                dispDegree3.color = Color.red;
            }
        }
    }



    public void Gun2yeGec()
    {
        gun1Degeri = Convert.ToInt32(slider1.value);
        panelGun1.SetActive(false);
        panelGun2.SetActive(true);
    }
    public void Gun3eGec()
    {
        gun2Degeri = Convert.ToInt32(slider2.value);
        panelGun2.SetActive(false);
        panelGun3.SetActive(true);
    }
    public void SonucaGec()
    {
        gun3Degeri = Convert.ToInt32(slider3.value);
        panelGun3.SetActive(false);
        panelSonuc.SetActive(true);
    }
}
