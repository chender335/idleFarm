using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public List<Vector2> Points { get; private set; }
    public float MoveSpeed => moveSpeed;
    public float WaitOnPointTime => waitOnPointTime;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float waitOnPointTime;
    [SerializeField] private GameObject chainPrefab;
    [SerializeField] private float chainOffset;

    private int moovObjectSortingLayer;

    private void Awake()
    {
        GetPointsPosition();
        CreateChain();
        moovObjectSortingLayer = GetComponentInChildren<ObjectToMove>().GetComponent<SpriteRenderer>().sortingOrder;
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

        if(Points.Count < 2)
        {
            throw new System.Exception("Cant move beetwen 1 point " + gameObject);
        }
    }

    private void CreateChain()
    {
        if (Points == null)
        {
            return;
        }

        if (Points.Count == 2)
        {
            CreateChainLine(Points[0], Points[1]);
        }
        else
        {
            CreateChainLine(Points[0], Points[Points.Count - 1]);

            for (int i = 0; i < Points.Count - 1; i++)
            {
                CreateChainLine(Points[i], Points[i + 1]);
            }
        }
    }

    private void CreateChainLine(Vector2 pos1, Vector2 pos2)
    {
        int n = (int)(Mathf.Sqrt(((pos2.x - pos1.x) * (pos2.x - pos1.x) + (pos2.y - pos1.y) * (pos2.y - pos1.y) )) / chainOffset);
        Vector2 spawnPos = pos1;

        for(int i = 0; i < n + 1; i++)
        {
            GameObject chain =  Instantiate(chainPrefab, spawnPos, Quaternion.identity);
            chain.transform.parent = transform;
            chain.GetComponent<SpriteRenderer>().sortingOrder = moovObjectSortingLayer - 1;
            spawnPos = Vector2.MoveTowards(spawnPos, pos2, chainOffset);
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;


        if (Points == null)
        {
            return;
        }
        else if (Points.Count == 2)
        {
            Gizmos.DrawLine(Points[0], Points[1]);
        }
        else if (Points != null)
        {
            Gizmos.DrawLine(Points[0], Points[Points.Count - 1]); 

            for (int i = 0; i < Points.Count - 1; i++)
            {
                Gizmos.DrawLine(Points[i], Points[i + 1]);
            }
        }
    }*/
}
