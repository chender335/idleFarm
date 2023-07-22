using UnityEngine;
using System;

public class FireTrap : MonoBehaviour
{
    public Action<bool> OnFireStateChanged; 

    [SerializeField] private float timeToBurn;
    [SerializeField] private float burnTime;

    private BurnStage burnStage;
    private Animator animator;
    private float timeRemained;

    private void Awake()
    {
        burnStage = BurnStage.Off;
        timeRemained = 0;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(timeRemained >= 0)
        {
            timeRemained -= Time.deltaTime;
        }
        else
        {
            if ((burnStage == BurnStage.Hit) || (burnStage == BurnStage.On))
            {
                SetNextStage();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(213);
        if(burnStage == BurnStage.Off)
        {
            SetNextStage();
        }
    }

    private void SetNextStage()
    {
        if(burnStage == BurnStage.Off)
        {
            Debug.Log(1);
            timeRemained = timeToBurn;
            burnStage = BurnStage.Hit;
            animator.Play("Hit");
        }
        else if(burnStage == BurnStage.Hit)
        {
            Debug.Log(2);
            timeRemained = burnTime;
            burnStage = BurnStage.On;
            OnFireStateChanged?.Invoke(true);
            animator.Play("On");
        }
        else
        {
            Debug.Log(3);
            OnFireStateChanged?.Invoke(false);
            burnStage = BurnStage.Off;
            animator.Play("Off");
        }
    }

    private enum BurnStage
    {
        Off,
        Hit,
        On
    }
}


