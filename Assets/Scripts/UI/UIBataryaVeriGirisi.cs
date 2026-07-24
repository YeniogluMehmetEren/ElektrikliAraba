using System.Collections.Generic;
using UnityEngine;

public class UIBataryaVeriGirisi : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject panelGun1;
    public GameObject panelGun2;
    public GameObject panelGun3;
    public GameObject panelSonuc;
 
    public List<BatteryCellUI> batteryCellDataGun1 = new List<BatteryCellUI>();
    public List<BatteryCellUI> batteryCellDataGun2 = new List<BatteryCellUI>();
    public List<BatteryCellUI> batteryCellDataGun3 = new List<BatteryCellUI>();

    private int gun = 1; 
    public void Gun2yeGec()
    {
        panelGun1.SetActive(false);
        panelGun2.SetActive(true);
        gun = 2;
    }
    public void Gun3eGec()
    {
        panelGun2.SetActive(false);
        panelGun3.SetActive(true);
        gun = 3;
    }
    public void SonucaGec()
    {
        panelGun3.SetActive(false);
        panelSonuc.SetActive(true);
    }

    public void AddBatteryData(BatteryCellUI batteryData)
    {
        if (gun == 1)
        {
            if (!batteryCellDataGun1.Contains(batteryData))
            {
                batteryCellDataGun1.Add(batteryData);
            }
        }
        else if (gun == 2)
        {
            if (!batteryCellDataGun2.Contains(batteryData))
            {
                batteryCellDataGun2.Add(batteryData);
            }
        }
        if (gun == 3)
        {
            if (!batteryCellDataGun3.Contains(batteryData))
            {
                batteryCellDataGun3.Add(batteryData);
            }
        }
        
    }
    public void DeleteBatteryData(BatteryCellUI batteryData)
    {
        if (gun == 1)
        {
            if (batteryCellDataGun1.Contains(batteryData))
            {
                batteryCellDataGun1.Remove(batteryData);
            }
        }
        if (gun == 2)
        {
            if (batteryCellDataGun2.Contains(batteryData))
            {
                batteryCellDataGun2.Remove(batteryData);
            }
        }
        if (gun == 3)
        {
            if (batteryCellDataGun3.Contains(batteryData))
            {
                batteryCellDataGun3.Remove(batteryData);
            }
        }
        
        
    }
}
