using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput;
    public float moveSpeed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Karakterin fiziksel darbelerle sağa sola yalpalamasını engelle
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        // Klavyeden A-D veya Yön tuşlarını temizce alır (Basmıyorsan 0 olur)
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Hızı horizontalInput ile çarptık! 
        // Tuşa basmıyorsan horizontalInput 0 olacağı için karakter zınk diye duracak.
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
}