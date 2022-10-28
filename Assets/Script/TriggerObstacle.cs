using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerObstacle : MonoBehaviour
{
    public UnityEvent TriggerObstacleEvent;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerObstacleEvent.Invoke();
        }
    }
}
