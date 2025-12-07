using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private float moveTime = 0.5f;
    private float timer = 0f;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
            CameraMove();
    }

    // Вызывается триггером комнаты
    public void MoveToPosition(Vector3 targetPosition)
    {
        // Эти переменные берутся из RoomEntranceScript.cs. Там есть прикол, с ним нужно быть внимательным
        startPos = transform.position; // Где камера сейчас
        endPos = targetPosition; // Куда нужно прийти
        
        timer = 0f;
        isMoving = true;
    }

    // Анимация передвижения камеры
    private void CameraMove()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / moveTime);

        transform.position = Vector3.Lerp(startPos, endPos, t);

        if (t >= 1f)
            isMoving = false;
    }
}

