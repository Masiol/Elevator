using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDoors : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private SimpleController player;
    private DoorTrigger doorTrigger;
    private ElevatorSounds elevatorSounds;

    private Animator doorAnimator;

    private float time = 1f;
    [HideInInspector]
    public bool close = true, open;
   
    private void Start()
    {
        doorTrigger = GetComponentInChildren<DoorTrigger>();
        doorAnimator = GetComponent<Animator>();
        elevatorSounds = GetComponentInParent<ElevatorSounds>();
    }
    // Start is called before the first frame update
    public void OpenDoors()
    {
        doorAnimator.SetBool("Open", true);
        doorAnimator.SetBool("Close", false);
        doorTrigger.SetSafetyPlayer(false);
        elevatorSounds.PlaySound(0);
    }
    

    public void CloseDoors()
    {
        doorAnimator.SetFloat("speed", 1);
        doorAnimator.SetBool("Close",true);
        doorAnimator.SetBool("Open", false);
        doorTrigger.SetSafetyPlayer(true);
        elevatorSounds.PlaySound(1);
    }
    public void SetBoolDoorClose()
    {
        elevatorSounds.PlayMusic();
        close = true;
        open = false;
    }
    public void SetBoolDoorOpen()
    {
        open = true;
        close = false;
    }
    public void OpenDoorWhenPlayerWentIntoTrigger()
    {
        doorAnimator.SetFloat("speed", -1);
        StartCoroutine(ContinueMoving());
    }
    IEnumerator ContinueMoving()
    {
        yield return new WaitForSeconds(time);
        CloseDoors();
    }
}
