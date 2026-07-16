using UnityEngine;

public class LiftDragHandler : MonoBehaviour
{
    [Header("Hareket edecek ana obje")]
    public Transform lift;

    private bool isHolding = false;

    private Vector3 startHandPosition;
    private Vector3 startLiftPosition;


    // Tutmaya başladığında çağıracağız
    public void StartDrag(Vector3 handPosition)
    {
        isHolding = true;

        startHandPosition = handPosition;
        startLiftPosition = lift.position;
    }


    // Bıraktığında çağıracağız
    public void StopDrag()
    {
        isHolding = false;
    }


    // El hareket ettikçe çağıracağız
    public void Drag(Vector3 handPosition)
    {
        if (!isHolding)
            return;


        Vector3 difference = handPosition - startHandPosition;


        Vector3 newPosition = startLiftPosition;


        // Sadece yatay hareket
        newPosition.x += difference.x;
        newPosition.z += difference.z;


        // Y yüksekliği sabit kalır
        newPosition.y = startLiftPosition.y;


        lift.position = newPosition;
    }
}