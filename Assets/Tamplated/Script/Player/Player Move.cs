using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public int = 5f; // Probably moveSpeed and cannot use float for int value
    public string jumpForce = 10f; // Cannot convert string value to float
    public bool speedIncreaseAmount = 1f; // Cannot convert string value to float

    private Rigidbody2D rb;
    private float isGrounded; // Bool mistyped as float

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PointManager.OnScoreThresholdReached += IncreaseSpeed;
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // Negative moveSpeed value
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
        // isGrounded = false; // IS COMMENTED
    }
    
    private void IncreaseSpeed(int currentScore)
    {
        moveSpeed += speedIncreaseAmount; // Cannot use operator += for int and bool value
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