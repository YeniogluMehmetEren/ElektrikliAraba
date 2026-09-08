using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LiftYuvasi : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor lift_yuvasi;
    [SerializeField] private GameObject sari_alan;

    public event Action kücük_lift_sokete_girdi;
    public bool liftAlandaMi = false;

    private void Start()
    {
        if (lift_yuvasi == null)
        {
            return;
        }

        if (sari_alan != null)
            sari_alan.SetActive(false);

        lift_yuvasi.selectExited.AddListener(LiftSockettenAlindi);
        lift_yuvasi.selectEntered.AddListener(LiftSocketeBirakildi);

        if (lift_yuvasi.hasSelection)
        {
            liftAlandaMi = true;
            SariAlaniKapat();
        }
        else
        {
            liftAlandaMi = false;
        }
    }
    private void OnDestroy()
    {
        if (lift_yuvasi != null)
        {
            lift_yuvasi.selectExited.RemoveListener(LiftSockettenAlindi);
            lift_yuvasi.selectEntered.RemoveListener(LiftSocketeBirakildi);
        }
    }

    public void GoreviBaslat()
    {
        if (lift_yuvasi == null)
            return;

        if (lift_yuvasi.hasSelection)
        {
            liftAlandaMi = true;
            SariAlaniKapat();
        }
        else
        {
            liftAlandaMi = false;
            SariAlaniAc();
        }
    }

    public void LiftTutuldu(SelectEnterEventArgs args)
    {

        if (args.interactorObject is XRSocketInteractor)
        {
            return;
        }

        liftAlandaMi = false;

        SariAlaniAc();
    }

    public void LiftEldenBirakildi(SelectExitEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor)
        {
            return;
        }
        SariAlaniKapat();
    }

    private void LiftSockettenAlindi(SelectExitEventArgs args)
    {
        liftAlandaMi = false;
        SariAlaniAc();
    }


    private void LiftSocketeBirakildi(SelectEnterEventArgs args)
    {
        liftAlandaMi = true;

        SariAlaniKapat();
        kücük_lift_sokete_girdi?.Invoke();
    }
    private void SariAlaniAc()
    {
        if (sari_alan != null)
            sari_alan.SetActive(true);
    }
    private void SariAlaniKapat()
    {
        if (sari_alan != null)
            sari_alan.SetActive(false);
    }
}