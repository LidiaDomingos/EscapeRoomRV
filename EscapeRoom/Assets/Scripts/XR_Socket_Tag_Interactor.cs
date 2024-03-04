using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    public List<string> targetTag = new List<string> {"BookGreen", "BookBlue", "BookBrown"};

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && targetTag.Contains(interactable.transform.tag);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && targetTag.Contains(interactable.transform.tag);
    }
}
