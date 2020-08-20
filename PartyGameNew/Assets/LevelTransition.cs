using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelTransition : MonoBehaviour
{
    float currTime = 0f;
    [Range(10f, 60f)]
    public float startTime = 10f;

    public Animator Transition;


    public Text TimerText;

    private int LevelNum;
    // Start is called before the first frame update
    void Start()
    {
        //Transition = GetComponent<Animator>();
        currTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= 1 * Time.deltaTime;
        TimerText.text = currTime.ToString("0");
        if (currTime <= 0)
        {
            TimerText.enabled = false;
            Transition.SetTrigger("Start");
            // LevelNum = SelectLevel();
            // StartCoroutine(LoadScene(LevelNum));
            SceneManager.LoadScene("LevelLoading");
        }
    }
    //IEnumerator LoadScene(int index)
    //{
    //    Transition.SetTrigger("Start");

    //    yield return new WaitForSeconds(2f);
    //    SceneManager.LoadScene("Tron");
    //    //SceneManager.LoadScene(index);
    //}

    private int SelectLevel()
    {
        int index = Random.Range(5, 7);
        return index;
    }
}
