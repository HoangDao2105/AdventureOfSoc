using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip collect, attack, destroy;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        collect = Resources.Load<AudioClip>("Game coin");
        attack = Resources.Load<AudioClip>("Sword");
        destroy= Resources.Load<AudioClip>("Rock Crash");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "collect":
                audioSource.clip = collect;
                audioSource.PlayOneShot(collect,0.6f);
                break;
            case "attack":
                audioSource.clip = attack;
                audioSource.PlayOneShot(attack, 0.6f);
                break;
            case "destroy":
                audioSource.clip = destroy;
                audioSource.PlayOneShot(destroy, 0.6f);
                break;
            default:
                break;
        }
    }
}
