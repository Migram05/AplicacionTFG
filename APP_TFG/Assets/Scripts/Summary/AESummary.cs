using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AESummary : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI activityText;
    [SerializeField]
    private TextMeshProUGUI emotionText;
    
    public void setTexts(string aText, string eText)
    {
        activityText.text = aText;
        emotionText.text = eText;
    }
}
