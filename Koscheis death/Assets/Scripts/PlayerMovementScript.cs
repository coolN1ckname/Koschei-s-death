using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMovementScript : MonoBehaviour
{

private float moveTime = 0.1f;
private float moveCoolDown = 0.25f;
private bool isMoving = false;

//Анимация передвижения
private Vector3 startPos;
private Vector3 endPos;
private float timer = 0f;

    void Update()
    {
        if(!isMoving)
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                direction = new Vector3(0,1,0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction = new Vector3(-1,0,0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction = new Vector3(0,-1,0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = new Vector3(1,0,0);
            }

            if(direction != Vector3.zero)
            {
                Move(direction);
            }
        }
        else
        {
            AnimateMove();
        }
    }

    void Move(Vector3 direction)
    {
        isMoving = true;
        timer = 0f;

        startPos = transform.position;
        endPos = transform.position + direction;
    }

    void AnimateMove()
    {
        timer += Time.deltaTime;
        float percentageComplete = timer / moveTime;

        transform.position = Vector3.Lerp(startPos,endPos,percentageComplete);

        if (percentageComplete >= 1 && timer >= moveCoolDown)
        {
            isMoving = false;
        }
    }
}