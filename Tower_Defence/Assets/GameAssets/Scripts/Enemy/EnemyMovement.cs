using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0;
    public float speedRotation = 0;
    public int Level = 1;
    public Transform[] point;

    int currentWaypointIndex = 0;

    void Update()
    {
        SimpleMovement();
    }

    void SimpleMovement()
    {
        if (currentWaypointIndex < point.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, point[currentWaypointIndex].position, Time.deltaTime * speed);
            Vector3 direction = point[currentWaypointIndex].position - transform.position;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * speedRotation
                );
            }
            if (Vector3.Distance(transform.position, point[currentWaypointIndex].position) < 0.1f) currentWaypointIndex++;
        }
    }

}
