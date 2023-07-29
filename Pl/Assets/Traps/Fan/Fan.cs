using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float timeBeetwenSwitch;
    [SerializeField] private float length;
    [SerializeField] private string onAnimationName = "On";
    [SerializeField] private string offAnimationName = "Off";

#pragma warning disable CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    private BoxCollider2D collider;
#pragma warning restore CS0108 // „лен скрывает унаследованный член: отсутствует новое ключевое слово
    private AreaEffector2D effector;
    private Animator animator;
    private float timeRemainedToSwitch;
    private bool isWork;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        effector = GetComponent<AreaEffector2D>();
        animator = GetComponentInChildren<Animator>();

        length /= transform.localScale.x;

        collider.isTrigger = true;
        collider.usedByEffector = true;
        collider.offset = new Vector2(0, length / 2);
        collider.size = new Vector2(0.25f, length);
        isWork = true;

        effector.forceAngle = 90;
        effector.forceMagnitude = isWork ? forceMagnitude : 0;

        timeRemainedToSwitch = timeBeetwenSwitch;
    }

    private void Update()
    {
        if(timeRemainedToSwitch < 0)
        {
            Switch();
        }
        else
        {
            timeRemainedToSwitch -= Time.deltaTime;
        }
    }

    private void Switch()
    {
        isWork = !isWork;

        animator.Play(isWork ? onAnimationName : offAnimationName );
        
        timeRemainedToSwitch = timeBeetwenSwitch;
        effector.forceMagnitude = isWork ? forceMagnitude : 0;
    }
}
