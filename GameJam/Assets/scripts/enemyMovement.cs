using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    public float lookRadius = 10;

    public Transform target;
    NavMeshAgent navMesh;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position,transform.position);
        if(distance <= lookRadius){
            navMesh.SetDestination(target.position);
            if(distance <= navMesh.stoppingDistance){
                //do damage to player
            }
        }
    }
}
