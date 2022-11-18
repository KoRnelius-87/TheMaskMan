using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformScript : MonoBehaviour
{
    [SerializeField]
    private float Wait;
    [SerializeField]
    private float ResetPlatform;
    [SerializeField]
    private GameObject Platform;
    [SerializeField]
    private float margin;

    private Rigidbody2D Rigidbody2D;
    Animator animator;
    private Vector3 OriginalPosition;
    private SpriteRenderer sprite;

    private bool move;
    private float shake = 0.002f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        OriginalPosition = transform.position;
        sprite = Platform.GetComponent<SpriteRenderer>();
    }
    void Update() 
    {
        if (move)
        {
            transform.position = new Vector3(transform.position.x + shake, transform.position.y, transform.position.z);
            if (transform.position.x >= OriginalPosition.x + margin || transform.position.x <= OriginalPosition.x - margin) shake *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("contact", true);
            Invoke(nameof(FallingPlatform), Wait);
            Invoke(nameof(Reset), ResetPlatform);
            move = true;
        }
    }

    private void FallingPlatform()
    {
        Rigidbody2D.isKinematic = false;
    }

    private void Reset()
    {
        move = false;
        Rigidbody2D.velocity = Vector3.zero;
        Rigidbody2D.isKinematic = true;
        transform.position = OriginalPosition;
        Color c1 = sprite.material.color;
        c1.a = 0f;
        sprite.material.color = c1;

        StartCoroutine(nameof(FadeIn));
    }

    IEnumerator FadeIn()
    {
        for (float i = 0; i <= 1 ; i+= 0.1f)
        {
            Color c1 = sprite.material.color;
            c1.a = i;
            sprite.material.color = c1;
            yield return new WaitForSeconds(0.050f);
        }
    }
}
