using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarButtonCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrefab;
    List<GameObject> buttonList;
    void Start()
    {
        if (!buttonPrefab) return;
        GameObject each;
        int index = 1, maxNum, startNum, currentDayNum = 1;
        maxNum = Manager.instance.getNumDaysInMonth();
        startNum = Manager.instance.getFirstDay();
        foreach (Transform child in transform) //Recorremos los hijos y creamos botones para cada uno
        {
            if(index >= startNum)
            {
                each = Instantiate<GameObject>(buttonPrefab, child);
                each.gameObject.GetComponent<DayPrefabScript>().setNumber(currentDayNum); //Ajustamos su número
                if (currentDayNum >= maxNum) break; //Cuando hayamos creado tantos días como hay en el mes, dejamos de crear
                else currentDayNum++;
            }
            ++index;
        }
    }
}
