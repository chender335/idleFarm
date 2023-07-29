using UnityEngine;

public class ObjectToMoveAround : MonoBehaviour
{
    private float angle;
    private MoveAround moveInfo;
    private float radius;

    private void Awake()
    {
        moveInfo = transform.parent.GetComponent<MoveAround>();
        angle = moveInfo.StratAngle * Mathf.Deg2Rad;
        radius = Mathf.Sqrt(transform.localPosition.x * transform.localPosition.x + transform.localPosition.y * transform.localPosition.y);

    }

    private void Update()
    {
        angle -= moveInfo.Speed * Time.deltaTime;

        transform.localPosition = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
    }
}
