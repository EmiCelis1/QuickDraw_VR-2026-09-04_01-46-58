using UnityEngine;

public class SimpleGunShoot : MonoBehaviour
{
    [Header("Referencias")]
    public Transform firePoint;
    public float bulletSpeed = 30f;


    public void Shoot()
    {
        GameObject bullet = BulletManager.Instance.GetBullet();

        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
}