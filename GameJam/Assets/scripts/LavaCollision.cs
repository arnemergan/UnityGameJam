using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCollision : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collisionInfo) {
        if(collisionInfo.collider.name.ToLower() == "soldier"){
            source.Play();
        }
    }
}
