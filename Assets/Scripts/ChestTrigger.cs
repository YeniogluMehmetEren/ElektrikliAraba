using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ChestTrigger : MonoBehaviour
{
    public bool giysiGiyildiMi = false;

    public AudioSource ses_kaynagı;
    public AudioClip giyme_sesi;

    private void OnTriggerEnter(Collider other)
    {
        XRGrabInteractable grab =
            other.GetComponentInParent<XRGrabInteractable>();

        if (grab == null)
            return;

        if (!grab.CompareTag("Apron"))
            return;

        if (!grab.isSelected)
            return;

        giysiGiyildiMi = true;

        StartCoroutine(Giydir(grab));
    }

    private IEnumerator Giydir(XRGrabInteractable grab)
    {
        ses_kaynagı.PlayOneShot(giyme_sesi);

        yield return new WaitForSeconds(giyme_sesi.length);

        grab.gameObject.SetActive(false);
    }
}