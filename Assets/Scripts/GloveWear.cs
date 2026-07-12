using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GloveWear : MonoBehaviour
{
    [Header("Hand Meshes")]
    public SkinnedMeshRenderer leftHand;
    public SkinnedMeshRenderer rightHand;

    [Header("Glove Material")]
    public Material gloveMaterial;

    private bool equipped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (equipped)
            return;

        // Eldivenin XR Grab'ını bul
        XRGrabInteractable grab =
            other.GetComponentInParent<XRGrabInteractable>();

        if (grab == null)
            return;

        // Eldiven mi?
        if (!grab.CompareTag("Glove"))
            return;

        // Kullanıcı gerçekten tutuyor mu?
        if (!grab.isSelected)
            return;

        equipped = true;

        // İki ele de eldiven materyalini uygula
        leftHand.material = gloveMaterial;
        rightHand.material = gloveMaterial;

        // Tutulan eldiveni yok et
        grab.gameObject.SetActive(false);

        Debug.Log("Koruyucu eldiven giyildi.");
    }
}