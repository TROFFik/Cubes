using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private Vector3 rotateDirection;
    private Vector3 moveDirection;
    private float rotationY;

    bool IsPointerDown = false;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        GetAxis();
        Movment();
        Rotation();
    }

    private void GetAxis()
    {
        if (!IsPointerDown)
        {
            moveDirection.x = Input.GetAxisRaw("Horizontal");
            moveDirection.z = Input.GetAxisRaw("Vertical");

            rotateDirection.x = Input.GetAxis("Mouse X");
            rotateDirection.y = Input.GetAxis("Mouse Y");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 3;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= 3;
        }
    }

    private void Movment()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void Rotation()
    {
        rotationY -= rotateDirection.y;
        rotationY = Mathf.Clamp(rotationY, -80f, 80f);
        
        transform.Rotate(0, rotateDirection.x * rotateSpeed * Time.deltaTime, 0);
        transform.localRotation = Quaternion.Euler(rotationY, transform.localEulerAngles.y, 0);
    }

    public void PointerDown(int Dir)
    {
        IsPointerDown = true;
        moveDirection = Vector3.forward * Dir;
    }

    public void PointerUp()
    {
        IsPointerDown = false;
        moveDirection = Vector3.zero;
    }
}
