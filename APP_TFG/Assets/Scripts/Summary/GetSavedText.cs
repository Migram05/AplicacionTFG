using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetSavedText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool isGoodText = true;
    // Start is called before the first frame update
    void Start()
    {
        string savedText = Manager.instance.getSavedGoodText();
        if (!isGoodText) savedText = Manager.instance.getSavedBadText();
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = savedText; //Ajusta el texto
    }
}
