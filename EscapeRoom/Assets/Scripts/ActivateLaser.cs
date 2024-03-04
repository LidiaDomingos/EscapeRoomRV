using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.ParticleSystem;

public class ActivateLaser : MonoBehaviour


{
    private LineRenderer lineRenderer;
    private bool rayActivate = false;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StarLaser());
        grabInteractable.deactivated.AddListener(x => StopLaser());

        // Obtém o LineRenderer do filho
        lineRenderer = transform.GetComponentInChildren<LineRenderer>();

        // Verifica se o LineRenderer foi encontrado
        if (lineRenderer != null)
        {
            // Desativa o LineRenderer no início
            lineRenderer.enabled = false;
        }
        else
        {
            Debug.LogError("LineRenderer não encontrado no filho.");
        }
    }

    public void StarLaser()
    {
        lineRenderer.enabled=true;
        rayActivate = true;
    }

    public void StopLaser()
    {
        lineRenderer.enabled = false;
        rayActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
