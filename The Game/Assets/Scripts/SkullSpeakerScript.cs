using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullSpeakerScript : MonoBehaviour
{
    public DialogueState[] states;
    public int Actualstate = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                StartCoroutine(DialogueScriptController.MainInstance.Speak(states[Actualstate].phrase));
        }              
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
        DialogueScriptController.MainInstance.dialogue.SetActive(false);
    }
}
