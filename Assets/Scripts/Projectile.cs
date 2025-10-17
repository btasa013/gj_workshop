using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private float direction;

    public void SetDirection(float dir)
    {
        direction = dir;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime * Vector3.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }   
    }
}
