using UnityEngine;

public class WeaponAiming : MonoBehaviour {
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject weapon;
    private float rotationSpeed = .1f;

    void FixedUpdate() {
        AimToCusor();
    }
    /// <summary>
    /// rotates the characters gun towards the players cursor
    /// </summary>
    private void AimToCusor() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePosition);
        if(character.transform.localScale.x == -1)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -1;
            transform.localScale = newScale;
        } else
        {
            Vector3 newScale = transform.localScale;
            newScale.x = 1;
            transform.localScale = newScale;
        }
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);  
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
    }
}