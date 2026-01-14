using UnityEngine;

public class RoomEntranceScript : MonoBehaviour
{
    public CameraScript cameraScript;

    // ВСЕ ЭТИ ВЕКТОРЫ УКАЗЫВАЮТСЯ ВРУЧНУЮ ДЛЯ КАЖДОГО ЭЛЕМЕНТА ROOM ENTRANCE. ОСЬ Z ВСЕГДА ДОЛЖНА БЫТЬ -10 
    public Vector3 leftTargetPosition;
    public Vector3 rightTargetPosition;
    public Vector3 topTargetPosition;
    public Vector3 downTargetPosition;

    void Awake()
    {
        if (cameraScript == null)
            cameraScript = FindFirstObjectByType<CameraScript>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Определяем направление входа
        Vector2 direction = other.transform.position - transform.position;

        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                cameraScript.MoveToPosition(leftTargetPosition); // При движении слева-направо
            }
            else
            {
                cameraScript.MoveToPosition(rightTargetPosition); // при движении справа-налево
            }
        }
        else
        {
            if(direction.y > 0)
            {
                cameraScript.MoveToPosition(downTargetPosition); // при движении Сверху-вниз
            }
            else
            {
                cameraScript.MoveToPosition(topTargetPosition); // при движении снизу-вверх
            }
        }

    }
}
