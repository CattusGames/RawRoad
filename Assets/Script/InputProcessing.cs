using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputProcessing : MonoBehaviour
{
	public float X;
	public float Y;

    private Rect leftPart = new Rect(0, 0, Screen.width / 2, Screen.height-300);
    private Rect rightPart = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height-300);

    private void Awake()
    {
        X = 0;
        Y = 0;
    }  
    void Update()
    {
        X = Input.GetAxis("Horizontal");


		if (Input.GetKeyDown("t"))
			GetComponent<Game>().Skip();

       /* if (Input.GetMouseButton(0)){

            if (leftPart.Contains(Input.mousePosition))
            {
                X = -1;
                Y = 0;
            }
            else if (rightPart.Contains(Input.mousePosition))
            {
                X = 1;
                Y = 0;
            }
        }else{
            X = 0;
            Y = 0;}*/
    }
        public Vector2 GetDirection(){
		return new Vector2(X, Y);}

}