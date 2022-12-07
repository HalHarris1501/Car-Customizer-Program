using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //variable to store the camera
    [SerializeField] private Camera cam;

    //variable to store the previous position
    private Vector3 previousPosition;

    // Update is called once per frame
    void Update()
    {
        //checks if the mouse button has been clicked
        if(Input.GetMouseButtonDown(0))
        {
            //sets the previous position to be the mouse positionon the viewport
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        //checks if the mouse button has been held
        if(Input.GetMouseButton(0))
        {
            //gets the direction to move the camera in by comparing the new mouse position with the old mouse position
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            //sets the point to rotate around
            cam.transform.position = new Vector3();

            //apply the rotation in the x axis
            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            //apply the rotation in the y axis, relative to the world space
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            //move camera to look back at the car
            cam.transform.Translate(new Vector3(0, 0, -10));

            //reset previous position variable
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
