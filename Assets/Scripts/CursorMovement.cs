using UnityEngine;

public class CursorMovement: MonoBehaviour
{
    void Update()
    {
        MoveToCusor();
    }

    /// <summary>
    /// Moves the attahed object to the players cursour
    /// </summary>
    private void MoveToCusor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;

    }
}
