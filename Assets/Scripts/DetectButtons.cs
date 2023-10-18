using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectButtons : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Panel panelButtons;
    [SerializeField] private ElevatorController elevatorController;

    [Header("Strings")]
    [SerializeField] private string buttonTag;
    [SerializeField] private string panel;
   
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(ray, out hit) && hit.transform.CompareTag(buttonTag))
        {
            
            //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
            hit.transform.GetComponent<FloorButton>().OnButtonPressed();

        }
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(ray, out hit) && hit.transform.CompareTag(panel))
        {
            if (!elevatorController.moving)
            {
                //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
                panelButtons.OnPanelPressed();
            }

        }
    }
}
