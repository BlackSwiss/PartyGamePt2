using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonEvent : MonoBehaviour
{
    public static buttonEvent current; //Singleton

    public delegate void onButtonEventDelegate(); //Get subscribers
    public static event onButtonEventDelegate OnbuttonPressEnter; //What subscribers are doing
    public static void OnButtonPress() //If theres subscribes, do the event
    {
        if (OnbuttonPressEnter != null)
        {
            OnbuttonPressEnter();
        }
    }
}
