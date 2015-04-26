using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cell : MonoBehaviour {

    public Vector2 positionInGrid;

    void Start()
    {
        GetComponentInChildren<Text>().color = ColorRegistry.textColor;
    }

    public void SetCurrent()
    {
        GameObject.FindWithTag("Grid").GetComponent<Grid>().currentCell = positionInGrid;
    }
}
