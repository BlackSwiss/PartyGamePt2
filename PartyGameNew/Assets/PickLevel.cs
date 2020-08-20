using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickLevel : MonoBehaviour
{
    float currTime = 0f;
    float startTime = 10f;
    public Animator Transition;

    public Text TimerText;

    private int LevelNum;
    // Start is called before the first frame update
    void Start()
    {
        Transition = GetComponent<Animator>();
        currTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= 1 * Time.deltaTime;
        TimerText.text = currTime.ToString("0");
        if(currTime <= 0)
        {
            TimerText.enabled = false;
            LevelNum = SelectLevel();
            StartCoroutine(LoadScene(LevelNum));
        }
    }
    IEnumerator LoadScene(int index)
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }
    public void MiniGamePick()
    {
        //TODO
        //Create a timer function that counts down to next game selected
        //Have a random number saved to be the next mini game level
        //Display the Mini Game name
        //Loading screen maybe?
        //Once Timer is done, load Scene
    }
    private int SelectLevel()
    {
        int index = Random.Range(5, 7);
        return index;
    }
}
