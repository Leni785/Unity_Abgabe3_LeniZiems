using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    float moveDistance = 2f;
    float speed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, moveDistance * 2) - moveDistance;
        transform.position = startPos + Vector3.right * offset;
    }
}

