using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerInputFunc : MonoBehaviour
{
    //Methods for button inputs
    private void OnA()
    {
        Debug.Log("Pressed A");
        SendMessageUpwards("onButtonPress", 0, SendMessageOptions.RequireReceiver);
    }

    private void OnB()
    {
        Debug.Log("Pressed B");
        SendMessageUpwards("onButtonPress", 1);
    }

    private void OnX()
    {
        Debug.Log("Pressed X");
        SendMessageUpwards("onButtonPress", 2);
    }

    private void OnY()
    {
        Debug.Log("Pressed Y");
        SendMessageUpwards("onButtonPress", 3);
    }

    private void OnLB()
    {
        Debug.Log("Pressed LB");
        SendMessageUpwards("onButtonPress", 4);
    }

    private void OnRB()
    {
        Debug.Log("Pressed RB");
        SendMessageUpwards("onButtonPress", 5);
    }

}
