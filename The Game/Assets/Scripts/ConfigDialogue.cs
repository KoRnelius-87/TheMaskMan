using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class ConfigDialogue : ScriptableObject
{
    public CharacterDialogue[] Character;

    public float time = 0.1f;

    public KeyCode capSkip = KeyCode.Space;


}
