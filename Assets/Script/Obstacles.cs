using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [Range(0,10)]
    public int timeBonus;

    private GameObject player;

    private GameProgressManager GPMngr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GPMngr = GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<GameProgressManager>();
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==player)
        {
            GPMngr.OnObstacles(timeBonus, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
            Destroy(gameObject);
        }

    }

}
