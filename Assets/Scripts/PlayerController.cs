using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] new AudioSource audio;

    [SerializeField] AudioClip shootAudio;

    [SerializeField] private float speed;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Projectile projectile;

    [SerializeField] private Vector2 boundsX;
    [SerializeField] private Vector2 boundsY;

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

        if (x != 0)
        {
            spriteRenderer.flipX = x < 0;
        }
        
        Vector3 pos = transform.position + speed * Time.deltaTime * force;

        pos.x = Mathf.Clamp(pos.x, boundsX.x, boundsX.y);
        pos.y = Mathf.Clamp(pos.y, boundsY.x, boundsY.y);
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shootAudio != null) audio.PlayOneShot(shootAudio);

            Projectile p = Instantiate(projectile);
            p.transform.position = transform.position;
            p.SetDirection(spriteRenderer.flipX ? -1 : 1);
        }
    }
}
