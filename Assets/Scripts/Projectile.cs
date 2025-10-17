using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
