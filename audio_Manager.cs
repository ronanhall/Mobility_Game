using UnityEngine.Audio;
using System;
using UnityEngine;

public class audio_Manager : MonoBehaviour
{
    public sound[] sounds;
    //an array of the sounds
    public float soundEffectsVolume;
    //the volume of the audio clips
    private static audio_Manager instance;
    //making the object an instance

    public static audio_Manager instance
    {
        get
        {
            return _instance;
        }
        //returning an _instance
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
                Destroy(gameObject);
        }
        //making the object an instance, see lines 39-41 on game_Manager script
        
        foreach (sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        //for every audio clip in the sound array, it adds an audio source, sets that source to be an auido clip so you can name it, and
        //controls the pitch of the sound and whether it loops
    }

    private void Update()
    {
        foreach (sound s in sounds)
        {
            s.source.volume = soundEffectsVolume;   
        }
        //setting the volume of the sounds to be the soundEffectsVolume, allowing it to be changed
    }

    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        //finding the sounds exact name
        if (s == null)
            return;
        //if the sound isn't there, the game isn't trying to play it
        s.source.Play();
        //if it is, it plays the sound
    }

    public void StopPlaying(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        //finding the osunds exact name
        if (s == null)
            return;
        //if the sound isn't there, the game isn't trying to play it
        s.source.Stop();
        //if it is, it stops the sound
    }
}
