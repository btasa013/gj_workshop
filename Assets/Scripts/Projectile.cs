using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    public Rigidbody2D Rigidbody => rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
