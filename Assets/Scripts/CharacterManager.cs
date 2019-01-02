using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    CharacterController controller;
    public Transform playerCamTransform, character, centerPoint;
    public Camera playerCam;

    private const float yAngleMin = 0.0f, yAngleMax = 65.0f;
    public float mouseSpeed = 3f, moveSpeed = 5f, rotationSpeed = 5;
    private float verticalVelocity, zoom = 10.0f, currentX = 0.0f, currentY = 0.0f, zoomSpeed = 2, zoomMin = 1f, zoomMax = 5f;

    public virtual void Interact()
    {
        Debug.Log("Interacting with something");
    }

    void Start()
    {
        playerCamTransform = playerCam.transform;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        #region Character Movement
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
        currentX += Input.GetAxis("Mouse X") * mouseSpeed;
        currentY -= Input.GetAxis("Mouse Y") * mouseSpeed;
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
        float moveFB = Input.GetAxis("Vertical") * moveSpeed;
        float moveLR = Input.GetAxis("Horizontal") * moveSpeed;

        if (controller.isGrounded)
        {
            verticalVelocity = -1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = 8;
            }
        }
        else
        {
            verticalVelocity -= 1;
        }

        Vector3 movement = new Vector3(moveLR, verticalVelocity, moveFB);
        movement = character.rotation * movement;

        controller.Move(movement * Time.deltaTime);

        Quaternion turnAngle = Quaternion.Euler(0, playerCamTransform.eulerAngles.y, 0);
        character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);

        #endregion
        #region Left Click Interact

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(centerPoint.transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 20))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.GetComponent<Interactable>().Interact();
                }
            }
        }

#endregion
    }

    private void LateUpdate()
    {
        

        Vector3 dir = new Vector3(0, 0, -zoom);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        playerCamTransform.position = centerPoint.position + rotation * dir;
        playerCamTransform.LookAt(centerPoint.position);
    }
}
