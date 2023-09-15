using UnityEngine;

public class WeaponAiming : MonoBehaviour {
    public SpriteRenderer weaponSpriteRend;
    private float rotationSpeed = .175f;

    void FixedUpdate() {
        AimToCusor();
    }

    /// <summary>
    /// This method aims the object towards the cursor position
    /// </summary>
    private void AimToCusor() {
        //Get position of mouse in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle between the object and the mouse and smoothly rotates towards target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(angle) >= 120f)
        {
            weaponSpriteRend.flipY = true;
        } else {
            weaponSpriteRend.flipY = false;
        }




        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
        Debug.Log(transform.rotation);
    }
}