using Unity.VisualScripting;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
    }
}
