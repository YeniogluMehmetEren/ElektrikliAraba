using UnityEngine;
using UnityEngine.UI;

public class LiftMovement : MonoBehaviour
{
    public Transform transformLift;
    public float liftingSpeed;
    public Button btnUp;
    public Button btnDown;
    [SerializeField] private AudioSource lift_ses;
    Vector3 liftMin = new Vector3(0f, 0.085f, 0f);
    Vector3 liftMax = new Vector3(0f, 1.7f, 0f);

    public bool basiliTutuluyor = false;

    public bool liftEnYukardaMi = false;


    public void ButonaBasildi()
    {
        basiliTutuluyor = true;
    }

   
    public void ButonBirakildi()
    {
        basiliTutuluyor = false;

        if (lift_ses != null && lift_ses.isPlaying)
        {
            lift_ses.Stop();
        }
    }

    void Update()
    {
        if (basiliTutuluyor && btnUp.IsPressed() && transformLift.transform.position.y < liftMax.y)
        {
            if (lift_ses != null && !lift_ses.isPlaying)
            {
                lift_ses.Play();
            }

            transformLift.transform.position += Vector3.up * liftingSpeed;
            //Debug.Log(transformLift.transform.position.y);
            //Debug.Log(liftMax.y);
            if (transformLift.transform.position.y >= liftMax.y)
            {
                liftEnYukardaMi = true;

                if (lift_ses != null)
                {
                    lift_ses.Stop();
                }
            }
        }
        if (basiliTutuluyor && btnDown.IsPressed() && transformLift.transform.position.y > liftMin.y )
        {

            if (lift_ses != null && !lift_ses.isPlaying)
            {
                lift_ses.Play();
            }

            transformLift.transform.position += Vector3.down * liftingSpeed;

            if (transformLift.position.y <= liftMin.y)
            {
                if (lift_ses != null)
                {
                    lift_ses.Stop();
                }
            }
        }
    }
}
