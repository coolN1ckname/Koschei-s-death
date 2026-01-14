using UnityEngine;

public class RoomThreeController : MonoBehaviour
{

    public GameObject door2;
    public GameObject hardObstacle;

    void Update()
    {
        Debug.Log("Пластин нажато = " + PlateScript.pressCounter);
        if(PlateScript.pressCounter == 0)
        {
            Destroy(door2);
        }
        if(PlateScript.pressCounter == 3)
        {
            Destroy(hardObstacle);
            PlateScript.pressCounter = 0;
        }
    }
}
