using System;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public static int pressCounter = 0;
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Debug.Log("Пластина нажата объектом: " + collision.name);

            pressCounter++;
            return;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Объект ушёл с пластины: " + collision.name);

            pressCounter--;
            return;
        }
    }
}
