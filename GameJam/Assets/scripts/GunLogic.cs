using UnityEngine;

public class GunLogic : MonoBehaviour
{
    public Transform FirePoint;
    public Rigidbody Bullet;
    public float BulletSpeed;
    public float FireRate;
    private float TimeSinceLastShot = 0f;
    public int playerNumber;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        shoot();
    }

    void shoot()
    {
        if (Input.GetAxis("J" + playerNumber + "Fire1") == 1 && TimeSinceLastShot + 1 / FireRate < Time.time)
        {   
            source.Play();
            Rigidbody bulletInstance = Instantiate(Bullet, FirePoint.position, FirePoint.rotation*Quaternion.Euler(-90, 0, -90)) as Rigidbody;
            bulletInstance.velocity = FirePoint.forward * -BulletSpeed;
            TimeSinceLastShot = Time.time;
        }
    }
}