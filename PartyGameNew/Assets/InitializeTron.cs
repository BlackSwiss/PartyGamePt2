using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeTron : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns; //Setting up premade spawn locations

    [SerializeField]
    private GameObject playerPrefab; //Set player character

    private Color[] colors = {  new Color(1, 0, 0, 1),new Color(0, 1, 0, 1), new Color(1, 1, 0, 1), new Color(0, 0, 1, 1) };

    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();

        for (int i = 0; i < playerConfigs.Length; i++)
        {
            //Load in player Character
            playerConfigs[i].IsActive = true;
            //Debug.Log("Controller turned on: " + playerConfigs[i].IsActive);

            //Load in object with controller logic attached
            
            GameObject PlayerObj = Instantiate(playerConfigs[i].PlayerCharacter, playerSpawns[i].transform.position, playerSpawns[i].transform.rotation);

            Vector3 HelperObjSpawn = PlayerObj.transform.position + new Vector3(0, 1 , -1);

            var HelperObj = Instantiate(playerPrefab, HelperObjSpawn, PlayerObj.transform.rotation, PlayerObj.transform);

            var TrailColor = HelperObj.GetComponent<ParticleSystem>().main;
            TrailColor.startColor = colors[i];
            
            //Debug.Log("Player Character: " + playerConfigs[i].PlayerCharacter.name);
            PlayerObj.AddComponent<TronMover>();
            PlayerObj.AddComponent<PlayerInputHandlerTron>();
            //PlayerObj.GetComponent<PlayerInputHandler>();
            StartCoroutine(WaitForStart());
            PlayerObj.GetComponent<PlayerInputHandlerTron>().InitializePlayer(playerConfigs[i]);
        }
    }

    IEnumerator WaitForStart()
    {

        yield return new WaitForSeconds(5f);

    }
}
