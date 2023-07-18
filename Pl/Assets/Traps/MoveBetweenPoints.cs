using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public List<Vector2> Points { get; private set; }
    public float MoveSpeed => moveSpeed;
    public float WaitOnPointTime => waitOnPointTime;
    public bool MoveWithAcceleration => moveWithAcceleration;
    public float Acceleration => acceleration;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float waitOnPointTime;
    [SerializeField] private float acceleration;
    [SerializeField] private bool moveWithAcceleration;

    private void Awake()
    {
        GetPointsPosition();
    }

    private void GetPointsPosition()
    {
        Points = new List<Vector2>();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Point>() != null)
            {
                Points.Add(transform.GetChild(i).position);
            }
        }
    }
}
