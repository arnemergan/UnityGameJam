using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    public float lookRadius = 10;
    private Transform target1;
    private Transform target2;
    private GameObject playertarget1;
    private GameObject playertarget2;
    public Enemy enemy;
    private Transform[] transforms = new Transform[2];

    NavMeshAgent navMesh;
    // Start is called before the first frame update
    void Start()
    {
        playertarget1 = GameObject.Find("soldier1");
        playertarget2 = GameObject.Find("soldier2");
        target1 = playertarget1.transform;
        target2 = playertarget2.transform;
        transforms[0] = target1;
        transforms[1] = target2;
        enemy = GetComponent<Enemy>();
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform target = GetClosestTarget(transforms);
        if(enemy.health > 0){
            float distance = Vector3.Distance(target.position,transform.position);
            if(distance <= lookRadius){
                navMesh.SetDestination(target.position);
                if(distance <= navMesh.stoppingDistance){
                    //do damage to player
                    Player player = target.GetComponent<Player>();
                    player.TakeDamage(enemy.damage,target); 
                }
            }
        }
    }

Transform GetClosestTarget(Transform[] targets)
{
    Transform tMin = null;
    float minDist = Mathf.Infinity;
    Vector3 currentPos = transform.position;
    foreach (Transform t in targets)
    {
        float dist = Vector3.Distance(t.position, currentPos);
        if (dist < minDist)
        {
            tMin = t;
            minDist = dist;
        }
    }
    return tMin;
}
}
