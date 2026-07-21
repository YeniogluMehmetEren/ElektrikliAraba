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
    [SerializeField] private ThermalRaycaster thermalRaycaster;

    private bool thermalMode = false;

    public bool IsThermalMode => thermalMode;

    private void Start()
    {
        // Kameralar
        normalCamera.enabled = true;
        thermalCamera.enabled = false;

        // Yazı
        modeText.text = "MODE : NORMAL";

        // Thermal sistemi kapalı başlasın
        if (thermalRaycaster != null)
            thermalRaycaster.enabled = false;

        Debug.Log("NORMAL MODE");
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
            // Thermal Mode
            normalCamera.enabled = false;
            thermalCamera.enabled = true;

            modeText.text = "MODE : THERMAL";

            if (thermalRaycaster != null)
                thermalRaycaster.enabled = true;

            Debug.Log("THERMAL MODE");
        }
        else
        {
            // Normal Mode
            normalCamera.enabled = true;
            thermalCamera.enabled = false;

            modeText.text = "MODE : NORMAL";

            if (thermalRaycaster != null)
                thermalRaycaster.enabled = false;

            Debug.Log("NORMAL MODE");
        }
    }
}