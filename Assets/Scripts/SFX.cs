using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource soundPlayer;

    public void playSound()
    {
        soundPlayer.Play();
    }
}
