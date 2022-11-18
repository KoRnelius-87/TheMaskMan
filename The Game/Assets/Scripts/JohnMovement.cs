using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JohnMovement : MonoBehaviour
{
    public static JohnMovement Instance;
   
    private Animator Animator;

    [Header("Particulas")]
    public ParticleSystem Dust;

    [Header("Salto")]
    public bool Grounded;
    private bool DoubleJump;
    public float JumpForce;
    public float JumpForceTwo;

    [Header("movimiento")]
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    public float Speed;
    public float smooth;
    public Vector3 posicionInicial;
    public bool viewRight;
    public Joystick joystick;

    [Header("Dash")]
    public float DashDistance;
    float LastDash;

    void Start()
    {
        Instance = this;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        posicionInicial = transform.position;
        viewRight = true;
        
    }
    void Update()
    {
        Horizontal = joystick.Horizontal * Speed;

        transform.position += new Vector3(Horizontal, 0, 0) * Time.deltaTime;

        Animator.SetBool("Running", Horizontal != 0.0f);

        if (Grounded) DoubleJump = true;

    }
    private void FixedUpdate()
    {
        Move(Horizontal * Time.fixedDeltaTime);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f)) Grounded = true;
        else Grounded = false;

    }

    public void Move(float _move)
    {
        Vector3 GoalVelocity = new Vector2(_move, Rigidbody2D.velocity.y);
        Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, GoalVelocity, ref posicionInicial, smooth);

        if (_move > 0 && !viewRight)
        {
            Turn();
        }
        else if (_move < 0 && viewRight)
        {
            Turn();
        }
    }
    private void Turn()
    {
        viewRight = !viewRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
       
    }

    public void Dash()
    {
        if (DashSkill.Skill.RabbitActive &&  Time.time > LastDash + 2f)
        {
            transform.position += new Vector3(transform.localScale.x, 0, 0) * DashDistance;
            CreateDust();
            LastDash = Time.time;
        }
    }
    void CreateDust()
    {
        Dust.Play();
    }

    public void Jump()
    {
        if (Grounded)
        {
            StartCoroutine(JohnJump());
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
            SoundManagerScript.PlaySound("jump");
        }
        else if (DoubleJump && DoubleJumpScript.Skill.ToadActive)
        {
            Rigidbody2D.velocity = Vector2.zero;
            StartCoroutine(JohnJump());
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
            SoundManagerScript.PlaySound("jump");
            DoubleJump = false;
        }

    }
    private IEnumerator JohnJump()
    {
        Animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.4f);
        Animator.SetBool("Jump", false);
    }
  
}