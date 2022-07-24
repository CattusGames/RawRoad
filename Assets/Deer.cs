using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private Rigidbody rb;
    [Range(0,10f)][SerializeField] private float _speed;
    [Range(0, 10f)][SerializeField] private float _pause;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Move(float speed, float pause)
    {
        if (pause <= 0)
        {
            rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        }
        else
        {

        }

    }

    private IEnumerator Pause(float pause)
    {
        yield return new WaitForSeconds(pause);
    }
}
