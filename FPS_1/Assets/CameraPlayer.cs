using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraPlayer : MonoBehaviour
{
    public float Zpos;
    public float Xpos;
    public float MouseX_pres;
    public float MouseX_pres_1;
    public float MouseX_past;
    public float MouseX_Direction;
    public float MouseY_pres;
    public float MouseY_pres_1;
    public float MouseY_past;
    public float MouseY_Direction;

    public float cross_x;
    public float cross_z;

    public float y_angle;
    public float sin;
    public float cos;


    public float x;
    public float z;

    public float height;

    public Terrain map;



    // Use this for initialization
    void Start()
    {
        MouseX_past = Input.mousePosition.x;
        MouseY_past = Input.mousePosition.y;
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

        MouseX_pres_1 = Input.GetAxis("Mouse X");
        MouseY_pres_1 = Input.GetAxis("Mouse Y");
        MouseX_pres = Input.mousePosition.x;
        MouseY_pres = Input.mousePosition.y;
        MouseX_Direction = MouseX_past - MouseX_pres;
        MouseY_Direction = MouseX_past - MouseY_pres;
        MouseX_past = MouseX_pres;
        MouseY_past = MouseY_pres;
        Zpos = Zpos + deltaZ;
        Xpos = Xpos + deltaX;

        x = transform.position.x;
        z = transform.position.z;

        //  height = map.terrainData.GetHeight(transform.position.x, transform.position.z);

        //    height = map.terrainData.GetHeight((int)transform.position.x, (int)transform.position.z);
        //y_angle = transform.eulerAngles.y;
        // y_angle = Mathf.Deg2Rad*90;
        sin = Mathf.Sin(y_angle);
        cos = Mathf.Cos(y_angle);

        cross_x = (Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.y) * deltaZ) + transform.position.x;
        cross_z = (Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.y) * deltaZ) + transform.position.z;



        Vector3 movement = new Vector3(cross_x, transform.position.y, cross_z);
        // Vector3 movement = new Vector3(cross_x, map.terrainData.GetHeight((int)transform.position.x, (int)transform.position.z) + 2.0F, cross_z);
        //  Vector3 movement = new Vector3(Xpos, transform.position.y, Zpos);
        transform.position = movement;

        //   transform.eulerAngles = new Vector3((transform.eulerAngles.x + MouseX_pres_1), (transform.eulerAngles.y +MouseY_pres_1), 0);
        transform.eulerAngles = new Vector3((transform.eulerAngles.x - MouseY_pres_1), (transform.eulerAngles.y + MouseX_pres_1), 0);
        //   transform.eulerAngles= new Vector3(-(MouseY_pres/10.0f), (MouseX_pres/ 10.0f), 0);

        // Print the rotation around the global X Axis
        // print(transform.eulerAngles.x);
        // Print the rotation around the global Y Axis
        //  print(transform.eulerAngles.y);
        // Print the rotation around the global Z Axis
        //  print(transform.eulerAngles.z);
    }
}