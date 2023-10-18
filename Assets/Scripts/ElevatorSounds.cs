using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSounds : MonoBehaviour
{
    [Header("Scripts")]
    private LiftDoors lift;
    private ElevatorController elevator;


    [Header("Sounds")]
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;
    public bool canPlaySound;
    void Start()
    {
        elevator = GetComponent<ElevatorController>();
        audioSource = GetComponent<AudioSource>();
        lift = GetComponentInChildren<LiftDoors>();
    }
    // Update is called once per frame
    public void PlaySound(int i)
    {
        audioSource.clip = audioClips[i];
        canPlaySound = false;

        if (audioSource.loop == true)
            audioSource.loop = false;

        audioSource.Play();
   }
    public void PlayMusic()
    {
        if (elevator.moving)
        {
            audioSource.clip = audioClips[2];
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void StopSound()
    {
        audioSource.Stop();
    }
}
