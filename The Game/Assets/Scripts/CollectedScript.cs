using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedScript : MonoBehaviour
{
    [SerializeField] private float ScoreQuantity;
    [SerializeField] private ScoreScript ScoreScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreScript.Score(ScoreQuantity);
            GetComponent<SpriteRenderer>().enabled = false;
            SoundManagerScript.PlaySound("coin");
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject,0.2f);
        }
    }
}
