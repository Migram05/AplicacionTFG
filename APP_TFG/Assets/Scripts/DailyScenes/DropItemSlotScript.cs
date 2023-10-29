using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropItemSlotScript : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private TextMeshProUGUI nombreActividad;
    [SerializeField]
    private string Allowedtag;

    public void eraseActivityName()
    {
        nombreActividad.text = "";
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
            nombreActividad.text = imagen.GetComponent<DragDropScript>().getNombre();

        }
    }
}
