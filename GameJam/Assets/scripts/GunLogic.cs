using UnityEngine;

public class GunLogic : MonoBehaviour
{
    public Transform FirePoint;
    public Rigidbody Bullet;
    public float BulletSpeed;
    public float FireRate;
    private float TimeSinceLastShot = 0f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        shoot();
    }

    void shoot()
    {
        if (Input.GetAxis("Fire1") == 1 && TimeSinceLastShot + 1 / FireRate < Time.time)
        {   
            Rigidbody bulletInstance = Instantiate(Bullet, FirePoint.position, FirePoint.rotation*Quaternion.Euler(-90, 0, -90)) as Rigidbody;
            bulletInstance.velocity = FirePoint.forward * -BulletSpeed;
            TimeSinceLastShot = Time.time;
        }
    }
}