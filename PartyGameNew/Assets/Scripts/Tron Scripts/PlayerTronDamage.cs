using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Chloe Culver
// This script takes care of player/ trail collisions
public class PlayerTronDamage : MonoBehaviour
{
    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {


        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents); //number of particles colliding with object

        if (other.gameObject.tag == "Player" && numCollisionEvents > 5) //if more than five particles collide with the Player object, kill it
        {
            Debug.Log("I've hit something: " + other.gameObject.name); //
            //other.SetActive(false);


        }

    }
}
