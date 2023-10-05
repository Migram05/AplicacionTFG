using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetMonthyear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = Manager.instance.getCurrentMonth() + " " + Manager.instance.getCurrentYear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
