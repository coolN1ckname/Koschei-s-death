using UnityEngine;

public class FirstRoomScript : MonoBehaviour
{
    public GameObject door;
    void Start()
    {
        
    }

    void Update()
    {
        if(PlateScript.pressCounter == 2)
        {
            Destroy(door);
        }
    }
}
