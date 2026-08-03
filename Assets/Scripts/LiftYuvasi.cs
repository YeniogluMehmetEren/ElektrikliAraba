using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LiftYuvasi : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor lift_yuvasi;
    [SerializeField] private GameObject sari_alan;

    public bool liftAlandaMi = false;

    private void Start()
    {
        if (sari_alan != null)
            sari_alan.SetActive(true);

        lift_yuvasi.selectExited.AddListener(LiftAlindi);
        lift_yuvasi.selectEntered.AddListener(LiftBirakildi);
    }

    private void OnDestroy()
    {
        if (lift_yuvasi != null)
        {
            lift_yuvasi.selectExited.RemoveListener(LiftAlindi);
            lift_yuvasi.selectEntered.RemoveListener(LiftBirakildi);
        }
    }

    public void GoreviBaslat()
    {
        if (sari_alan != null)
            sari_alan.SetActive(true);
    }

    private void LiftAlindi(SelectExitEventArgs args)
    {
        if (sari_alan != null)
            sari_alan.SetActive(true);
    }

    private void LiftBirakildi(SelectEnterEventArgs args)
    {
        if (sari_alan != null)
        {
            sari_alan.SetActive(false);
            liftAlandaMi = true;
        }
    }
}