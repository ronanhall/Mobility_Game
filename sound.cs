using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class sound
{
    public string name;
    //the name of the desired sound effect
    public AudioClip clip;
    //reference to the audio clip
    
    [Range(0f, 1f)]
    public float volume;
    //reference to the volume of the sound
    
    [Range(0.1f, 3f)]
    public float pitch;
    //reference to the pitch of the sound

    public bool loop;

    [HideInInspector]
    public AudioSource source;
    //

}
