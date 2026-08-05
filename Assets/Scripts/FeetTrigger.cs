using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FeetTrigger : MonoBehaviour
{
    public AudioSource ses_kaynagi;
    public AudioClip giyme_sesi;

    private bool equipped = false;
    public bool ayakkabiGiyildiMi = false;

    private void OnTriggerEnter(Collider other)
    {
        if (equipped)
            return;

        XRGrabInteractable grab =
            other.GetComponentInParent<XRGrabInteractable>();

        if (grab == null)
            return;

        if (!grab.CompareTag("Shoes"))
            return;

        if (!grab.isSelected)
            return;

        equipped = true;
        ayakkabiGiyildiMi = true;

        StartCoroutine(AyakkabiyiGiy(grab));
    }

    private IEnumerator AyakkabiyiGiy(XRGrabInteractable grab)
    {
        if (ses_kaynagi != null && giyme_sesi != null)
        {
            ses_kaynagi.PlayOneShot(giyme_sesi);
            yield return new WaitForSeconds(giyme_sesi.length);
        }

        grab.gameObject.SetActive(false);
    }
}