using UnityEngine;

public class FirstRoomScript : MonoBehaviour
{
    public GameObject door;
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("Пластин нажато = " + PlateScript.pressCounter);
        if(PlateScript.pressCounter == 2)
        {
            Destroy(door);
            PlateScript.pressCounter = 0;
        }
    }
}
