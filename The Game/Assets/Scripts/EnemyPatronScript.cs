using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatronScript : MonoBehaviour
{
    public static EnemyPatronScript Instance;
    [SerializeField] public float Velocity;
    [SerializeField] private Transform GroundController;
    [SerializeField] private float Distance;
    [SerializeField] private bool Right ;

    private Rigidbody2D Rigidbody2D;

    private void Start()
    {
        Instance = this;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D Floor = Physics2D.Raycast(GroundController.position, Vector2.down, Distance);

        Rigidbody2D.velocity = new Vector2(Velocity, Rigidbody2D.velocity.y);

        if (Floor == false)
        {
            Turn();   
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")|| collision.gameObject.CompareTag("spikes"))
        {
            Turn();
        }
    }

    private void Turn()
    {
        Right = !Right;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        Velocity *= -1;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(GroundController.transform.position, GroundController.transform.position + Vector3.down * Distance);
    }
}
