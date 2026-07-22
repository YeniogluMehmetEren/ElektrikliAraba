using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class FLIRKontrol : MonoBehaviour
{
    
    [SerializeField] private Camera normalKamera;

    [SerializeField] private Camera termalKamera;

    [SerializeField] private TMP_Text modYazisi;


    [SerializeField] private TermalBilgiOkuyucu termalBilgiOkuyucu;

    private bool termalModAktif = false;

    public bool TermalModAktifMi => termalModAktif;

    private void Start()
    {
        normalKamera.enabled = true;
        termalKamera.enabled = false;

        modYazisi.text = "MOD : NORMAL";

        if (termalBilgiOkuyucu != null)
        {
            termalBilgiOkuyucu.enabled = false;
        }

        Debug.Log("NORMAL MOD");
    }

    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            ModDegistir();
        }
    }

    private void ModDegistir()
    {
        termalModAktif = !termalModAktif;

        if (termalModAktif)
        {
            normalKamera.enabled = false;
            termalKamera.enabled = true;

            modYazisi.text = "MOD : TERMAL";

            if (termalBilgiOkuyucu != null)
            {
                termalBilgiOkuyucu.enabled = true;
            }

            Debug.Log("TERMAL MOD");
        }
        else
        {
            normalKamera.enabled = true;
            termalKamera.enabled = false;

            modYazisi.text = "MOD : NORMAL";

            if (termalBilgiOkuyucu != null)
            {
                termalBilgiOkuyucu.enabled = false;
            }

            Debug.Log("NORMAL MOD");
        }
    }
}