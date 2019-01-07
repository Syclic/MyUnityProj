using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    CharacterController controller;
    public Transform playerCamTransform, character, centerPoint, reticle;
    public Camera playerCam;

    public Animator animator;
    
    private const float yAngleMin = 0.0f, yAngleMax = 65.0f;
    public float mouseSpeed = 3f, moveSpeed = 5f, walkSpeed = 2f, rotationSpeed = 5f;
    private float verticalVelocity, zoom = 5.0f, currentX = 0.0f, currentY = 0.0f, reticleZoom;
    private bool running;

    public virtual void Interact()
    {
        Debug.Log("Interacting with something");
    }

    void Start()
    {
        playerCamTransform = playerCam.transform;
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        running = true;
    }

    void Update()
    {
        #region Character Movement
        reticleZoom += Input.GetAxis("Mouse ScrollWheel") * 20f;
        reticleZoom = Mathf.Clamp(reticleZoom, 0.5f, 8f);
        reticle.localPosition = new Vector3(0, 5, reticleZoom);

        currentX += Input.GetAxis("Mouse X") * mouseSpeed;
        currentY -= Input.GetAxis("Mouse Y") * mouseSpeed;
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
        float moveFB = Input.GetAxis("Vertical") * moveSpeed;
        float moveLR = Input.GetAxis("Horizontal") * moveSpeed;
        Vector2 input = new Vector2(moveLR, moveFB);
        Vector2 inputDirection = input.normalized;

        if (PlayerManager.instance.KeyDown("ToggleWalk"))
        {
            if (running)
            {
                running = false;
            }
            else
            {
                running = true;
            }
        }

        float speed = ((running) ? moveSpeed : walkSpeed) * inputDirection.magnitude;


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

        float animationSpeedPercent = ((running) ? 1 : 0.5f) * inputDirection.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent);

        #endregion
        #region Left Click Interact

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(centerPoint.transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.GetComponent<Interactable>().Interact();
                }
            }
        }

        #endregion
        #region CursorLock
        if (PlayerManager.instance.KeyDown("UnlockCursor"))
        {
            PlayerManager.instance.SetCursorState(CursorLockMode.None);
        }
        if (PlayerManager.instance.KeyUp("UnlockCursor"))
        {
            PlayerManager.instance.SetCursorState(CursorLockMode.Locked);
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
