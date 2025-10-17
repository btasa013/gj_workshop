using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float attackDistance = 2f;

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {

        }

        else
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.MoveTowards(pos.x, player.position.x, speed * Time.deltaTime);
            transform.position = pos;
        }
    }
}
