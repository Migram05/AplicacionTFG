using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesSummaryGenerator : MonoBehaviour
{
    void Start()
    {
        string[] savedActivities = Manager.instance.getSavedActivities();
        string[] savedEmotions = Manager.instance.getSavedEmotions();
        int cCount = gameObject.transform.childCount;
        for(int i = 0; i < cCount; i++)
        {
            AESummary aESummary = gameObject.transform.GetChild(i).GetComponentInChildren<AESummary>();
            aESummary.setTexts(savedActivities[i], savedEmotions[i]);
        }
    }
}
