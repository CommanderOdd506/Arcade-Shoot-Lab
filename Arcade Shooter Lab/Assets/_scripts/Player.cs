using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveRange = 8;
    private float moveSpeed = 3;
    public float rpm = 160;

    public BulletPool bulletPool;

    public Transform rightSpawn;
    public Transform leftSpawn;

    bool rightShoot;
    float fireTime;
    Vector3 activeSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, -moveRange, moveRange);
        transform.position = pos;

        if (fireTime > 0)
        {
            fireTime -= Time.deltaTime;
        }
        else if (fireTime < 0)
        {
            fireTime = 0;
        }


        if (Input.GetKey(KeyCode.Space) && fireTime <= 0)
        {
            Debug.Log("Fire");
            activeSpawn = rightShoot ? rightSpawn.position : leftSpawn.position;
            bulletPool.SpawnBullet(activeSpawn);
            rightShoot = !rightShoot;
            fireTime = 60 / rpm;
        }

    }
}