using UnityEngine;

public class ShootWeapon : MonoBehaviour
{
    [SerializeField] private AudioClip assaultShoot;
    [SerializeField] private AudioClip shotgunShoot;
    [SerializeField] private AudioClip sniperShoot;
    [SerializeField] private AudioClip railgunShoot;

    [SerializeField] private AudioClip assaultReload;
    [SerializeField] private AudioClip shotgunReload;
    [SerializeField] private AudioClip sniperReload;

    [SerializeField] private GameObject assaultBullet;
    [SerializeField] private GameObject shotgunBullet;
    [SerializeField] private GameObject sniperBullet;
    [SerializeField] private GameObject railgunBullet;


    // 0 = No Weapon
    // 1 = AR
    // 2 = Shotgun
    // 3 = Sniper
    // 4 = Railgun
    public int weapon = 1;

    private float cooldownTime = .05f;
    private float timeUntilNextShot = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //check what weapon the player is using
        switch (Input.inputString)
        {
            case "1": // AR
                weapon = 1;
                cooldownTime = .05f;
                break;
            case "2": // Shotgun
                weapon = 2;
                cooldownTime = .5f;
                break;
            case "3": // Sniper
                weapon = 3;
                cooldownTime = 1f;
                break;
            case "4": // Railgun
                weapon = 4;
                cooldownTime = 2.5f;
                break;
        }

        // check if player can shoot
        if (timeUntilNextShot <= Time.time)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                switch (weapon)
                {
                    case 1:
                        audioSource.clip = assaultShoot;
                        break;
                    case 2:
                        audioSource.clip = shotgunShoot;
                        break;
                    case 3:
                        audioSource.clip = sniperShoot;
                        break;
                    case 4:
                        audioSource.clip = railgunShoot;
                        break;
                    default:
                        break;
                }
                SpawnBullet();
                audioSource.Play();
                timeUntilNextShot = Time.time + cooldownTime; // Fire Rate
            }
        }
    }

    /// <summary>
    /// instantiate bullet with movement towards raycast point
    /// </summary>
    private void SpawnBullet()
    {
        GameObject bulletPrefab = null;
        float bulletSpeed = 10f;

        // Select bullet prefab and speed based on weapon
        switch (weapon)
        {
            case 1:
                bulletPrefab = assaultBullet;
                bulletSpeed = 10;
                break;
            case 2:
                bulletPrefab = shotgunBullet;
                bulletSpeed = 10;
                break;
            case 3:
                bulletPrefab = sniperBullet;
                bulletSpeed = 10;
                break;
            case 4:
                bulletPrefab = railgunBullet;
                bulletSpeed = 10;
                break;
            default:
                break;
        }

        // Instantiate bullet and add force towards cursor position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, targetRotation);
        Rigidbody2D bulletRigidbody = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
}
