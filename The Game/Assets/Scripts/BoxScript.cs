using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    Animator box;
    [SerializeField] private GameObject BrokenBox;

    private void Start()
    {
        box = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {

            StartCoroutine(BoxDestructionRoutine());
        }
    }


    public IEnumerator BoxDestructionRoutine()
    {
        box.SetBool("broken", true);
        yield return new WaitForSeconds(0.2f);
        Instantiate(BrokenBox, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
