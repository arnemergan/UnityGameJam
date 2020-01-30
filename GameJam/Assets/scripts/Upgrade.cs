using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private string Tag;

    void Start()
    {
        Tag = gameObject.tag;
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if(collisionInfo.gameObject.tag.ToLower() == "player"){
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(Tag);
            foreach (GameObject go in gameObjects)
            {
                Destroy(go);
            }
        }
        
    }
}
