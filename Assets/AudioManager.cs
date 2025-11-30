using UnityEngine;

public class AudioManager : MonoBehaviour
    //this script will handle all audio clips for the main level, including SFX clips and background ambience
{
    [Header("Source")]
    [SerializeField] AudioSource music_source;
    [SerializeField] AudioSource SFX_source;


    [Header("Audio Clips")]
    //audio 
    public AudioClip background;
    public AudioClip footstep;
    public AudioClip pistolShot;
    public AudioClip shotgunShot;
    public AudioClip pistolReload;
    public AudioClip shotgunReload;
    public AudioClip zombieDeath;
    public AudioClip zombieGroan;
    public AudioClip powerOn;
    public AudioClip ammoPurchase;

    private void Start()
    {
        music_source.clip = background;
        music_source.Play();

    }
    // CAN BE ACCESSED FROM OTHER SCRIPTS
    public void PlaySFX (AudioClip clip)
    {
        SFX_source.PlayOneShot(clip);
    }    
}
