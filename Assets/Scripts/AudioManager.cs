using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip otherClip;
    [SerializeField] private AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void ChangeAudioClip()
    {
        source.clip = otherClip;
    }
}
