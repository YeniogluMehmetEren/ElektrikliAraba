using UnityEngine;
using UnityEngine.UI;

public class LiftMovement : MonoBehaviour
{
    public Transform transformLift;
    public float liftingSpeed;
    public Button btnUp;
    public Button btnDown;

    Vector3 liftMin = new Vector3(0f, 0.085f, 0f);
    Vector3 liftMax = new Vector3(0f, 1.7f, 0f);

    public bool basiliTutuluyor = false;


    public void ButonaBasildi()
    {
        basiliTutuluyor = true;
    }

   
    public void ButonBirakildi()
    {
        basiliTutuluyor = false;
    }

    void Update()
    {
        if (basiliTutuluyor && btnUp.IsPressed() && transformLift.transform.position.y < liftMax.y)
        {
            transformLift.transform.position += Vector3.up * liftingSpeed;
            //Debug.Log(transformLift.transform.position.y);
            //Debug.Log(liftMax.y);
        }
        if (basiliTutuluyor && btnDown.IsPressed() && transformLift.transform.position.y > liftMin.y )
        {
            transformLift.transform.position += Vector3.down * liftingSpeed;
        }
    }
}
