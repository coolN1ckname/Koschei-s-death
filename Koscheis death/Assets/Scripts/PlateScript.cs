using System;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public static int pressCounter = 0;

    void Start()
    {
        pressCounter = 0;
    }

    private bool isPressed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && !isPressed)
        {
            isPressed = true;
            pressCounter++;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && isPressed)
        {
            isPressed = false;
            pressCounter--;
        }
    }
}

