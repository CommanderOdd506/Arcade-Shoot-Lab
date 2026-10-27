using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float LifeTime = 10;

    private float currentLifeTime;
    private int poolIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void Initialize(int index)
    {
        poolIndex = index;
        currentLifeTime = LifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = transform.position.y + speed * Time.deltaTime;
        transform.position = pos;

        currentLifeTime -= Time.deltaTime;

        if (currentLifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.Hit();
            gameObject.SetActive(false);
        }
    }
}