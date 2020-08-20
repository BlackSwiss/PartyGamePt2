using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandlerTron : MonoBehaviour
{
    //ref to playerInput
    private PlayerConfiguration playerInput; //The literal player Input of the controller
    private TronMover mover; //ref to movement script
    [SerializeField]
    private Controller controls; //.references to controller C# class we made earlier

    public GameObject PlayerAvatr;
    void Awake()
    {

        mover = GetComponent<TronMover>(); //Get Player prefab
        controls = new Controller(); //creates a new contrller object

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

    private void Input_onActionTriggered(CallbackContext obj)
    {
        //Check what action was perfromed
        if(!playerInput.IsActive)
        {
            Debug.Log("Player Controller");
            return;
        }
        else
        {
            if (obj.action.name == controls.PlayerMovement.Movement.name)
            {
                OnMove(obj);

            }
            if (obj.action.name == controls.PlayerMovement.Jump.name)
            {

            }
        }

    }

    //Function that is called by controller
    public void OnMove(CallbackContext context)
    {
        if (mover != null)
            mover.SetInputVector(context.ReadValue<Vector2>()); //Tells the mover script what value the stick motion is returning and saves it to be used later
    }

    public void OnJump(CallbackContext context)
    {
        //context.ReadValue();
        if (mover != null)
        {
            mover.Jump();
        }
    }
}
