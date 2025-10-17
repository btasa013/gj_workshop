using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject monster;

    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private float leftX;
    [SerializeField] private float rightX;

    [SerializeField] private float interval = 5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnMonster), 1f, interval);
    }

    void SpawnMonster()
    {
        float x = Random.value > 0.5f ? leftX : rightX;
        float y = Random.Range(minY, maxY);
        
        GameObject obj = Instantiate(monster);
        obj.transform.position = new Vector3(x, y);
    }
}
