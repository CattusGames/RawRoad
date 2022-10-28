using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidObstacle : MonoBehaviour
{
    [SerializeField][Range(0, 10)]private int timeBonus;

    private GameProgressManager GPMngr;

    void Start()
    {
        GPMngr = GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<GameProgressManager>();
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GPMngr.SolidObstacleEvent?.Invoke(timeBonus, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
            Destroy(gameObject);
        }

    }

}
