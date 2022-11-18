using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionScript : MonoBehaviour
{
    public GameObject BulletPrefab;

    Animator Destruction;

    public float Health;
    public float animDelay;

    private float TotalHealth;

    [SerializeField] private float Force;
    [SerializeField] private float Radio;

    [Header("Particulas")]
    public ParticleSystem Explosion;


    private void Start()
    {
        TotalHealth = Health;
        Destruction = GetComponent<Animator>();
    }

    void DestroyPromp(bool set)
    {
        Explosion.Play();
        Destruction.SetBool("explosion", set);
        SoundManagerScript.PlaySound("explosion");
        Destroy(gameObject, animDelay);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            TotalHealth -= BulletScript.damage;
            _ = TotalHealth / Health;
            if (TotalHealth <= 0)
            {
                DamageExplosion();
                DestroyPromp(true);
                ScreenShakeController.Instance.Shake(0.9f,0.4f);
            }
        }
    }

    public void DamageExplosion()
    {
      Collider2D[] initialObjects = Physics2D.OverlapCircleAll(transform.position,Radio);

        foreach (Collider2D collider in initialObjects)
        {
            BoxScript box = collider.GetComponent<BoxScript>();
            if(box != null)
            {
                StartCoroutine(box.BoxDestructionRoutine());
            }
        }

        Collider2D[] allObjects = Physics2D.OverlapCircleAll(transform.position, Radio);

        foreach (Collider2D Object in allObjects)
        {
            Rigidbody2D rigidbody2D = Object.GetComponent<Rigidbody2D>();

            if(rigidbody2D != null)
            {
                Vector2 direction = Object.transform.position - transform.position;
                float distance = 1 + direction.magnitude;
                float finalForce = Force / distance;
                rigidbody2D.AddForce(direction * finalForce);
            }
            if (Object.gameObject.CompareTag("enemy"))
            {
                DestroyPromp(true);
                Object.gameObject.GetComponent<GruntScript>().EnemyDestroy(true);
            }
            if (Object.gameObject.CompareTag("box"))
            {
                BoxScript box = Object.GetComponent<BoxScript>();
                StartCoroutine(box.BoxDestructionRoutine());
            }

        }
    }
}
