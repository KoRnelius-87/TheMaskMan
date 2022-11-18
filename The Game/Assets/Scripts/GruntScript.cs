using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public static GruntScript Instance;
    public GameObject EnemyBulletPrefab;
    public GameObject HealtBar;
    Animator enemyDeath;

    [Header("Particulas")]
    public ParticleSystem Blood;

    [Header("Vida")]
    public float enemyHealt;
    private float curHealt;

    [Header("Disparo")]
    private float LastShoot;
   

    private void Start()
    {
        curHealt = enemyHealt;
        enemyDeath = GetComponent<Animator>();
        Instance = this;
    }

    void Update()
    {
        if (Time.time > LastShoot + 1.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (EnemyPatronScript.Instance.Velocity > 0) direction = Vector3.right;
        else if(EnemyPatronScript.Instance.Velocity < 0) direction = Vector3.left;
        else direction = Vector3.zero;

        GameObject bullet = Instantiate(EnemyBulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<EnemyBulletScript>().SetDirection(direction);
        Destroy(bullet, 1f);
    }

   public void EnemyDestroy(bool set)
    {
        enemyDeath.SetBool("IsDead", set);
        ScreenShakeController.Instance.Shake(0.9f, 0.4f);
        SoundManagerScript.PlaySound("explosion");
        Destroy(gameObject, 0.6f);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Bullet"))
        {
            SoundManagerScript.PlaySound("enemyHurt");
            CreateBlood();
            curHealt -= BulletScript.damage;
            float barLenght = curHealt / enemyHealt;
            SetHealtBar(barLenght);
            if (curHealt <= 0)
            {     
                EnemyDestroy(true);                
            }
        }

        if (collider.CompareTag("empty"))
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("spikes"))
        {
            EnemyDestroy(true);
        }

    }
    void CreateBlood()
    {
        Blood.Play();
    }

    public void SetHealtBar(float healt)
    {
        if (healt >= 0)
        {
            HealtBar.transform.localScale = new Vector3(healt, HealtBar.transform.localScale.y, HealtBar.transform.localScale.z);
        }
    }
}
