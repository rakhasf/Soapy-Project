using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float speedIncreaseAmount = 1f;

    private Rigidbody2D rb;
    private bool isGrounded;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PointManager.OnScoreThresholdReached += IncreaseSpeed;
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
    void OnDestroy()
    {
       
        PointManager.OnScoreThresholdReached -= IncreaseSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            SFXManager.instance.PlaySFX("Jump");
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }
    
    private void IncreaseSpeed(int currentScore)
    {
        moveSpeed += speedIncreaseAmount;
        Debug.Log("Speed increased! New speed: " + moveSpeed);
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}