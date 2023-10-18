using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private SimpleController simpleController;
    private LiftDoors liftDoors;
    private ElevatorSounds elevatorSounds;

    [Header("Settings")]
    [SerializeField] private float elevatorSpeed = 3;
    [SerializeField] private int numFloors;
    [SerializeField] private float TimeToCloseDoors = 1f;
    [SerializeField] private float TimeToOpenDoors = 1f;
    [SerializeField] private Transform[] floors;

    
    [HideInInspector]
    public int currentFloor = 0;

    [HideInInspector]
    public bool moving = false;
    private Vector3 targetPos;

    

    void Start()
    {
        liftDoors = GetComponentInChildren<LiftDoors>();
        elevatorSounds = GetComponent<ElevatorSounds>();
    }

    void Update()
    {
        if (moving && liftDoors.close)
        {
            // przesuwanie windy w kierunku pozycji docelowej
            transform.position = Vector3.MoveTowards(transform.position, targetPos, elevatorSpeed * Time.deltaTime);
            simpleController.playerInsideLift = true;
            // jeœli windy dotar³a do pozycji docelowej, zatrzymaj j¹ i wy³¹cz ruch
            if (transform.position == targetPos)
            {
                moving = false;
                simpleController.playerInsideLift = false;
                StartCoroutine(OpenDoors());
            }
        }
    }

    // funkcja do obs³ugi naciœniêcia przycisku na piêtrze
    public void GoToFloor(int floor)
    {
        if (!moving && floor != currentFloor && floor >= 0 && floor < numFloors)
        {
            targetPos = new Vector3(transform.position.x, floors[floor].position.y, transform.position.z);
            moving = true;
            currentFloor = floor;

            //elevatorSounds.PlaySound(0);
            if(liftDoors.open)
            {
                liftDoors.CloseDoors();
            }

            float playerPosY = simpleController.transform.position.y;

            if (playerPosY < floors[floor].transform.position.y)
            {
                simpleController.moveDown = false;
            }
            else
                simpleController.moveDown = true;
            //floorButtons[floor].GetComponent<Renderer>().material.color = Color.green;
        }
    }
    private IEnumerator OpenDoors()
    {
        yield return new WaitForSeconds(TimeToOpenDoors); // odczekaj czas zamkniêcia drzwi

        liftDoors.OpenDoors(); // otwórz drzwi windy
    }
    private IEnumerator CloseDoors()
    {
        yield return new WaitForSeconds(TimeToCloseDoors); // odczekaj czas zamkniêcia drzwi

        liftDoors.CloseDoors(); // otwórz drzwi windy
    }
}
