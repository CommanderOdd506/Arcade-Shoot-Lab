using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private int poolAmount = 30;

    [SerializeField] private GameObject poolParent;

    private Bullet[] bulletPool;

    private int poolIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletPool = new Bullet[poolAmount];
        for (int i = 0; i < bulletPool.Length; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab, poolParent.transform);
            newBullet.SetActive(false);
            Bullet bullet = newBullet.GetComponent<Bullet>();
            bulletPool[i] = bullet;
        }
    }

    public void SpawnBullet(Vector3 position)
    {
        Bullet spawnBullet = bulletPool[poolIndex];
        spawnBullet.transform.position = position;
        spawnBullet.gameObject.SetActive(true);
        spawnBullet.Initialize(poolIndex);
        poolIndex++;
        poolIndex %= poolAmount;
    }
}