using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour
{
    public static DashSkill Skill;
    public bool RabbitActive;
    // Start is called before the first frame update
    void Start()
    {
        Skill = GetComponent<DashSkill>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RabbitActive = true;
            Destroy(gameObject);
        }
    }
}
