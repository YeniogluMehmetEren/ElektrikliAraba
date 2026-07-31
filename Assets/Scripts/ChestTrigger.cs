using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ChestTrigger : MonoBehaviour
{
    public bool giysiGiyildiMi = false;
    private void OnTriggerEnter(Collider other)
    {
        XRGrabInteractable grab =
            other.GetComponentInParent<XRGrabInteractable>();

        if (grab == null)
            return;

        // Önlük mü?
        if (!grab.CompareTag("Apron"))
            return;

        // Elde tutuluyor mu?
        if (!grab.isSelected)
            return;

        Debug.Log("Güvenlik önlüğü giyildi.");

        giysiGiyildiMi = true;
        grab.gameObject.SetActive(false);
    }
}