using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    public static int damage;
    public int damageReference;

    void Awake()
    {
        damage = damageReference;
    }

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SoundManagerScript.PlaySound("fire");

    }

    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestroyBullet();
        }
        if (collision.CompareTag("empty"))
        {
            Destroy(gameObject);
        }

    }




}
