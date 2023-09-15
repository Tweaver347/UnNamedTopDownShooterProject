using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collider2D collider)
    {
            Destroy(gameObject);
    }
}
