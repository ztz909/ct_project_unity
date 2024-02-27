using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource source2;
    [SerializeField] private AudioClip navClip;
    [SerializeField] private AudioClip loadClip;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayNavSound()
    {
        source.Play();
    }

    public void PlayLoadSound()
    {
        source2.Play();
    }
}
