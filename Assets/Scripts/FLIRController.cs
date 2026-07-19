using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class FLIRController : MonoBehaviour
{
    public Camera normalCamera;
    public Camera thermalCamera;

    public TMP_Text modeText;

    private bool thermalMode = false;

    void Start()
    {
        normalCamera.enabled = true;
        thermalCamera.enabled = false;

        modeText.text = "MODE : NORMAL";

        Debug.Log("NORMAL MODE");
    }

    void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            ToggleMode();
        }
    }

    void ToggleMode()
    {
        thermalMode = !thermalMode;

        if (thermalMode)
        {
            normalCamera.enabled = false;
            thermalCamera.enabled = true;

            modeText.text = "MODE : THERMAL";

            Debug.Log("THERMAL MODE");
        }
        else
        {
            normalCamera.enabled = true;
            thermalCamera.enabled = false;

            modeText.text = "MODE : NORMAL";

            Debug.Log("NORMAL MODE");
        }
    }
}