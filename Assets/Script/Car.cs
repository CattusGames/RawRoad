using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float Speed = 1f;
    public GameObject AirPoint;
    public GameObject GroundPoint;

    [HideInInspector] public Rigidbody rb;

    public bool Aerial;
    // Start is called before the first frame update
   private void Start()
    {
        Initialization();
    }

    // Update is called once per frame
   private void FixedUpdate()
    {
        Move();
    }
  
    private void Move()
    {
        Ray AirRay = new Ray(AirPoint.transform.position, -AirPoint.transform.up);
        RaycastHit AirHit;

        Ray GroundRay = new Ray(GroundPoint.transform.position, -GroundPoint.transform.up);
        RaycastHit GroundHit;

        Vector3 Direction = transform.forward * Speed;

        if (!Physics.Raycast(AirRay, out AirHit, 1f) && Physics.Raycast(GroundRay, out GroundHit, 1f)) //����� �����
        {
            rb.AddForce(Direction);
        }
        else if (Physics.Raycast(AirRay, out AirHit, 1f) && Physics.Raycast(GroundRay, out GroundHit, 1f))//����� �������� � ������ �������
        {
            transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
            rb.AddForce(Direction);
            //Quaternion.AngleAxis(90,Vector3.up);
        }
        else if (Physics.Raycast(AirRay, out AirHit, 1f) && !Physics.Raycast(GroundRay, out GroundHit, 1f))//����� �������� � ����� �������
        {
            transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime);
            rb.AddForce(Direction);
            //Quaternion.AngleAxis(-90, Vector3.up);
        }
        else
        {
            transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime);
            rb.AddForce(Direction);
        }

        if (rb.velocity.magnitude > 3)
        {
            rb.drag = 5;

        }
        else
        {
            rb.drag = 0.5f;

        }
    }

    private void Initialization()
    {
        rb = GetComponent<Rigidbody>();
    }
}
