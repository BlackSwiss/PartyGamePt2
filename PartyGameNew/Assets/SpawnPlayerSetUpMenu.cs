using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetUpMenu : MonoBehaviour
{
    public GameObject playerSetUPMenuPrefab;
    public PlayerInput input;
    private void Awake()
    {
        var rootMenu = GameObject.Find("MainLayout");
        if(rootMenu!=null)
        {
            var menu = Instantiate(playerSetUPMenuPrefab, rootMenu.transform);
            input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            menu.GetComponent<PlayerSetUpMenuController>().SetPlayerIndex(input.playerIndex);
        }
    }


}
