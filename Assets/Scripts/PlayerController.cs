using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Projectile projectile;

    private Rigidbody2D rb;
    
    public bool onGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move
        float x = Input.GetAxis("Horizontal");
        transform.position += speed * Time.deltaTime * x * Vector3.right;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            onGround = true;
    }
}
