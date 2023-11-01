using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityEmotionSave : MonoBehaviour
{
    private void OnDestroy()
    {
        int numChild = gameObject.transform.childCount;
        for(int i = 0; i < numChild; i++)
        {
            GameObject parent = gameObject.transform.GetChild(i).gameObject;
            DropItemSlotScript[] componentArray = parent.GetComponentsInChildren<DropItemSlotScript>();
            //Guarda las actividades
            foreach(DropItemSlotScript componentRef in componentArray)
            {
                string textToSave = componentRef.getText();
                if (componentRef.getIsActivityDrop()) Manager.instance.saveActivity(textToSave);
                else Manager.instance.saveEmotion(textToSave);
            }
        }
    }
}
