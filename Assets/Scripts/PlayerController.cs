using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Projectile projectile;

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
        transform.position += speed * Time.deltaTime * force;

        Camera camera = Camera.main;
        Vector2 mouseScreenPos = Input.mousePosition;
        Ray mouseRay = camera.ScreenPointToRay(mouseScreenPos);
        Vector2 mouseDirection = mouseRay.direction;

        Vector2 cameraPos = camera.transform.position;
        Vector2 direction = (Vector2)transform.position - cameraPos;

        float angleDegrees = Vector3.Angle(direction, mouseDirection);

        // Attack
        bool attacking = Input.GetKeyDown(KeyCode.Space);
        if (attacking)
        {
            Projectile p = Instantiate(projectile);
            p.transform.position = transform.position;
            p.transform.forward = Quaternion.Euler(0, angleDegrees, 0) * Vector3.up;
        }
    }
}
