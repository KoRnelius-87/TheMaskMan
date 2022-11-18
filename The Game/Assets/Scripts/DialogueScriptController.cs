using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScriptController : MonoBehaviour
{
    public static DialogueScriptController MainInstance;
    public GameObject dialogue;
    public Text Dialoguetext;

    public Image imgFace;
    public Phrases[] phrases;
    public ConfigDialogue configuration;

    public void Awake()
    {
        if(MainInstance == null)
        {
            MainInstance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    void Start()
    {
        dialogue.SetActive(false);
    }

    public IEnumerator Speak(Phrases[] _phrases)
    {
        dialogue.SetActive(true);
        for (int i = 0; i < _phrases.Length; i++)
        {
            Dialoguetext.text = "";
            imgFace.sprite = configuration.Character[_phrases[i].character].GetCharacter(0);
            for (int j = 0; j < _phrases[i].text.Length + 1; j++)
            {
                
                yield return new WaitForSeconds(configuration.time);
                if (Input.GetKey(configuration.capSkip))
                {
                    j = _phrases[i].text.Length;

                }
                Dialoguetext.text = _phrases[i].text.Substring(0, j);
                SoundManagerScript.PlaySound("speak");

                if (j < _phrases[i].text.Length) imgFace.sprite = configuration.Character[_phrases[i].character].GetCharacter(_phrases[i].text[j].ToString().ToUpper());

            }

            Dialoguetext.text = _phrases[i].text;

            yield return new WaitForSeconds(0.5f);
         //   yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));  
        }

        dialogue.SetActive(false);
    }
   
}

[System.Serializable]
public class Phrases 
{
    public string text;
    public int character;
}

[System.Serializable]
public class DialogueState
{
    public Phrases[] phrase;
}

// Animacion de personaje en dialogos
[System.Serializable]
public class Charaters
{
    public string letter;
    public Sprite character;

}
[System.Serializable]
public class CharacterDialogue
{
    public Charaters[] Faces;

    public Sprite GetCharacter(string l)
    {
        int index = 0;

        for (int i = 0; i < Faces.Length; i++)
        {
            if(Faces[i].letter == l)
            {
                index = i;
                break;
            }
        }
        return Faces[index].character;
    }

    public Sprite GetCharacter(int i)
    {
        i = Mathf.Clamp(i, 0, Faces.Length - 1);
        return (Faces[i].character);
    }
}