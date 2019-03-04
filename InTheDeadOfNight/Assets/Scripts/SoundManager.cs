using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Attack, Battery, Critical, NewGame, Death;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        Attack = Resources.Load<AudioClip> ("Attack");
        Battery = Resources.Load<AudioClip> ("Battery");
        NewGame = Resources.Load<AudioClip> ("NewGame");
        Critical = Resources.Load<AudioClip> ("Critical");
        Death = Resources.Load<AudioClip> ("Death");
        NewGame = Resources.Load<AudioClip> ("NewGame");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip) {
        case "Attack":
            audioSrc.PlayOneShot (Attack);
            break;
        case "Battery":
            audioSrc.PlayOneShot (Battery);
            break;
        case "Critical":
            audioSrc.PlayOneShot (Critical);
            break;
        case "NewGame":
            audioSrc.PlayOneShot (NewGame);
            break;
        case "Death":
            audioSrc.PlayOneShot (Death);
            break;
        }
    }

}
