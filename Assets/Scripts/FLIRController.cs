using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FLIRController : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private Camera normalCamera;
    [SerializeField] private Camera thermalCamera;

    [Header("UI")]
    [SerializeField] private TMP_Text modeText;

    [Header("Systems")]
    [SerializeField] private TermalBilgiOkuyucu termalBilgiOkuyucu;

    private bool thermalMode = false;

    public bool IsThermalMode => thermalMode;

    public bool termalTutulduMu = false;

    private void Start()
    {
        normalCamera.enabled = true;
        thermalCamera.enabled = false;

        modeText.text = "MODE : NORMAL";

        if (termalBilgiOkuyucu != null)
        {
            termalBilgiOkuyucu.IsiniKapat();
            termalBilgiOkuyucu.enabled = false;
        }

    }

    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            ToggleMode();
        }
    }

    private void ToggleMode()
    {
        thermalMode = !thermalMode;

        if (thermalMode)
        {
            normalCamera.enabled = false;
            thermalCamera.enabled = true;

            modeText.text = "MODE : THERMAL";

            if (termalBilgiOkuyucu != null)
                termalBilgiOkuyucu.enabled = true;

        }
        else
        {
            normalCamera.enabled = true;
            thermalCamera.enabled = false;

            modeText.text = "MODE : NORMAL";

            if (termalBilgiOkuyucu != null)
                termalBilgiOkuyucu.enabled = false;

        }
    }

    public void TermalTutuldu(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor)
        {
            return;
        }
        termalTutulduMu = true;

        thermalMode = false;

        normalCamera.enabled = true;
        thermalCamera.enabled = false;

        modeText.text = "MODE : NORMAL";

        if (termalBilgiOkuyucu != null)
        {
            termalBilgiOkuyucu.enabled = false;
            termalBilgiOkuyucu.IsiniKapat();
        }
    }
}