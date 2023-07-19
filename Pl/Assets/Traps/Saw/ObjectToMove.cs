using UnityEngine;
using System;

public class ObjectToMove : MonoBehaviour
{
    public Action<bool> OnStateChange;

    private int curentPoint = 0;
    private MoveBetweenPoints moveInfo;
    private float timeRemainedToStay;
    private bool isWaiting;

    private void Awake()
    {
        moveInfo = transform.parent.GetComponent<MoveBetweenPoints>();
        curentPoint = 0;
        timeRemainedToStay = 0;
        isWaiting = false;
    }

    private void Update()
    {
        if(!isWaiting)
        {
            MoveToNextPoint();
        }
        else
        {
            timeRemainedToStay -= Time.deltaTime;

            if(timeRemainedToStay <= 0)
            {
                isWaiting = false;
                OnStateChange?.Invoke(isWaiting);
            }
        }
    }

    private void MoveToNextPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveInfo.Points[curentPoint], moveInfo.MoveSpeed * Time.deltaTime);

        if((Vector2)transform.position == moveInfo.Points[curentPoint])
        {
            if (curentPoint + 1 == moveInfo.Points.Count)
            {
                curentPoint = 0;
            }
            else
            {
                curentPoint++;
            }

            isWaiting = true;
            OnStateChange?.Invoke(isWaiting);
            timeRemainedToStay = moveInfo.WaitOnPointTime;
        }
    }
}
