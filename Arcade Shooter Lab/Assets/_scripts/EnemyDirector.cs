using UnityEngine;

public class EnemyDirector : MonoBehaviour
{
    public EnemyBuilder enemyBuilder;

    public float spawnInterval = 1.5f;
    public int maxEnemies = 5;
    public float spawnWidth = 6;
    public float[] spawnRows = { 2, 4, 6 };

    float spawnTime;
    int enemyCount;

    void OnEnable()
    {
        Enemy.OnEnemyHit += EnemyHit;
    }

    void OnDisable()
    {
        Enemy.OnEnemyHit -= EnemyHit;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }

        if (spawnTime <= 0 && enemyCount < maxEnemies)
        {
            float x = Random.Range(-spawnWidth, spawnWidth);
            float y = spawnRows[Random.Range(0, spawnRows.Length)];
            SpawnRandomEnemy(new Vector3(x, y, 0));
            enemyCount++;
            spawnTime = spawnInterval;
        }
    }

    void SpawnRandomEnemy(Vector3 position)
    {
        int type = Random.Range(0, 3);

        if (type == 0)
        {
            BuildSmallFast(position);
        }
        else if (type == 1)
        {
            BuildMedium(position);
        }
        else
        {
            BuildBigSlow(position);
        }
    }

    public Enemy BuildSmallFast(Vector3 position)
    {
        return enemyBuilder.SetSpeed(7).SetSize(0.5f).SetPoints(50).SetSprite(0).Build(position);
    }

    public Enemy BuildMedium(Vector3 position)
    {
        return enemyBuilder.SetSpeed(4).SetSize(1).SetPoints(20).SetSprite(1).Build(position);
    }

    public Enemy BuildBigSlow(Vector3 position)
    {
        return enemyBuilder.SetSpeed(2).SetSize(1.5f).SetPoints(10).SetSprite(2).Build(position);
    }

    void EnemyHit(int points)
    {
        enemyCount--;
    }
}