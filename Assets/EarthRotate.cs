using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EarthRotate : MonoBehaviour
{

    //Color activeColor = new Color();
    [SerializeField] [Range(0.01f,0.1f)] private float _speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //activeColor = Color.white;

        if (Input.touchCount == 1)
        {
            Touch screenTouch = Input.GetTouch(0);

            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.RotateAround(Vector3.up, -screenTouch.deltaPosition.x * _speed * Mathf.Deg2Rad);
                transform.RotateAround(Vector3.right, screenTouch.deltaPosition.y * _speed * Mathf.Deg2Rad);
                
                Debug.Log("X: " + screenTouch.deltaPosition.x + "\n" + "Y: " + screenTouch.deltaPosition.y );
            }
        }
        else
        {
            //activeColor = Color.blue;
        }

        //GetComponent<MeshRenderer>().material.color = activeColor;
    }
}