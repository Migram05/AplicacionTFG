using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    //[SerializeField]
    private string nombre;
    //[SerializeField]
    //private Color color;
    public GameObject padre;
    public string getNombre() { return nombre; }
    //public Color getColor() { return color; }

    private void Start()
    {
        padre = transform.parent.gameObject;
        nombre = gameObject.GetComponent<Image>().sprite.name;
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.parent.tag != "ImgScroll") return;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        if (transform.parent.GetComponent<DropItemSlotScript>())
        {
            transform.parent.GetComponent<DropItemSlotScript>().eraseActivityName();
        }

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        GameObject copia = Instantiate(this.gameObject);
        copia.transform.SetParent(this.padre.transform);
        copia.transform.localScale = Vector3.one;
        Vector3 pos = copia.transform.localPosition; pos.z = 0f; 
        copia.transform.SetPositionAndRotation(pos, Quaternion.identity);

        if (!this.gameObject.transform.parent.GetComponent<DropItemSlotScript>())
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.GetComponent<DragDropScript>().enabled = false;
        }
        copia.name = this.gameObject.name;
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
