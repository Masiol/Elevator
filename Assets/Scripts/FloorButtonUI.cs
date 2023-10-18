using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorButtonUI : MonoBehaviour
{  
    [Header("Scripts")]
    [SerializeField] private ElevatorController elevator; 
    [SerializeField] private LiftDoors liftDoors;
    private Panel panel;

    [Header("Floor")]
    public int floor;    

    private void Start()
    {
        panel = GetComponentInParent<Panel>();
        this.GetComponent<Button>().onClick.AddListener(() => MovingToFloor(floor));
    }

    public void MovingToFloor(int floor)
    {
        panel.UpdateButtonOnPanel(floor);
        panel.HidePanel();
        elevator.GoToFloor(floor);
    }
}
