using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    [SerializeField] private float chainOffset;
    [SerializeField] private GameObject chainPrefab;

    [SerializeField] private float startAngle;
    [SerializeField] private float radius;

    private int ballOrderInLayer;

    private void Start()
    {
        SpikeBallDamage spikeBallDamage = GetComponentInChildren<SpikeBallDamage>();

        spikeBallDamage.transform.localPosition = new Vector2(radius * Mathf.Cos(startAngle * Mathf.Deg2Rad), radius * Mathf.Sin(startAngle * Mathf.Deg2Rad));



        ballOrderInLayer = spikeBallDamage.GetComponent<SpriteRenderer>().sortingOrder;
        Rigidbody2D m_rigidbody = GetComponent<Rigidbody2D>();
        float maxRadius = ((Vector2)(spikeBallDamage.transform.localPosition)).magnitude;
        float curentRadius = 0;
        Vector2 spawnPosition = transform.position;
        Vector2 spawnDirection = (Vector2)(spikeBallDamage.transform.position);

        int n = (int)(maxRadius / chainOffset);
        for(int i = 0 ; i < n; i++)
        {
            GameObject chain = Instantiate(chainPrefab, spawnPosition, Quaternion.identity);

            Rigidbody2D rigidbody =  chain.AddComponent<Rigidbody2D>();
            SpringJoint2D joint =  chain.AddComponent<SpringJoint2D>();
            chain.GetComponent<SpriteRenderer>().sortingOrder = ballOrderInLayer - 1;

            chain.transform.parent = transform;
            rigidbody.gravityScale = 1f * curentRadius / maxRadius;
            joint.connectedBody = m_rigidbody;
            joint.dampingRatio = 1f;
            joint.frequency = 1000000f;

            curentRadius += chainOffset;
            spawnPosition = Vector2.MoveTowards(spawnPosition , spawnDirection, chainOffset);
        }
    }
}
