using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private KeyCode shootKey;
    [SerializeField] private Transform shootPosition;   
    [SerializeField] private float bulletAmount;
    [SerializeField] private GunInfo gunInfo;
    
    public static GunInfo GunInfo { get; private set; }
    public static bool IsFacingRight { get; private set; }

    private float timeFromPreviousShot;

    private void Awake()
    {
        IsFacingRight = true;
        GunInfo = gunInfo;
        timeFromPreviousShot = gunInfo.ShootDelay;
    }

    private void Update()
    {
        if (timeFromPreviousShot >= 0)
        {
            timeFromPreviousShot += Time.deltaTime;
        }
        if (Input.GetKeyDown(shootKey) && timeFromPreviousShot >= gunInfo.ShootDelay && bulletAmount > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(gunInfo.BulletPrefab, shootPosition.position, Quaternion.Euler(0, 0, IsFacingRight ? 0 : 180));
        timeFromPreviousShot = 0;
        bulletAmount--;
    }

    private void IncreaseAmo(float amount)
    {
        if(amount <= 0)
        {
            throw new System.Exception("You cant add less then 0 amo" + gameObject);
        }
        else
        {
            bulletAmount += amount;
        }
    }

    private void OnEnable()
    {
        PlayerPickUp.OnAmoUp += IncreaseAmo;
    }

    private void OnDisable()
    {
        PlayerPickUp.OnAmoUp -= IncreaseAmo;
    }
}
