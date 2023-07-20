using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public float StratAngle => stratAngle;
    public float Speed => speed;

    [SerializeField] private float stratAngle;
    [SerializeField] private float speed;
    [SerializeField] private float chainOffset;
    [SerializeField] private GameObject chainPrefab;


    private int moovObjectSortingLayer;
    private float radius;
    private Vector2 spawnDirection;

    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        { 
            if(transform.GetChild(i).GetComponent<ObjectToMoveAround>() != null)
            {
                spawnDirection = transform.GetChild(i).position;
                radius = Vector2.SqrMagnitude((transform.GetChild(i).position - transform.position));
            }
        }
        int n = (int)(radius / chainOffset);
        Vector2 spawnPos = transform.position;

        for (int i = 0; i < n + 1; i++)
        {
            GameObject chain = Instantiate(chainPrefab, spawnPos, Quaternion.identity);
            chain.transform.parent = transform;
            chain.GetComponent<SpriteRenderer>().sortingOrder = moovObjectSortingLayer - 1;
            chain.AddComponent<ObjectToMoveAround>();
            spawnPos = Vector2.MoveTowards(spawnPos, spawnDirection, chainOffset);
        }
    }
}
