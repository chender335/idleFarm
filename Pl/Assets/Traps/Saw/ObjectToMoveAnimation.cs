using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ObjectToMoveAnimation : MonoBehaviour
{
    [SerializeField] private string idleAnimationName = "Idle";
    [SerializeField] private string moveAnimationName = "Move";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void ChangeAnimation(bool isWaiting)
    {
        if(isWaiting)
        {
            animator.Play(idleAnimationName);
        }
        else
        {
            animator.Play(moveAnimationName);
        }
    }

    private void OnEnable()
    {
        transform.GetComponent<ObjectToMove>().OnStateChange += ChangeAnimation;
    }

    private void OnDisable()
    {
        transform.GetComponent<ObjectToMove>().OnStateChange -= ChangeAnimation;
    }
}
