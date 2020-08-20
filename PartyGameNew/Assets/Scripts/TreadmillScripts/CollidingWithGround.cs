using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingWithGround : MonoBehaviour
{ 
    public Rigidbody rb;

    public float treadmillSpeed = 1;
    public float randomSpeed;
    public float currentTime;




    // Start is called before the first frame update
    void Awake()
    {
         randomSpeed = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = GameObject.Find("CountdownRules").GetComponent<countdownScript>().currentTime;
        if (currentTime <= 0.5f)
        {
            treadmillSpeed = randomSpeed;
            randomSpeed = Random.Range(1f, 5f);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Treadmill")
        {
            rb.transform.Translate(Vector3.forward * Time.deltaTime *treadmillSpeed);
        }
        if (collision.gameObject.tag == "TreadmillB")
        {
            rb.transform.Translate(-Vector3.forward * Time.deltaTime * treadmillSpeed);
        }
    }
}
