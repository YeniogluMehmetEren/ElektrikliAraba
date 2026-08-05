using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class NesneTutmaSesi : MonoBehaviour
{
    public AudioSource sesKaynagi;
    public AudioClip tutmaSesi;

    private XRGrabInteractable xrGrabInteractable;

    private void Awake()
    {
        xrGrabInteractable = GetComponent<XRGrabInteractable>();

        if (xrGrabInteractable != null)
        {
            xrGrabInteractable.selectEntered.AddListener(OnlukTutuldu);
        }
    }

    private void OnlukTutuldu(SelectEnterEventArgs args)
    {
        if (sesKaynagi != null && tutmaSesi != null)
        {
            sesKaynagi.PlayOneShot(tutmaSesi);
        }
    }

    private void OnDestroy()
    {
        if (xrGrabInteractable != null)
        {
            xrGrabInteractable.selectEntered.RemoveListener(OnlukTutuldu);
        }
    }
}