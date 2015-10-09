using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour
{

    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                print("joystick button " + i);
            }
        }

    }
}
