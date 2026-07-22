using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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
}