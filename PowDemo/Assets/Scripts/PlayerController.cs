using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivityX = 250f;
    [SerializeField] private float mouseSensitivityY = 250f;
    [SerializeField] private Transform spawnerObject;

    private void Update()
    {
        mouseRotateInputY();
        mouseRotateInputX();
    }

    private void mouseRotateInputY()
    {
        if (Input.GetMouseButton(1))
        {
            // left right mouse
            Vector3 mouseInputX = Vector3.down * Input.GetAxis("Mouse X") * mouseSensitivityX;
            rotatePlayerY(mouseInputX);
        }
    }
    void rotatePlayerY(Vector3 mouseInputX)
    {
        spawnerObject.Rotate(mouseInputX * Time.deltaTime, Space.World);
    }

    void mouseRotateInputX()
    {
        if (Input.GetMouseButton(1))
        {
            // mouse up down
            Vector3 mouseInputY = Vector3.right * Input.GetAxis("Mouse Y") * mouseSensitivityY;
            rotatePlayerX(mouseInputY);
        }
    }
    void rotatePlayerX(Vector3 mouseInputX)
    {
        spawnerObject.Rotate(mouseInputX * Time.deltaTime, Space.World);
    }
}
