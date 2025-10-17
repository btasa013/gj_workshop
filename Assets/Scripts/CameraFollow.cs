using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        transform.position = pos;
    }
}
