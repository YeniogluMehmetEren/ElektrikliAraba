using UnityEngine;

public class BataryaSokTak : MonoBehaviour
{
    [SerializeField] private LiftTemasKontrol liftTemasKontrol;
    [SerializeField] private SoketTakmaCıkartma soketTakmaCikartma;
    [SerializeField] private BoltRemover boltRemover;

    [SerializeField] private Transform liftPlatform;
    [SerializeField] private Transform batarya;

    public bool BataryaLiftteMi => batarya_lift_temi;

    private bool batarya_lift_temi = false;

    private Vector3 batarya_lift_mesafe;

    void Update()
    {
        if (!batarya_lift_temi)
        {
            if (soketTakmaCikartma.TumSoketlerSokulduMu &&
                liftTemasKontrol.Bataryaya_temas_ediyormu && boltRemover.VidalarinHepsiSokulduMu())
            {
                batarya_lift_temi = true;

                batarya_lift_mesafe = batarya.position - liftPlatform.position;

                Debug.Log("Batarya lift üzerine alındı.");
            }
        }

        if (batarya_lift_temi)
        {
            batarya.position = liftPlatform.position + batarya_lift_mesafe;
        }
    }
}