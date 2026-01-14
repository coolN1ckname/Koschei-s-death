using UnityEngine;

public class SecondRoomScript : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;



    void Update()
    {
        Debug.Log("Пластин нажато = " + PlateScript.pressCounter);
        if(PlateScript.pressCounter == 0)
        {
            Destroy(door1);
        }

        if(PlateScript.pressCounter == 3)
        {
            Destroy(door2);
            PlateScript.pressCounter = 0;
        }
    }
}
