using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraPlayer : MonoBehaviour
{

    public float MouseX_Dir;
    public float MouseY_Dir;
    public float cross_x;
    public float cross_z;
    public float y_angle;
    public float sin;
    public float cos;
    public float x;
    public float z;
    public Terrain map;
    public float height;
    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        /*
        int layerMask = 1 << 5;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {


            GameObject hitted = hit.collider.gameObject;

          //  hitted.SetActive(false);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }



         */
        float deltaZ = 0;
        float deltaX = 0;

        if (Input.anyKey)
        {
            Debug.Log("A key or mouse click has been detected" + Input.inputString);
            if (Input.inputString.Equals("w"))
            {
                deltaZ = 3f;
            }
            if (Input.inputString.Equals("s"))
            {
                deltaZ = -3f;
            }
            if (Input.inputString.Equals("a"))
            {
                deltaX = 1f;
            }
            if (Input.inputString.Equals("d"))
            {
                deltaX = -1f;
            }
        }

        MouseX_Dir = Input.GetAxis("Mouse X");
        MouseY_Dir = Input.GetAxis("Mouse Y");
  

        cross_x = (Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y) * deltaZ) + transform.position.x;
        cross_z = (Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y) * deltaZ) + transform.position.z;
        Vector3 movement = new Vector3(cross_x, transform.position.y, cross_z);
        // Vector3 movement = new Vector3(cross_x, map.terrainData.GetHeight((int)transform.position.x, (int)transform.position.z) + 2.0F, cross_z);
        transform.position = movement;
        transform.eulerAngles = new Vector3((transform.eulerAngles.x - MouseY_Dir), (transform.eulerAngles.y + MouseX_Dir), 0);

    }
}