using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MatkapYuvasi : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor matkap_yuvasi;
    [SerializeField] private GameObject sariAlan;

    private void Start()
    {
        if (sariAlan != null)
            sariAlan.SetActive(false);

        matkap_yuvasi.selectExited.AddListener(MatkapAlindi);

        matkap_yuvasi.selectEntered.AddListener(MatkapBirakildi);
    }

    private void OnDestroy()
    {
        matkap_yuvasi.selectExited.RemoveListener(MatkapAlindi);
        matkap_yuvasi.selectEntered.RemoveListener(MatkapBirakildi);
    }

    private void MatkapAlindi(SelectExitEventArgs args)
    {
        if (sariAlan != null)
            sariAlan.SetActive(true);

    }

    private void MatkapBirakildi(SelectEnterEventArgs args)
    {
        if (sariAlan != null)
            sariAlan.SetActive(false);

    }
}