using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespawnGhost : MonoBehaviour
{
    public string targetTag;
    private Vector3 initialPosition;
    public UnityEvent<GameObject> OnEnterEvent;
    public GameObject ghost;

    private void Start()
    {
        initialPosition = ghost.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            OnEnterEvent.Invoke(other.gameObject);
        }
    }

    public void Respawn()
    {
        if (initialPosition != null)
        {
            ghost.transform.position = initialPosition;
        }
    }
}
