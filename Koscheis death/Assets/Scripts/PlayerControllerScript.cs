using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public LayerMask wallLayer;
    public Transform handPoint;
    private GameObject heldObject;
    private Vector3 faceDirection;
    private Vector3 rotationDirection;
    private Vector3 frontCell;
    // СКРИПТ ДЛЯ ВЗАИМОДЕЙСТВИЯ С ПРЕДМЕТАМИ. КРАСНЫЕ ЯЩИКИ МОЖНО БРАТЬ И НОСИТЬ С СОБОЙ

    void Update()
    {
        faceDirection = PlayerMovementScript.faceDirection;

        frontCell = transform.position + faceDirection;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(heldObject == null)
            {
                TryPickUp(frontCell);
            }
            else
            {
                TryToDrop(frontCell);
            }
        }
    }

    void TryPickUp(Vector3 frontCell)
    {
        Collider2D col = Physics2D.OverlapCircle(frontCell, 0.15f, obstacleLayer);
        if (col != null)
        {
            heldObject = col.gameObject;

            Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.simulated = false;
            }
            heldObject.transform.SetParent(handPoint);
            heldObject.transform.localPosition = Vector3.zero;
            Debug.Log("Предмет поднят");
        }
    }

    void TryToDrop(Vector3 frontCell)
    {
        if(Physics2D.OverlapCircle(frontCell, 0.1f, wallLayer) || Physics2D.OverlapCircle(frontCell, 0.1f, obstacleLayer))
        {
            Debug.Log("Здесь нельзя попустить предмет");
        }
        else
        {
            heldObject.transform.SetParent(null);

            Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.simulated = true;
            }
            heldObject.transform.position = frontCell;
            Debug.Log("Предмет попущен");
            heldObject = null;
        }
    }
}

