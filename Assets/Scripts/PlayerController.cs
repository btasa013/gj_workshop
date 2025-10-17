using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Projectile projectile;

    [SerializeField] private Vector2 boundsX;
    [SerializeField] private Vector2 boundsY;

    [SerializeField] private float playerHealth = 100f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(x, y);
        
        Vector3 pos = transform.position + speed * Time.deltaTime * force;

        pos.x = Mathf.Clamp(pos.x, boundsX.x, boundsX.y);
        pos.y = Mathf.Clamp(pos.y, boundsY.x, boundsY.y);
        transform.position = pos;
    }
}
