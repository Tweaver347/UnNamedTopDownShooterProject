using UnityEngine;

public class SwapWeapons : MonoBehaviour
{
    // Weapon Sprite Prefabs
    [SerializeField] private GameObject assault;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject sniper;
    [SerializeField] private GameObject railgun;
    
    // Crosshair Spite Prefabs 
    [SerializeField] private GameObject arCross;
    [SerializeField] private GameObject shotCross;
    [SerializeField] private GameObject sniperCross;
    [SerializeField] private GameObject railCross;

    // Sprite Renderers for weapons and the crosshair
    [SerializeField] private SpriteRenderer weaponSpriteRend;
    [SerializeField] private SpriteRenderer crossSpriteRend; 

    void Update()   
    {
        ChangeWeapons();
    }

    private void ChangeWeapons()
    {
        switch (Input.inputString)
        {
            case "1":
                weaponSpriteRend.sprite = assault.GetComponent<SpriteRenderer>().sprite;
                crossSpriteRend.sprite = arCross.GetComponent<SpriteRenderer>().sprite;
                break;
            case "2":
                weaponSpriteRend.sprite = shotgun.GetComponent<SpriteRenderer>().sprite;
                crossSpriteRend.sprite = shotCross.GetComponent<SpriteRenderer>().sprite;
                break;
            case "3":
                weaponSpriteRend.sprite = sniper.GetComponent<SpriteRenderer>().sprite;
                crossSpriteRend.sprite = sniperCross.GetComponent<SpriteRenderer>().sprite;
                break;
            case "4":
                weaponSpriteRend.sprite = railgun.GetComponent<SpriteRenderer>().sprite;
                crossSpriteRend.sprite = railCross.GetComponent<SpriteRenderer>().sprite;
                break;
            default:
                break;
        }
    }
}
