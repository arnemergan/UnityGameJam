using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float lookRadius = 10;
    public int soldierNumber;
    private GameObject target;
    private Enemy enemy;
    private Transform targetLocation;
    private Rigidbody rb;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        rb = enemy.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        target = GameObject.Find("soldier" + soldierNumber);
        targetLocation = target.transform;
        transform.LookAt(targetLocation);
        transform.rotation *= Quaternion.Euler(0, -90, 0);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * 1000;
    }
}
