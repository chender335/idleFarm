using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float speed;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float agrDistance;

    private int currentPointIndex = 0;
    private Transform currentPatrolPoint;

    private void Start()
    {
        currentPatrolPoint = patrolPoints[currentPointIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) <= agrDistance)
            Chase();
        else
            Patrol();
    }

    private void Patrol()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, currentPatrolPoint.position, speed * Time.deltaTime);
        if (transform.position == currentPatrolPoint.position)
        {
            currentPointIndex++;
            if (currentPointIndex == patrolPoints.Length)
                currentPointIndex = 0;
            currentPatrolPoint = patrolPoints[currentPointIndex];
        }
    }

    private void Chase()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }
}