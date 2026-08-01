using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FlirYuvasi : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor flirYuvasi;
    [SerializeField] private GameObject sariAlan;

    private void Start()
    {
        // Oyun başladığında sarı alan görünmesin
        if (sariAlan != null)
            sariAlan.SetActive(false);

        // FLIR alındığında
        flirYuvasi.selectExited.AddListener(FlirAlindi);

        // FLIR yerine bırakıldığında
        flirYuvasi.selectEntered.AddListener(FlirBirakildi);
    }

    private void OnDestroy()
    {
        flirYuvasi.selectExited.RemoveListener(FlirAlindi);
        flirYuvasi.selectEntered.RemoveListener(FlirBirakildi);
    }

    private void FlirAlindi(SelectExitEventArgs olayBilgisi)
    {
        if (sariAlan != null)
            sariAlan.SetActive(true);

        Debug.Log("FLIR alındı.");
    }

    private void FlirBirakildi(SelectEnterEventArgs olayBilgisi)
    {
        if (sariAlan != null)
            sariAlan.SetActive(false);

        Debug.Log("FLIR yerine bırakıldı.");
    }
}