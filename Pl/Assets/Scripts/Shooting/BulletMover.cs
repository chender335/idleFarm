using UnityEngine;

public class BulletMover : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerShoot.IsFacingRight ? PlayerShoot.GunInfo.BulletSpeed : -PlayerShoot.GunInfo.BulletSpeed, 0);
    }
}
