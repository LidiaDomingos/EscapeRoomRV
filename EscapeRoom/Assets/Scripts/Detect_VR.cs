using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
    public GameObject xrOrigin;
    public GameObject desktopCharacter;

    void Start()
    {
        var xrSettings = XRGeneralSettings.Instance;
        if (xrSettings == null)
        {
            Debug.Log("XrGeneralSettings is null");
            return;
        }

        var xrManager = xrSettings.Manager;
        if (xrManager == null)
        {
            Debug.Log("XrManagerSettings is null");
            return;
        }

        var xrLoader = xrManager.activeLoader;
        if (xrLoader == null)
        {
            Debug.Log("XRLoader is null");
            xrOrigin.SetActive(false);
            desktopCharacter.SetActive(true);
            return;
        }

        Debug.Log("XRLoader is not null");
        xrOrigin.SetActive(true);
        desktopCharacter.SetActive(false);

    }
}
