using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TronMover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.81f; //How fast the object is moving
    //Move direction
    private Vector3 moveDirection = Vector3.zero; //Where we move in the world
    private Vector2 inputVector = Vector2.zero; // Stick input of the X and Y values on a controller


    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction; //Setting the stick controls to the direction we want the player to move in
    }

    // Update is called once per frame
    void Update()
    {
        {
           

            Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y) * moveSpeed * Time.deltaTime;
            Debug.Log("Movement Vector: " + movement.ToString());
            Quaternion targetRotation = Quaternion.LookRotation(movement + transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * (15/360f));

        }
    }

    public void Jump()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float fallMultiplier = 2.5f;
        float lowJumpMulti = 2f;

        if (rb.velocity.y > 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }

    }
}
