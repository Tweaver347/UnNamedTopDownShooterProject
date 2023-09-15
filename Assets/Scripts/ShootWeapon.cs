using System.Collections;
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
    public float bulletSpeed = 10f;
    private int shotgunPellets = 5;

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
                        StartCoroutine(FullAuto());
                        timeUntilNextShot = Time.time + cooldownTime; 

                        break;
                    case 2:
                        audioSource.clip = shotgunShoot;

                        shotgunSpread(shotgunPellets, shotgunBullet);

                        audioSource.Play();
                        timeUntilNextShot = Time.time + cooldownTime;

                        break;
                    case 3:
                        audioSource.clip = sniperShoot;
                        SpawnBullet();
                        audioSource.Play();
                        timeUntilNextShot = Time.time + cooldownTime;

                        break;
                    case 4:

                        audioSource.clip = railgunShoot;
                        audioSource.Play();
                        StartCoroutine(WaitAndSpawnBullet());
                        timeUntilNextShot = Time.time + cooldownTime;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    IEnumerator WaitAndSpawnBullet()
    {
        yield return new WaitForSeconds(1.25f); // Wait for 2 seconds
        SpawnBullet();
    }

    IEnumerator FullAuto()
    {
         AudioSource audioSource = GetComponent<AudioSource>();
        while (Input.GetMouseButton(0))
        {

           audioSource.clip = assaultShoot;
           SpawnBullet();
           audioSource.Play();
           yield return new WaitForSeconds(0.1f); // Set the interval between shots here
        }
    }
    /// <summary>
    /// Spawns N Number of bullets in a random spread 
    /// </summary>
    private void shotgunSpread(int n, GameObject bulletPrefab)
    {
        float spread = 35f; // The angle of the spread in degrees
        float bulletSpeed = 8.5f; // The speed of the bullets

        for (int i = 0; i < n; i++)
        {
            // Calculate the angle of the bullet
            float angle = transform.eulerAngles.z - spread / 2 + Random.Range(0f, 1f) * spread;

            // Spawn the bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, angle));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = bullet.transform.right * bulletSpeed;
        }
    }




    /// <summary>
    /// instantiate bullet with movement towards raycast point
    /// </summary>
    private void SpawnBullet()
    {
        GameObject bulletPrefab = null;

        // Select bullet prefab and speed based on weapon
        switch (weapon)
        {
            case 1:
                bulletPrefab = assaultBullet;
                bulletSpeed = 10f;
                break;
            case 3:
                bulletPrefab = sniperBullet;
                bulletSpeed = 20f;
                break;
            case 4:
                bulletPrefab = railgunBullet;
                bulletSpeed = 15f;
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
        bulletRigidbody.velocity = bulletInstance.transform.right * bulletSpeed;
    }
}
