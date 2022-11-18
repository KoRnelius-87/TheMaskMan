using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamageScript : MonoBehaviour
{
    //public GameObject JohnHealtBar;
    private Animator Animator;

    [Header("Vida")]
    public float JohnHealt;
    private float curHealt;
    public ParticleSystem Blood;

    [Header("Daño")]
    private float damage;
    [SerializeField] private SliderScript sliderScript;

    // Start is called before the first frame update
    void Start()
    {
        curHealt = JohnHealt;
        sliderScript.StartBar(curHealt);
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void JohnDead(bool set)
    {
        JohnMovement.Instance.Speed = 0;
        JohnMovement.Instance.JumpForce = 0;
        Animator.SetBool("isDead", set);
        SoundManagerScript.PlaySound("hurtJohn");
    }

    public void ReturnJohn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DamagePlayer(float damage)
    {
        curHealt -= damage;
        sliderScript.changeLife(curHealt);
        StartCoroutine(JohnHurt());
        Blood.Play();
        if (curHealt <= 0)
        {
            StartCoroutine(JohnDeadRoutine());
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("spikes"))
        {
            damage = 10;
            DamagePlayer(10);
            ScreenShakeController.Instance.Shake(0.9f, 0.4f);
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            damage = EnemyBulletScript.damage;
            DamagePlayer(damage);
        }

        if (collision.CompareTag("empty"))
        {
            curHealt = 0;
            StartCoroutine(JohnDeadRoutine());
        }

        if (collision.CompareTag("life") && curHealt < JohnHealt)
        {
            curHealt += 25;
            sliderScript.changeLife(curHealt);
        }

        if (collision.CompareTag("Crush"))
        {
            damage = 40;
            DamagePlayer(damage);
            ScreenShakeController.Instance.Shake(0.9f, 0.4f);
        }
    }

    // Routines
    private IEnumerator JohnHurt()
    {
        SoundManagerScript.PlaySound("hurtJohn");
        Animator.SetBool("hurt", true);
        yield return new WaitForSeconds(0.5f);
        Animator.SetBool("hurt", false);
    }
    private IEnumerator JohnDeadRoutine()
    {
        JohnDead(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");
    }
}
