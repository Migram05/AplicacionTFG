using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropItemSlotScript : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private TextMeshProUGUI texto;
    [SerializeField]
    private string Allowedtag;
    [SerializeField] //Se usa para guardar la información como actividad o emocion
    bool isActiviyDrop = false;
    bool used = false;

    public bool getIsActivityDrop() { return isActiviyDrop; }
    public string getText()
    {
        string returnString = texto.text;
        if (!used) returnString = "NADA";
        return returnString;
    }
    public void eraseActivityName()
    {
        texto.text = " ";
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.tag == Allowedtag)
        {
            if (this.transform.childCount > 0)
            {
                GameObject imgChild = this.transform.GetChild(0).gameObject;
                Destroy(imgChild);
            }
            GameObject imagen = eventData.pointerDrag;
            imagen.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            imagen.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
            imagen.GetComponent<Transform>().position = this.GetComponent<Transform>().position;
            texto.text = imagen.GetComponent<DragDropScript>().getNombre();
            used = true;
        }
    }
}
