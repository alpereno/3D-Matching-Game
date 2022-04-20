using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivityX = 250f;
    [SerializeField] private float mouseSensitivityY = 250f;
    [SerializeField] private Transform spawnerObject;
    [SerializeField] private LayerMask thingMask;
    Camera viewCamera;
    float maxRayDistance = 100;
    Color defaultColor;
    Color yellowColor;

    private void Start()
    {
        viewCamera = Camera.main;
        yellowColor = Color.yellow;
    }

    private void Update()
    {
        mouseRotateInputY();
        mouseRotateInputX();
        createAimRay();
    }

    private void createAimRay()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;        
        if (Physics.Raycast(ray, out hit, maxRayDistance, thingMask, QueryTriggerInteraction.Collide))
        {
            //print(hit.collider.name);
        }
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
