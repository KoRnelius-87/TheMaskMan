using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [Header("Disparo")]
    private float LastShoot;

    public GameObject Bullet;
    public GameObject Laser;
    private GameObject SelectGun;
    Vector3 direction;

    private void Start()
    {
        SelectGun = Bullet;
    }
    public void Shoot()
    {

        if (Time.time > LastShoot + 0.25f)
        {
            if (transform.localScale.x == 1.0f) direction = Vector2.right;
            else direction = Vector2.left;

            GameObject bullet = Instantiate(SelectGun, transform.position + direction * 0.1f, Quaternion.identity); ;
            bullet.GetComponent<BulletScript>().SetDirection(direction);
            LastShoot = Time.time;
        }

        if (SelectGun == Bullet)
        {
            SoundManagerScript.PlaySound("fire");
        }
        else if (SelectGun == Laser)
        {
            SoundManagerScript.PlaySound("coin");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser")) SelectGun = Laser;

    }
}
