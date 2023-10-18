using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private ElevatorController elevator;
    [SerializeField] private LiftDoors liftDoors;

    public int floorNumber;

    private bool pressedButton;
    private Vector3 startPosButton;
    private bool doorState;

    private void Start()
    {
        startPosButton = transform.position;
        liftDoors = elevator.GetComponentInChildren<LiftDoors>();
    }

    public void OnButtonPressed()
    {
        CheckCurrentButton();
        if (!pressedButton)
        {
            elevator.GoToFloor(floorNumber);
            //  ButtonAnimOnClicked();
            pressedButton = true;
        }
    }
    private void CheckCurrentButton()
    {
        if (elevator.currentFloor == floorNumber)
        {
            if (liftDoors.close)
            {
                if (!doorState)
                {
                    liftDoors.OpenDoors();
                    doorState = true;
                    Invoke("ResetDoorState", 1.5f);
                }
            }
            else

                if (!doorState)
            {
                liftDoors.CloseDoors();
                doorState = true;
                Invoke("ResetDoorState", 1.75f);

            }

        }
        else
            pressedButton = false;
    }
    private void ResetDoorState()
    {
        doorState = false;
    }
}