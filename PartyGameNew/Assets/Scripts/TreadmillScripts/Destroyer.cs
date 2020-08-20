using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter(Collider other)
    {
            objectToDestroy = other.gameObject;
            Destroy(objectToDestroy);
    }
}
