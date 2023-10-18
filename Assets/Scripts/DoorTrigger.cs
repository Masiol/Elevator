using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [Header("Scripts")]
    private LiftDoors liftDoors;
    private ElevatorSounds elevatorSounds;

    private bool playerWentIntoTriggerLiftDoor;
    private bool playerSafety;

    private void Start()
    {
        elevatorSounds = GetComponentInParent<ElevatorSounds>();
        liftDoors = GetComponentInParent<LiftDoors>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (playerSafety)
        {
            // Sprawdü, czy obiekt wejúcia to gracz
            if (other.CompareTag("Player"))
            {
                elevatorSounds.StopSound();
                // Powiadom windy, øe gracz wszed≥
                liftDoors.OpenDoorWhenPlayerWentIntoTrigger();
            }
        }
    }
    public void SetSafetyPlayer(bool safety)
    {
        playerSafety = safety;
    }
}
