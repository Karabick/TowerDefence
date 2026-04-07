using UnityEngine;

public class WarriorsMovement : MonoBehaviour
{
    public float speed = 5f;
    public float speedRotation = 180f;
    public int Level = 1;
    public Transform targetPoint;

    void Start()
    {
        if (speed == 0) speed = 5f;
        if (speedRotation == 0) speedRotation = 180f;
    }

    void Update()
    {
        if (targetPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, Time.deltaTime * speed);
            Vector3 direction = targetPoint.position - transform.position;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(
                    transform.rotation,
                    targetRotation,
                    Time.deltaTime * speedRotation
                );
            }
        }
    }
}