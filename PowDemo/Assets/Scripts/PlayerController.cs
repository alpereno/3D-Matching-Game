using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float mouseSensitivityX = 250f;
    //[SerializeField] private float mouseSensitivityY = 250f;
    [SerializeField] private float touchSensitivityX = 200;
    [SerializeField] private float touchSensitivityY = 200;

    [SerializeField] private Transform spawnerObject;
    [SerializeField] private LayerMask thingMask;
    bool inputActive = true;
    Camera viewCamera;
    float maxRayDistance = 100;
    Vector2 firstTouchPoint;
    Vector2 lastTouchPoint;
    Vector2 differenceBetweenTwoPoints;
    [SerializeField]
    float selectThreshold = 25f;
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
            //Input for PC
            //mouseRotateInputY();
            //mouseRotateInputX();
            //createAimRay();

            rotateX();
            rotateY();
            mouseClickInput();
            resetInputValues();
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
        //    }
        //}

        // hit can be null (generally). So we've to make another Physics.Raycast
        if (differenceBetweenTwoPoints.sqrMagnitude < selectThreshold * selectThreshold)
        {
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
    }

    void rotateY()
    {
        //Vector3 rotateVector = Vector3.zero;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    firstTouchX = Input.mousePosition.x;
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    float lastTouchX = Input.mousePosition.x;
        //    float diff = lastTouchX - firstTouchX;
        //    rotateVector = new Vector3(0, diff, 0) * Time.deltaTime;
        //    firstTouchX = lastTouchX;
        //    print(diff);
        //}
        //spawnerObject.Rotate(-rotateVector * touchSensitivityX, Space.World);
        //if (Input.GetMouseButton(0))
        //{
        //    spawnerObject.Rotate(0, Input.GetAxis("Mouse Y") * touchSensitivityY * Time.deltaTime, 0, Space.World);
        //}
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPoint.y = Input.mousePosition.y;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 rotateVector;
            lastTouchPoint.y = Input.mousePosition.y;
            differenceBetweenTwoPoints.y = Mathf.Abs(lastTouchPoint.y - firstTouchPoint.y);
            rotateVector = new Vector3(Input.GetAxis("Mouse Y") * touchSensitivityY, 0, 0);
            spawnerObject.Rotate(rotateVector * Time.deltaTime, Space.World);
        }
    }

    void rotateX()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPoint.x = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 rotateVector;
            lastTouchPoint.x = Input.mousePosition.x;
            differenceBetweenTwoPoints.x = Mathf.Abs(lastTouchPoint.x - firstTouchPoint.x);
            rotateVector = new Vector3(0, Input.GetAxis("Mouse X") * -touchSensitivityX, 0);
            spawnerObject.Rotate(rotateVector * Time.deltaTime, Space.World);
        }
    }

    void resetInputValues()
    {
        if (Input.GetMouseButtonUp(0))
        {
            firstTouchPoint = Vector2.zero;
            lastTouchPoint = Vector2.zero;
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

    // Input for PC
    #region
    //private void mouseRotateInputY()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        // mouse left right 
    //        Vector3 mouseInputX = Vector3.down * Input.GetAxis("Mouse X") * mouseSensitivityX;
    //        rotatePlayerY(mouseInputX);
    //    }
    //}
    //void rotatePlayerY(Vector3 mouseInputX)
    //{
    //    spawnerObject.Rotate(mouseInputX * Time.deltaTime, Space.World);
    //}

    //void mouseRotateInputX()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        // mouse up down
    //        Vector3 mouseInputY = Vector3.right * Input.GetAxis("Mouse Y") * mouseSensitivityY;
    //        rotatePlayerX(mouseInputY);
    //    }
    //}
    //void rotatePlayerX(Vector3 mouseInputX)
    //{
    //    spawnerObject.Rotate(mouseInputX * Time.deltaTime, Space.World);
    //}
    #endregion

    public void onGameOver() {
        inputActive = false;
    }
}
