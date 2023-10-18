using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private ElevatorController elevatorController;

    [Header("Buttons")]
    [SerializeField] private FloorButtonUI[] floorButtons;

    public GameObject UIPanel;
    [HideInInspector]
    public bool panelOpened = false;

    private void Start()
    {
        floorButtons = GetComponentsInChildren<FloorButtonUI>();
        UpdateButtonOnPanel(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelOpened)
            {
                StartCoroutine(ScalePanel(0.5f, Vector3.one, Vector3.zero));
                panelOpened = false;
            }
            else
                return;
        }
    }
    public void OnPanelPressed()
    {
        if (!panelOpened)
        {
            StartCoroutine(ScalePanel(0.5f, Vector3.zero, Vector3.one));
            panelOpened = true;
        }
    }
    public void HidePanel()
    {
        StartCoroutine(ScalePanel(0.5f, Vector3.one, Vector3.zero));
        panelOpened = false;
    }

    IEnumerator ScalePanel(float time, Vector3 currentScale, Vector3 destinationScale)
    {
        RectTransform panelRectTransform = UIPanel.GetComponent<RectTransform>();
        Vector3 originalScale = panelRectTransform.localScale;
        Vector3 destScale = destinationScale;
        float currentTime = 0.0f;

        while (currentTime < time)
        {
            panelRectTransform.localScale = Vector3.Lerp(originalScale, destScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }

        panelRectTransform.localScale = destScale;
    }
    public void UpdateButtonOnPanel(int floor)
    {
        int currentFloor = floor;

        foreach (FloorButtonUI button in floorButtons)
        {
            if (button.floor == currentFloor)
            {
                button.GetComponent<Button>().interactable = false;
            }
            else
            {
                button.GetComponent<Button>().interactable = true;
            }
        }
    }
}
