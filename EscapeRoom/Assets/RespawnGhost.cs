using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnGhost : MonoBehaviour
{
    public string targetTag;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            transform.position = initialPosition;
        }
    }
}
