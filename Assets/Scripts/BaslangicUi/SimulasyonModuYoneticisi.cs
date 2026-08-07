using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimulasyonModuYoneticisi : MonoBehaviour
{
    public static SimulasyonModu SeciliModu;


    [SerializeField] private Button baslat_butonu;

    [SerializeField] private Toggle egitim_butonu;

    [SerializeField] private Toggle degerlendirme_butonu;



    private void Start()
    {
        baslat_butonu.onClick.AddListener(OyunuBaslat);
    }

    private void OyunuBaslat()
    {
        if (egitim_butonu.isOn)
        {

            SeciliModu = SimulasyonModu.Egitim;
        }
        else
        {
            SeciliModu = SimulasyonModu.Degerlendirme;

        }
        SceneManager.LoadScene("Atölye");
    }

}
