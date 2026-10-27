using UnityEngine;

public class EnemyBuilder : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public Sprite[] enemySprites;

    private float speed = 3;
    private float size = 1;
    private int points = 10;
    private int spriteIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public EnemyBuilder SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        return this;
    }

    public EnemyBuilder SetSize(float newSize)
    {
        size = newSize;
        return this;
    }

    public EnemyBuilder SetPoints(int newPoints)
    {
        points = newPoints;
        return this;
    }

    public EnemyBuilder SetSprite(int newSpriteIndex)
    {
        spriteIndex = newSpriteIndex;
        return this;
    }

    public Enemy Build(Vector3 position)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        newEnemy.transform.localScale = Vector3.one * size;
        newEnemy.GetComponent<SpriteRenderer>().sprite = enemySprites[spriteIndex];

        Enemy enemy = newEnemy.GetComponent<Enemy>();
        enemy.Initialize(speed, points);

        ResetBuilder();
        return enemy;
    }

    private void ResetBuilder()
    {
        speed = 3;
        size = 1;
        points = 10;
        spriteIndex = 0;
    }
}