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

    private void OnCollisionStay(Collision other) {
        if(other.collider.name.ToLower() == "soldier"){
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage(100,player.transform);
        }
    }
}
