using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] AudioClip[] Clips;
    public static SoundManager instance;
    public void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    public enum sounds
    {
        collect
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void PlaySound(sounds sound)
    {
        audio.PlayOneShot(Clips[(int)sound]);
    }
}
