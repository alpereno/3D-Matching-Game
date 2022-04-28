using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivityX = 250f;
    [SerializeField] private float mouseSensitivityY = 250f;
    [SerializeField] private Transform spawnerObject;
    [SerializeField] private LayerMask thingMask;
    bool inputActive = true;
    Camera viewCamera;
    float maxRayDistance = 100;
    Material selectedMat;
    Color defaultColor;
    Color yellowColor;

    private void Start()
    {   // OBSOLETE Event System Action
        //Inventory.instance.onGameOver += onGameOver;
        viewCamera = Camera.main;
        yellowColor = Color.yellow;
    }

    private void Update()
    {
        if (inputActive)
        {
            mouseRotateInputY();
            mouseRotateInputX();
            //createAimRay();
            mouseClickInput();
        }
    }

    void mouseClickInput()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //----------- selection effect------------
        //if (Input.GetMouseButton(0))
        //{
        //    if (Physics.Raycast(ray, out hit, maxRayDistance, thingMask, QueryTriggerInteraction.Collide))
        //    {
        //        // selection effect
        //        selectedMat = hit.collider.GetComponent<Renderer>().material;
        //        defaultColor = selectedMat.color;
        //        selectedMat.color = yellowColor;
        //        print("----- selection effect, item name = " + hit.collider.name);
        //    }
        //}

        // hit can be null (generally). So we've to make another Physics.Raycast
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, maxRayDistance, thingMask, QueryTriggerInteraction.Collide))
            {
                Thing objectThing = hit.collider.GetComponent<Thing>();
                if (objectThing != null)
                {
                    //selectedMat.color = defaultColor;
                    objectThing.interact();
                }
            }
        }
    }

    // OBSOLETE selection
    #region
    //private void createAimRay()
    //{
    //    Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;        
    //    if (Physics.Raycast(ray, out hit, maxRayDistance, thingMask, QueryTriggerInteraction.Collide))
    //    {

    //        // you can do selection effect here

    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Thing t = hit.collider.GetComponent<Thing>();
    //            if (t != null)
    //            {
    //                t.interact();
    //            }
    //        }
    //    }
    //}
    #endregion

    private void mouseRotateInputY()
    {
        if (Input.GetMouseButton(1))
        {
            // mouse left right 
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

    public void onGameOver() {
        inputActive = false;
    }
}
