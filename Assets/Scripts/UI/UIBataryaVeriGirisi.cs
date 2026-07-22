using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBataryaVeriGirisi : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject panelGun1;
    public GameObject panelGun2;
    public GameObject panelGun3;
    public GameObject panelSonuc;

    public void Gun2yeGec()
    {
        panelGun1.SetActive(false);
        panelGun2.SetActive(true);
    }
    public void Gun3eGec()
    {
        panelGun2.SetActive(false);
        panelGun3.SetActive(true);
    }
    public void SonucaGec()
    {
        panelGun3.SetActive(false);
        panelSonuc.SetActive(true);
    }
}
