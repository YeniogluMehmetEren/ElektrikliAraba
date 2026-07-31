using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FeetTrigger : MonoBehaviour
{
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

        Debug.Log("Koruyucu ayakkabı giyildi.");

        grab.gameObject.SetActive(false);
    }
}