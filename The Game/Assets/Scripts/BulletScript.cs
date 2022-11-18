using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    public static int damage;
    public int damageReference;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        damage = damageReference;
    }

    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") || collision.CompareTag("barrel")|| collision.CompareTag("box"))
        {
            DestroyBullet();
        }
        
    }
}
