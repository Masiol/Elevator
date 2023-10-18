using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleController : MonoBehaviour
{
    private CharacterController characterController;
    private Camera playerCamera;

    [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float jumpHeight; // wysokoœæ skoku
    [SerializeField] private float gravity = -9.81f; // wartoœæ przyspieszenia grawitacyjnego
    [SerializeField] private Panel panel;

    private float verticalRotation = 0;
    private Vector3 verticalVelocity = Vector3.zero; // prêdkoœæ pionowa
    public bool playerInsideLift;
    private float movingY;

    public bool moveDown;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (!panel.panelOpened)
        {
            // Obrót kamery za pomoc¹ myszy
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
            transform.Rotate(Vector3.up * mouseX);
            playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

            // Ruch postaci
            if (!playerInsideLift)
            {
                movingY = 0;
                gravity = -5; 
                verticalVelocity.y += gravity * Time.deltaTime;
                characterController.Move(verticalVelocity * Time.deltaTime);
            }
            else
            {
                if (moveDown)
                {
                    movingY = -0.75f;
                }
                else
                {
                    movingY = 0.75f;
                }
            }
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), movingY, Input.GetAxis("Vertical"));
            characterController.Move(transform.TransformDirection(move) * Time.deltaTime * speed);
        }
    }
}