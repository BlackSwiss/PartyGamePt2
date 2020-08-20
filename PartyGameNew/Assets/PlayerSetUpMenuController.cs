using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetUpMenuController : MonoBehaviour
{
    private int PlayerIndex;

    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private Button readyButton;
    private float ignoreInputTime = 1.5f;
    private bool InputEnabled;

    public GameObject[] PlayersIdol;
    private int count = 0;
    public GameObject obj;
    public GameObject Prev;
    public GameObject Next;
    public Transform spawn;
   // public Transform PlayAreaSpawn;
    public void SetPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        titleText.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            InputEnabled = true;

        }
    }
    private void Start()
    {
        var location = GameObject.Find(titleText.text);
        spawn = location.transform;
        //location = GameObject.Find(titleText.text + " Play Area");
       // PlayAreaSpawn = location.transform;
       // if (PlayAreaSpawn == null)
         //   Debug.Log("Haven't found one yet :/");
        obj = Instantiate(PlayersIdol[count], spawn.position, Quaternion.Euler(0, 180, 0));
    }
    public void Select()
    {
        //Test function
        readyPanel.SetActive(true);
        readyButton.Select(); //Focus the ready button for the controller
        PlayerConfigurationManager.Instance.SetPlayerCharacter(PlayerIndex, PlayersIdol[count]);
        //Set Menu panel inactive
       // Instantiate(PlayersIdol[count], PlayAreaSpawn.position, Quaternion.Euler(0, 180, 0));
        menuPanel.SetActive(false);
    }
    //This function will need to be altered to handle the Assets like Player Avatars
    public void SetColor (Material Color) 
    {
        if(!InputEnabled) { return; }

        //PlayerConfigurationManager.Instance.SetPlayerColor(PlayerIndex, Color); //This script will need to change to handle asset changes
        readyPanel.SetActive(true);
        readyButton.Select(); //Focus the ready button for the controller
        //Set Menu panel inactive
        menuPanel.SetActive(false);
    }

    public void ReadyPlayer()
    {
        if (!InputEnabled) { return; }

        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex); //tELLS MANAGER THE PLAYER IS READY
        readyButton.gameObject.SetActive(false);
    }

    public void Left()
    {

        if (count > 0)
        {
            Destroy(obj);
            count--;
            obj = Instantiate(PlayersIdol[count], spawn.position, Quaternion.Euler(0, 180, 0));
        }



    }
    public void Right()
    {

        if (count < 6)
        {
            Destroy(obj);
            count++;
            obj = Instantiate(PlayersIdol[count], spawn.position, Quaternion.Euler(0, 180, 0));
        }


    }

}
