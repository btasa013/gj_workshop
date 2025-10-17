using JetBrains.Rider.Unity.Editor;
using UnityEditor.ShaderGraph;
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

    public GameObject prefabObstacle1;
    public GameObject prefabObstacle2;
    public GameObject cameraInversion;
    public GameObject dead;


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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle1") ||
            collision.gameObject.CompareTag("Obstacle2"))
        {
            Die(collision.gameObject.tag);
        }
    }
    void Die(string obstacleTag)
    {
 
        Debug.Log("You Died from: " + obstacleTag);

        GameObject firstToSpawn = null;
        Vector3 spawnPosition = transform.position + new Vector3(-1.5f, -0.8f, 0);
        switch (obstacleTag)
        {
            case "Obstacle1":
                firstToSpawn = prefabObstacle1;
                break;
            case "Obstacle2":
                firstToSpawn = prefabObstacle2;
                break;
        }

        if (firstToSpawn != null)
        {
            Instantiate(firstToSpawn, spawnPosition, Quaternion.identity);
        }
        cameraInversion.SetActive(true);
        dead.SetActive(true);

         transform.position = new Vector3(transform.position.x, transform.position.y - 9999f, transform.position.z - 99999f);


 
    }


}
