using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using UnityEngine.EventSystems;

public class ClickEventHelper : MonoBehaviour, IPointerClickHandler
{
    public Image newPanel;
    public Image grid;

    public Text[] createMenuTexts;

    public enum ColorType
    {
        Foreground, Background, Text
    }

    public ColorType colorType;

    public void OnPointerClick(PointerEventData data)
    {
        switch (colorType)
        {
            case ColorType.Foreground:
                GameObject.FindWithTag("OptionsPanel").GetComponent<Image>().color = GetComponent<Image>().color;
                GameObject.FindWithTag("ToolPanel").GetComponent<Image>().color = GetComponent<Image>().color;
                newPanel.color = GetComponent<Image>().color;
                grid.color = GetComponent<Image>().color;

                GameObject.FindWithTag("ForegroundColorPointer").GetComponent<RectTransform>().localPosition = transform.localPosition + new Vector3(0f, 28f, 0f);

                ColorRegistry.foregroundColor = GetComponent<Image>().color;
                break;
            case ColorType.Background:
                GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor = GetComponent<Image>().color;

                GameObject.FindWithTag("BackgroundColorPointer").GetComponent<RectTransform>().localPosition = transform.localPosition + new Vector3(0f, 28f, 0f);

                ColorRegistry.backgroundColor = GetComponent<Image>().color;
                break;
            case ColorType.Text:
                foreach (Text item in GameObject.FindObjectsOfType<Text>())
                {
                    item.color = GetComponent<Image>().color;
                }

                foreach (Text item in createMenuTexts)
                {
                    item.color = GetComponent<Image>().color;
                }

                GameObject.FindWithTag("TextColorPointer").GetComponent<RectTransform>().localPosition = transform.localPosition + new Vector3(0f, 28f, 0f);

                ColorRegistry.textColor = GetComponent<Image>().color;
                break;
            default:
                break;
        }
    }
}