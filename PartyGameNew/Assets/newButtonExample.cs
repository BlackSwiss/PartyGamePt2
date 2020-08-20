using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newButtonExample : MonoBehaviour
{
    //Parabola locations
    public GameObject Start;
    public GameObject Peak;
    public GameObject End;


    //Random number corresponding to buttons
    //{ A, B, X, Y, LB, RB}
    int randomNum;
    //Button the player pressed
    //player1.currNum

    private int currNum = -1;

    //Array of button pictures
    public GameObject[] pictures = new GameObject[] { };

    //Current picture shown
    private GameObject currentButton;

    //Count to keep score
    private int count = 0;

    //Cooldown Timers
    public float cooldownTime = 2;
    //Next time you can press the button
    //If we wanna start with a cooldown increase this
    private float nextPressTime =0;

    //Cant do random in start
    void Awake()
    {
        //buttonEvent.OnbuttonPressEnter += onButtonPress;
        randomNum = Random.Range(0, 5);
        currNum = -1;
        Debug.Log(randomNum);

        //Display random numbers button 
        switch (randomNum)
        {
            //Random number is 0 therefore display A on screen
            case 0:
                currentButton = pictures[0];
                currentButton.SetActive(true);
                break;
            //Random number is 1 therefore display B on screen
            case 1:
                currentButton = pictures[1];
                currentButton.SetActive(true);
                break;
            //Random number is 2 therefore display X on screen
            case 2:
                currentButton = pictures[2];
                currentButton.SetActive(true);
                break;
            //Random number is 3 therefore display Y on screen
            case 3:
                currentButton = pictures[3];
                currentButton.SetActive(true);
                break;
            //Random number is 4 therefore display LB on screen
            case 4:
                currentButton = pictures[4];
                currentButton.SetActive(true);
                break;
            //Random number is 5 therefore display RB on screen
            case 5:
                currentButton = pictures[5];
                currentButton.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void onButtonPress(int buttonNum)
    {
        if (Time.time > nextPressTime)
        {
            if (buttonNum == randomNum)
            {
                //Do animation
                GetComponent<ParabolaController>().FollowParabola();
                //For some reason start and end are swapped? Fixed in gameobject settings
                //Swap start with end of curve
                Start.transform.position = End.transform.position;
                //Move end to top of other platform
                End.transform.position = new Vector3(End.transform.position.x + 5, End.transform.position.y + 2, 0);

                //Peak will always be both (Start+End) /2, Added 2 to y to create a curvy peak
                Peak.transform.position = new Vector3((Start.transform.position.x + End.transform.position.x)/2,
                    (Start.transform.position.y + End.transform.position.y) / 2 +2, 0);

                //Increase score
                count++;
                Debug.Log("Correct button Pressed, Score:" + count);

                //Turn off the current picture
                currentButton.SetActive(false);

                //Randomize to next button
                randomNum = Random.Range(0, 6);
                Debug.Log(randomNum + " " + count);

                //Display random numbers button again
                switch (randomNum)
                {
                    //Random number is 0 therefore display A on screen
                    case 0:
                        currentButton = pictures[0];
                        currentButton.SetActive(true);
                        break;
                    //Random number is 1 therefore display B on screen
                    case 1:
                        currentButton = pictures[1];
                        currentButton.SetActive(true);
                        break;
                    //Random number is 2 therefore display X on screen
                    case 2:
                        currentButton = pictures[2];
                        currentButton.SetActive(true);
                        break;
                    //Random number is 3 therefore display Y on screen
                    case 3:
                        currentButton = pictures[3];
                        currentButton.SetActive(true);
                        break;
                    //Random number is 4 therefore display LB on screen
                    case 4:
                        currentButton = pictures[4];
                        currentButton.SetActive(true);
                        break;
                    //Random number is 5 therefore display RB on screen
                    case 5:
                        currentButton = pictures[5];
                        currentButton.SetActive(true);
                        break;
                }
            }

            //If they do not match 
            else if (buttonNum != randomNum)
            {
                Debug.Log("Curr num" + buttonNum);
                Debug.Log("Wrong button Pressed, Cooldown Started");
                //Wait current time +5 seconds
                nextPressTime = Time.time + cooldownTime;
            }
        }
    }

}
