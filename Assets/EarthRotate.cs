using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EarthRotate : MonoBehaviour
{

    Color activeColor = new Color();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        activeColor = Color.white;

        if (Input.touchCount == 1)
        {
            Touch screenTouch = Input.GetTouch(0);

            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, screenTouch.deltaPosition.x, 0f);
            }
        }
        else
        {
            activeColor = Color.blue;
        }

        GetComponent<MeshRenderer>().material.color = activeColor;
    }
}