using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandlerTreadMill : MonoBehaviour
{
    //ref to playerInput
    private PlayerConfiguration playerInput; //The literal player Input of the controller
    private TreadmillPlayerController Treadmill; //ref to movement script
    [SerializeField]
    private TreadmillController controls; //references to controller C# class we made earlier



    public GameObject PlayerAvatr;
    void Awake()
    {

        Treadmill = GetComponent<TreadmillPlayerController>(); //Get Player prefab
        controls = new TreadmillController(); //creates a new contrller object

    }
    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerInput = pc; //assign player controller to object
        //TODO:
        //Add code to set player avatar.
        //Should look something like this:
        // pc.Avatar = PlayerAvatr;
        playerInput.Input.onActionTriggered += Input_onActionTriggered;
    }

    //This script could be the problem
    private void Input_onActionTriggered(CallbackContext obj)
    {
        //Check what action was perfromed
        if (obj.action.name == controls.Controller.Move.name){
            OnMove(obj);

        }
    }

    //Function that is called by controller
    public void OnMove(CallbackContext context)
    {
        if (Treadmill != null)
            Debug.Log("I am connected!");
           // Treadmill.SetInputVector(context.ReadValue<Vector2>()); //Tells the mover script what value the stick motion is returning and saves it to be used later
    }



}
