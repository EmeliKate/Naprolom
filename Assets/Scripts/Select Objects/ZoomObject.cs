using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomObject : MonoBehaviour
{
    public GameObject mainCamera;
    private Camera camera;
    
    public float zoomFOV;
    private bool zoomOn;
    private float zoomDefault = 60;
   
    private Vector3 playerToObjDirection;

    // to test
    public GameObject testObj;

    void Start()
    {
        camera = mainCamera.GetComponent<Camera>();
        zoomOn = false;
    }

    public void ZoomInObject(float speed = 2.5f)
    {
        float start = camera.fieldOfView;
        float end = zoomFOV;
        camera.fieldOfView = Mathf.Lerp(start, end, Time.deltaTime*speed);
    }
    
    public void ZoomOutObject(float speed = 2.5f)
    {

        float start = camera.fieldOfView;
        float end = zoomDefault;
        camera.fieldOfView = Mathf.Lerp(start, end, Time.deltaTime*speed);
    }

    public void RotateToObject(GameObject objectToZoom, float speed = 2.5f)
    {
        Vector3 relativePos = objectToZoom.transform.position - mainCamera.transform.position;
        Quaternion rotationTo = Quaternion.LookRotation(relativePos, Vector3.up);
        
        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, rotationTo, Time.deltaTime*speed);
    }
    
    public void RotateToObjectBack(float speed = 2.5f)
    {
        //Vector3 relativePos = new Vector3(0,camera.transform.eulerAngles.y,0);
        //Quaternion rotationTo = Quaternion.LookRotation(relativePos, Vector3.up);
        
        //camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, rotationTo, Time.deltaTime*speed);
        
        Vector3 newEulerAngles = new Vector3(0,camera.transform.eulerAngles.y,0);
        camera.transform.eulerAngles = Vector3.Lerp(camera.transform.eulerAngles, newEulerAngles, Time.deltaTime*speed);
    }
}
