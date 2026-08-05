using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GloveWear : MonoBehaviour
{
    public AudioSource ses_kaynagı;
    public AudioClip giyme_sesi;

    [Header("Hand Meshes")]
    public SkinnedMeshRenderer leftHand;
    public SkinnedMeshRenderer rightHand;

    [Header("Glove Material")]
    public Material gloveMaterial;

    private bool equipped = false;
    public bool eldivenGiyildiMi = false;

    private void OnTriggerEnter(Collider other)
    {
        if (equipped)
            return;

        XRGrabInteractable grab =
            other.GetComponentInParent<XRGrabInteractable>();

        if (grab == null)
            return;

        if (!grab.CompareTag("Glove"))
            return;

        if (!grab.isSelected)
            return;

        equipped = true;
        eldivenGiyildiMi = true;

        leftHand.material = gloveMaterial;
        rightHand.material = gloveMaterial;

        StartCoroutine(EldiveniGiy(grab));
    }

    private IEnumerator EldiveniGiy(XRGrabInteractable grab)
    {
        if (ses_kaynagı != null && giyme_sesi != null)
        {
            ses_kaynagı.PlayOneShot(giyme_sesi);
            yield return new WaitForSeconds(giyme_sesi.length);
        }

        grab.gameObject.SetActive(false);
    }
}