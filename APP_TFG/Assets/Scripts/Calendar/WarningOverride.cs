using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningOverride : MonoBehaviour
{
    int num = 0;
    public void setNum(int n) { 
        num = n;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void AbortOverride()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ProceedOverride()
    {
        Manager.instance.callendarButtonClicked(num, true);
    }
}
