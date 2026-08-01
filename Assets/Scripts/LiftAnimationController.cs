using Unity.VisualScripting;
using UnityEngine;

public class LiftAnimationController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private BataryaSokTak bataryaSokTak;
    [SerializeField] private LiftTemasKontrol temasKontrol;

    private float animasyon_konumu = 0f;

  
    private int hareket_yonu = 0;

    private const float lift_yukselme_suresi = 7.267f;

    public bool kucukLiftEnYukardaMi = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        animator.Play("LiftUp", 0, 0f);
        animator.Update(0);

        animator.speed = 0;
    }

    void Update()
    {
        if (hareket_yonu == 0)
            return;

        animasyon_konumu += (hareket_yonu * Time.deltaTime) / lift_yukselme_suresi;

        animasyon_konumu = Mathf.Clamp01(animasyon_konumu);

        animator.Play("LiftUp", 0, animasyon_konumu);
        animator.Update(0);

        if (animasyon_konumu <= 0f)
            hareket_yonu = 0;

        if (animasyon_konumu >= 1f)
            hareket_yonu = 0;
    }

    public void ButtonUpPressed()
    {
        if (temasKontrol != null &&
            temasKontrol.Bataryaya_temas_ediyormu &&
            !bataryaSokTak.BataryaLiftteMi)
        {
            Debug.Log("Lift en üst noktada yukarı cıkamaz");
            kucukLiftEnYukardaMi = true;
            return;
        }

        hareket_yonu = 1;
    }

    public void ButtonUpReleased()
    {
        hareket_yonu = 0;
    }

    public void ButtonDownPressed()
    {
        hareket_yonu = -1;
    }

    public void ButtonDownReleased()
    {
        hareket_yonu = 0;
    }

    public void HareketiDurdur()
    {
        hareket_yonu = 0;
    }

    public bool BataryaAlınıpAşağıyaIndiMi()
    {
        if (animasyon_konumu == 0f && temasKontrol.Bataryaya_temas_ediyormu)
        {
            return true;
        }
        return false;
    }
}