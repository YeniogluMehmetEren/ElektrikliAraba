using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FLIRKontrol : MonoBehaviour
{
    [SerializeField] private Camera normalKamera;
    [SerializeField] private Camera termalKamera;
    [SerializeField] private TMP_Text modYazisi;

    [SerializeField] private TermalBilgiOkuyucu termalBilgiOkuyucu;

    private bool termalModAktif = false;

    public bool TermalModAktifMi => termalModAktif;

    private bool konsolOncekiDurum = false;

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


        if (Keyboard.current != null &&
            Keyboard.current.tKey.wasPressedThisFrame)
        {
            ModDegistir();
        }

        UnityEngine.XR.InputDevice solKumanda =
            UnityEngine.XR.InputDevices.GetDeviceAtXRNode(
                UnityEngine.XR.XRNode.LeftHand
            );

        if (solKumanda.isValid)
        {
            bool konsolXbasıldımı = false;

            if (solKumanda.TryGetFeatureValue(
                UnityEngine.XR.CommonUsages.primaryButton,
                out konsolXbasıldımı))
            {
                if (konsolXbasıldımı && !konsolOncekiDurum)
                {
                    ModDegistir();
                }

                konsolOncekiDurum = konsolXbasıldımı;
            }
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