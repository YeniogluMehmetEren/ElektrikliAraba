using UnityEngine;

public class LiftTemasKontrol : MonoBehaviour
{
    [SerializeField] private LiftAnimationController liftController;

    public bool Bataryaya_temas_ediyormu => bataryaya_temas_ediyormu;

    private bool bataryaya_temas_ediyormu = false;

    private void OnTriggerStay(Collider liftCollider)
    {
        if (!bataryaya_temas_ediyormu && liftCollider.CompareTag("Lift"))
        {
            bataryaya_temas_ediyormu = true;

            Debug.Log("Lift bataryaya temas etti.");

            if (liftController != null)
            {
                liftController.HareketiDurdur();
            }
        }
    }

    private void OnTriggerExit(Collider liftCollider)
    {
        if (liftCollider.CompareTag("Lift"))
        {
            bataryaya_temas_ediyormu = false;
        }
    }
}