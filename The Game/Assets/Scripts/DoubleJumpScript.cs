using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpScript : MonoBehaviour
{
    public static DoubleJumpScript Skill;
    public bool ToadActive;

    // Start is called before the first frame update
    void Start()
    {
        Skill = GetComponent<DoubleJumpScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ToadActive = true;
            GetComponent<SpriteRenderer>().enabled = false;
            SoundManagerScript.PlaySound("coin");
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject,0.1f);
        }
    }
}
