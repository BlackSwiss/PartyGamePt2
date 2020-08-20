using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePlayArea : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns; //Setting up premade spawn locations

    [SerializeField]
    //private GameObject playerPrefab; //Set player character

    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();

        for (int i = 0; i < playerConfigs.Length; i++)
        {
            //Load in player Character
            playerConfigs[i].IsActive = false;
            //Debug.Log("Controller turned off: " + playerConfigs[i].IsActive);

            //Load in object with controller logic attached
            //var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation);
            GameObject PlayerObj = Instantiate(playerConfigs[i].PlayerCharacter, playerSpawns[i].position, playerSpawns[i].rotation);
            //PlayerObj.transform.parent = player.transform;
            Debug.Log("Player Character: " + playerConfigs[i].PlayerCharacter.name);
            PlayerObj.AddComponent<Mover>();
            PlayerObj.AddComponent<PlayerInputHandler>();
            
            PlayerObj.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
        }
    }
}

  

