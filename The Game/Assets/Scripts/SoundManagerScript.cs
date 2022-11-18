using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip JumpSound, explosionSound, FireSound, HurtJohnSound, SpeakSound, CoinSound,enemyHurt;
    static AudioSource AudioSrc;
    void Start()
    {
        JumpSound =Resources.Load<AudioClip>("jump");
        explosionSound = Resources.Load<AudioClip>("explosion");
        FireSound = Resources.Load<AudioClip>("fire");
        HurtJohnSound = Resources.Load<AudioClip>("hurtJohn");
        SpeakSound = Resources.Load<AudioClip>("speak");
        CoinSound = Resources.Load<AudioClip>("coin");
        enemyHurt = Resources.Load<AudioClip>("enemyHurt");

        AudioSrc = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fire":
                AudioSrc.PlayOneShot(FireSound);
                break;
            case "jump":
                AudioSrc.PlayOneShot(JumpSound);
                break;
            case "hurtJohn":
                AudioSrc.PlayOneShot(HurtJohnSound);
                break;
            case "explosion":
                AudioSrc.PlayOneShot(explosionSound);
                break;
            case "speak":
                AudioSrc.PlayOneShot(SpeakSound);
                break;
            case "coin":
                AudioSrc.PlayOneShot(CoinSound);
                break;
            case "enemyHurt":
                AudioSrc.PlayOneShot(enemyHurt);
                break;

        }
    }

}
