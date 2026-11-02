using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerForArkanoid : MonoBehaviour
{
    [SerializeField] AudioSource musicSourceArkanoid;
    [SerializeField] AudioSource SFXSourceArkanoid;

    public AudioClip backgroundMusicArkanoid;
    public AudioClip hitBrickOriginal;
    public AudioClip completeLevelArkanoid;
    // Start is called before the first frame update
    void Start()
    {
       /* musicSourceArkanoid.clip = backgroundMusicArkanoid;
        musicSourceArkanoid.Play();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSourceArkanoid.PlayOneShot(clip);
    }
}
