using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WearEquipment : MonoBehaviour
{
    [Header("Target")]
    public Transform chestTarget;

    [Header("Right Hand Model")]
    public Transform handModel;

    [Header("Animation")]
    public float moveTime = 0.25f;

    [Header("Hand Rotation")]
    public Vector3 handRotationOffset = new Vector3(-15f, 10f, 0f);

    private XRGrabInteractable grab;
    private bool used = false;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(OnGrab);
    }

    private void OnDestroy()
    {
        if (grab != null)
            grab.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (used)
            return;

        used = true;

        StartCoroutine(WearRoutine());
    }

    private IEnumerator WearRoutine()
    {
        grab.enabled = false;

        // XR Grab tamamlasın
        yield return null;

        // Önlük ele yapışsın
        transform.SetParent(handModel, true);

        Vector3 apronStartPos = transform.position;
        Quaternion apronStartRot = transform.rotation;

        Quaternion handStartRot = handModel.localRotation;
        Quaternion handTargetRot =
            handStartRot * Quaternion.Euler(handRotationOffset);

        float t = 0f;

        //--------------------------
        // EL DÖNER + ÖNLÜK GİDER
        //--------------------------
        while (t < 1f)
        {
            t += Time.deltaTime / moveTime;

            float lerp = Mathf.SmoothStep(0f, 1f, t);

            handModel.localRotation =
                Quaternion.Slerp(handStartRot, handTargetRot, lerp);

            transform.position =
                Vector3.Lerp(apronStartPos, chestTarget.position, lerp);

            transform.rotation =
                Quaternion.Slerp(apronStartRot, chestTarget.rotation, lerp);

            yield return null;
        }

        yield return new WaitForSeconds(0.05f);

        //--------------------------
        // ÖNLÜK KAYBOLUR
        //--------------------------
        gameObject.SetActive(false);

        //--------------------------
        // EL GERİ DÖNER
        //--------------------------
        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / moveTime;

            float lerp = Mathf.SmoothStep(0f, 1f, t);

            handModel.localRotation =
                Quaternion.Slerp(handTargetRot, handStartRot, lerp);

            yield return null;
        }

        handModel.localRotation = handStartRot;

        Debug.Log("Güvenlik önlüğü giyildi.");
    }
}