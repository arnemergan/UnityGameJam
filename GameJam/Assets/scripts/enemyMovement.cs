using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    
    public int soldierNumber;
    private GameObject target;
    private Enemy enemy;
    private Transform targetLocation;
    private Rigidbody rb;
    private float timeSinceLastRotationUpdate = 0f;
    private float updateRate;
   
    void Start()
    {
        enemy = GetComponent<Enemy>();

        rb = enemy.GetComponent<Rigidbody>();
        //rb.isKinematic = true;

        target = GameObject.Find("soldier" + soldierNumber);
        targetLocation = target.transform;

        var lookPos = targetLocation.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0);
    }

    void FixedUpdate()
    {
        rb.transform.position += new Vector3(rb.transform.forward.x / 100 * movementSpeed, 0, rb.transform.forward.z / 100 * movementSpeed);
        updateRate = 20 - Vector3.Distance(targetLocation.position, rb.position) / 2;
        if (timeSinceLastRotationUpdate + (1 / updateRate) < Time.time)
        {
            timeSinceLastRotationUpdate = Time.time;
            UpdateRotation();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }

    }

    private void UpdateRotation()
    {
        var lookPos = targetLocation.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
    }
}
