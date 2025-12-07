using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneController.instance.LoadNextScene();
            Destroy(gameObject);
        }
    }
}
