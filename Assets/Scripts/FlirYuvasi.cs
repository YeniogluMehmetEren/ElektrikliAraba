using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FlirYuvasi : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor flir_yuvasi;
    [SerializeField] private GameObject sari_alan;

    private void Start()
    {
        if (sari_alan != null)
            sari_alan.SetActive(false);

        flir_yuvasi.selectExited.AddListener(FlirAlindi);

        flir_yuvasi.selectEntered.AddListener(FlirBirakildi);
    }

    private void OnDestroy()
    {
        flir_yuvasi.selectExited.RemoveListener(FlirAlindi);
        flir_yuvasi.selectEntered.RemoveListener(FlirBirakildi);
    }

    private void FlirAlindi(SelectExitEventArgs olayBilgisi)
    {
        if (sari_alan != null)
            sari_alan.SetActive(true);

    }

    private void FlirBirakildi(SelectEnterEventArgs olayBilgisi)
    {
        if (sari_alan != null)
            sari_alan.SetActive(false);

    }
}