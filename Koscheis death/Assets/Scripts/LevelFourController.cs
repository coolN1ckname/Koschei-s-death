using UnityEngine;

public class LevelFourController : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Пластин нажато = " + PlateScript.pressCounter);
        if(PlateScript.pressCounter == 1)
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
