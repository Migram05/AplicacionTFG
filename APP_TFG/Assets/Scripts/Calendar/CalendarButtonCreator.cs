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
        int index = 1, maxNum;
        maxNum = Manager.instance.getNumDaysInMonth();
        foreach (Transform child in transform) //Recorremos los hijos y creamos botones para cada uno
        {
            each = Instantiate<GameObject>(buttonPrefab, child);
            each.gameObject.GetComponent<ButtonScript>().setNumber(index); //Ajustamos su número
            if (index >= maxNum) break; //Cuando hayamos creado tantos días como hay en el mes, dejamos de crear
            else ++index;
        }
    }
}
