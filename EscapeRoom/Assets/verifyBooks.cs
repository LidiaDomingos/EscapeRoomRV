using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class verifyBooks : MonoBehaviour
{


    public int count = 0;

    public void UpdateScore()
    {
        count = count + 1;
        if (count == 3)
        {
            Debug.Log("comrpei");
        }
    }

}
