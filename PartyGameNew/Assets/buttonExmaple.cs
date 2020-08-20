using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class buttonExmaple : MonoBehaviour {

    //Array of gamepad buttons { A, B, X, Y, L1, R1}
    string[] joystickArray = new string[]{"Joystick Button 0", "Joystick Button 1", "Joystick Button 2",
    "Joystick Button 3","Joystick Button 4","Joystick Button 5"};
    string[] ex = new string[] { "1", "2", "3", "4" };

    System.Random r = new System.Random();

    //Array of gamepad pictures
    public GameObject[] buttonPics = new GameObject[] { };

    //Current picture being displayed
    public GameObject currentButton;

    //Button being used
    private Button button;



    int count = 0;

    private void Awake()
    {
        //Get current button
        button = GetComponent<Button>();

        //Randomize array
        joystickArray = joystickArray.OrderBy(x => r.Next()).ToArray();
        //Display first button
        switch (joystickArray[0])
        {
            //If first position is A
            case "Joystick Button 0":
                //Set current picture to A
                currentButton = buttonPics[0];
                //Show button on screen
                currentButton.SetActive(true);
                break;

            case "Joystick Button 1":
                currentButton = buttonPics[1];
                currentButton.SetActive(true);
                break;

            case "Joystick Button 2":
                currentButton = buttonPics[2];
                currentButton.SetActive(true);
                break;

            case "Joystick Button 3":
                currentButton = buttonPics[3];
                currentButton.SetActive(true);
                break;

            case "Joystick Button 4":
                currentButton = buttonPics[4];
                currentButton.SetActive(true);
                break;

            case "Joystick Button 5":
                currentButton = buttonPics[5];
                currentButton.SetActive(true);
                break;
        }

        Debug.Log(joystickArray[0]);
    }


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        //If they press the correct button, first button in array
        if (Input.GetButtonDown(joystickArray[0]))
        {
            //Turn off the current picture
            currentButton.SetActive(false);

            count++;
            //Press button
            button.onClick.Invoke();

            Debug.Log("Pressed " + count);
            
            //Randomize array again
            joystickArray = joystickArray.OrderBy(x => r.Next()).ToArray();
            Debug.Log(joystickArray[0] + " " + count);

            //Display next button and set it as active
            switch (joystickArray[0])
            {
                case "Joystick Button 0":
                    currentButton = buttonPics[0];
                    currentButton.SetActive(true);
                    break;

                case "Joystick Button 1":
                    currentButton = buttonPics[1];
                    currentButton.SetActive(true);
                    break;

                case "Joystick Button 2":
                    currentButton = buttonPics[2];
                    currentButton.SetActive(true);
                    break;

                case "Joystick Button 3":
                    currentButton = buttonPics[3];
                    currentButton.SetActive(true);
                    break;

                case "Joystick Button 4":
                    currentButton = buttonPics[4];
                    currentButton.SetActive(true);
                    break;

                case "Joystick Button 5":
                    currentButton = buttonPics[5];
                    currentButton.SetActive(true);
                    break;
            }
        }
    }

}
