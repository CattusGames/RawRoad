using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputProcessing : MonoBehaviour
{
	public float X;
	public float Y;
    public bool slowdown;

    private Rect leftPart = new Rect(0, 0, Screen.width / 2, Screen.height-300);
    private Rect rightPart = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height-300);

    
    //public GameProgressManager GPMngr;
    private void Awake()
    {
        slowdown = false;
        X = 0;
        Y = 0;
    }  
    void Update()
    {


        //if (Input.GetKeyDown("t"))
        //GPMngr.Skip();
       

       if (Input.touchCount == 1){

            if (leftPart.Contains(Input.mousePosition) && !rightPart.Contains(Input.mousePosition))
            {
                X = -1;
                Y = 0;
            }
            else if (rightPart.Contains(Input.mousePosition) && !leftPart.Contains(Input.mousePosition))
            {
                X = 1;
                Y = 0;
            }
        }
        else if (Input.touchCount>=2 || Input.GetKey(KeyCode.S))
        {
            slowdown = true;
            Debug.Log("Slowdown is "+slowdown);
            X = 0;
            Y = 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.A) == true)
            {
                X = -1;
                Y = 0;
            }
            else if (Input.GetKey(KeyCode.D) == true)
            {
                X = 1;
                Y = 0;
            }
            else
            {
                slowdown = false;
                X = 0;
                Y = 0;
            }

        }
        
    }
        public Vector2 GetDirection(){
		return new Vector2(X, Y);}

}