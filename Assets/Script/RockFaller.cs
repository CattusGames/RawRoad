using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFaller : MonoBehaviour
{

    [SerializeField] private Rigidbody[] _rocks;

    private void Awake()
    {
        for (int i = 0; i < _rocks.Length; i++)
        {
            _rocks[i].isKinematic = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            for (int i = 0; i < _rocks.Length; i++)
            {
                _rocks[i].isKinematic = false;
            }
        }
    }
}
