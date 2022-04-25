using UnityEngine.Audio;
using System;
using UnityEngine;

public class audio_Manager : MonoBehaviour
{
    public sound[] sounds;
    //an array of the sound script

    public static audio_Manager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);

        foreach (sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        //
    }

    private void Start()
    {
        Play("Music");
    }

    public void Play (string name)
    {
        sound s  = Array.Find(sounds, sound => sound.name == name);
        //
        if (s == null)
            return;
        //if the sound isn't there, the game isn't trying to play it
        s.source.Play();
    }

}
