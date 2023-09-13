using UnityEngine;

public class CursorMovement: MonoBehaviour
{
    [SerializeField] private GameObject arCross;
    [SerializeField] private GameObject shotCross;
    [SerializeField] private GameObject sniperCross;
    [SerializeField] private GameObject railCross;

    private SpriteRenderer spriteRend;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.sprite = arCross.GetComponent<SpriteRenderer>().sprite;
    }

    void FixedUpdate()
    {
        switch (Input.inputString)
        {
            case "1":
                spriteRend.sprite = arCross.GetComponent<SpriteRenderer>().sprite;
                break;
            case "2":
                spriteRend.sprite = shotCross.GetComponent<SpriteRenderer>().sprite;
                break;
            case "3":
                spriteRend.sprite = sniperCross.GetComponent<SpriteRenderer>().sprite;
                break;
            case "4":
                spriteRend.sprite = railCross.GetComponent<SpriteRenderer>().sprite;
                break;
            default:
                break;
        }
        MoveToCusor();
    }

    private void MoveToCusor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;

    }
}
