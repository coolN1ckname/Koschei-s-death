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
[SerializeField]
public static Vector3 lastDirection;
[SerializeField]
public static Vector3 faceDirection;
[SerializeField]
public static Vector3 rotationDirection;

//Анимация передвижения
private Vector3 startPos;
private Vector3 endPos;
private float timer = 0f;

public LayerMask wallLayer;

    void Update()
    {

        if(!isMoving)
        {
            Vector3 direction = Vector3.zero;
            Vector3 rotation = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                direction = new Vector3(0,1,0);
                rotation = new Vector3(0,0,90);
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction = new Vector3(-1,0,0);
                rotation = new Vector3(0,0,180);
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction = new Vector3(0,-1,0);
                rotation = new Vector3(0,0,270);
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = new Vector3(1,0,0);
                rotation = new Vector3(0,0,0);
            }

            if(direction != Vector3.zero)
            {
                Move(direction, rotation);
            }
        }
        else
        {
            AnimateMove();
        }
    }

    // Расчёт физических ккоординат игрока
    void Move(Vector3 direction, Vector3 rotation)
    {
        Vector3 targetPos = transform.position + direction;
        if(Physics2D.OverlapCircle(targetPos, 0.1f, wallLayer)) //Ограничение, чтобы нельзя было пройти в сетну
        {
            return; // Выходим из метода, если есть попытка оверлапнуться на стенку 
        }

        isMoving = true;
        timer = 0f;

        startPos = transform.position;
        endPos = transform.position + direction;
        faceDirection = direction; // для PlayerController.cs
        transform.rotation = Quaternion.Euler(rotation); //Поворот персонажа при изменении направления движения
    }

    //Плавное передвижение игрока
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