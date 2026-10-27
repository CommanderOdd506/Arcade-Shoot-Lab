using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<int> OnEnemyHit;

    public float moveRange = 8;
    private float moveSpeed = 3;
    private int pointValue = 10;

    private Vector3 moveDirection = Vector3.right;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void Initialize(float speed, int points)
    {
        moveSpeed = speed;
        pointValue = points;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > moveRange)
        {
            moveDirection = Vector3.left;
        }
        else if (transform.position.x < -moveRange)
        {
            moveDirection = Vector3.right;
        }

        transform.position += moveSpeed * moveDirection * Time.deltaTime;
    }

    public void Hit()
    {
        OnEnemyHit?.Invoke(pointValue);
        Destroy(gameObject);
    }
}