using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour {
    private static GameSound instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        sound = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    private AudioSource sound;

    public static void Play(AudioClip clip)
    {
        instance.sound.PlayOneShot(clip);
    }
}
