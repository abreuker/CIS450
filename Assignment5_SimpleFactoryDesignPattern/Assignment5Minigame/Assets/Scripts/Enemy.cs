using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float scoreValue;
    public float speed;
    public Rigidbody2D body;

    public GameManager gameManager;

    public void Start()
    {
        Shoot();
        body = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.isGameActive)
        {
            Move();
        }
    }

    public abstract void Move();
    public abstract void Die();

    public abstract void Shoot();
}
