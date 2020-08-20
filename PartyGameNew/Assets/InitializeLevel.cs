using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns; //Setting up premade spawn locations

    [SerializeField]
    private GameObject playerPrefab; //Set player character

    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();

        for( int i = 0; i < playerConfigs.Length; i++)
        {
            //Load in player Character
            playerConfigs[i].IsActive = false;
            Debug.Log("Controller turned off: " + playerConfigs[i].IsActive);
            
            //Load in object with controller logic attached
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation);
            GameObject PlayerObj = Instantiate(playerConfigs[i].PlayerCharacter, player.transform.position, player.transform.rotation, player.transform);
            PlayerObj.transform.parent = player.transform;
            //Debug.Log("Player Character: " + playerConfigs[i].PlayerCharacter.name);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
        }
    }

}
