using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cell : MonoBehaviour {

    public Vector2 positionInGrid;
    public void SetColor()
    {
        GetComponentInChildren<Text>().color = GameObject.FindWithTag("Grid").GetComponent<Grid>().currentColor;
        GameObject.FindWithTag("Grid").GetComponent<Grid>().MoveRight();
    }
    public void SetCurrent()
    {
        GameObject.FindWithTag("Grid").GetComponent<Grid>().currentCell = positionInGrid;
    }
}
