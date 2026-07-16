using UnityEngine;

public class LiftAnimationController : MonoBehaviour
{
    private Animator animator;

    // Animasyonun o anki konumu (0-1 arası)
    private float currentTime = 0f;

    // Hareket yönü
    private int direction = 0;
    // 1 = yukarı
    // -1 = aşağı
    // 0 = dur

    // LiftUp animasyonu toplam uzunluğu
    private const float liftUpLength = 7.267f;

    void Start()
    {
        animator = GetComponent<Animator>();

        animator.Play("LiftUp", 0, 0f);
        animator.Update(0);

        animator.speed = 0;
    }

    void Update()
    {
        if (direction == 0)
            return;

        currentTime += (direction * Time.deltaTime) / liftUpLength;

        currentTime = Mathf.Clamp01(currentTime);

        animator.Play("LiftUp", 0, currentTime);
        animator.Update(0);

        if (currentTime <= 0f)
            direction = 0;

        if (currentTime >= 1f)
            direction = 0;
    }

    // YEŞİL
    public void ButtonUpPressed()
    {
        direction = 1;
    }

    public void ButtonUpReleased()
    {
        direction = 0;
    }

    // KIRMIZI
    public void ButtonDownPressed()
    {
        direction = -1;
    }

    public void ButtonDownReleased()
    {
        direction = 0;
    }
}