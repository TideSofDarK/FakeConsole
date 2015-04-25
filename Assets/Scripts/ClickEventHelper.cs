using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using UnityEngine.EventSystems;

public class ClickEventHelper : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData data)
    {
        GameObject.FindWithTag("ColorPointer").GetComponent<RectTransform>().localPosition = transform.localPosition + new Vector3(0f, 28f, 0f);
        GameObject.FindWithTag("Grid").GetComponent<Grid>().currentColor = GetComponent<Image>().color;
    }
}