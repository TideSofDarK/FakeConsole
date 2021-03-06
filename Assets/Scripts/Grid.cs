﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Grid : MonoBehaviour
{

    public GameObject cellPrefab;

    public int gridWidth, gridHeight;
    public int gridCellWidth, gridCellHeight;

    GameObject[,] grid;

    public Vector2 currentCell;

    public Color currentColor = Color.white;

    public void ReInit()
    {
        ReInit(0,0);
    }

    private void ReInit(int width, int height)
    {
        //gridWidth = (int)GetComponent<RectTransform>().sizeDelta.x / (gridCellWidth);
       //gridHeight = (int)GetComponent<RectTransform>().sizeDelta.y / (gridCellHeight);

        if (grid != null)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    Destroy(grid[x, y]);
                }
            }
        }

        if (width == 0 && height == 0)
        {
            gridWidth = int.Parse(GameObject.FindWithTag("XField").GetComponent<InputField>().text);
            gridHeight = int.Parse(GameObject.FindWithTag("YField").GetComponent<InputField>().text);
        }
        else
        {
            gridWidth = width;
            gridHeight = height;
        }
        

        GetComponent<RectTransform>().sizeDelta = new Vector2(gridWidth * gridCellWidth, gridHeight * gridCellHeight);

        grid = new GameObject[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                grid[x, y] = Instantiate(cellPrefab, new Vector3(), Quaternion.identity) as GameObject;
                grid[x, y].transform.SetParent(transform);
                grid[x, y].transform.localPosition = Vector3.zero;
                grid[x, y].transform.localPosition = new Vector3(gridCellWidth / 2, gridCellHeight / 2, 0f) + new Vector3(x * gridCellWidth, y * gridCellHeight, 0f) - new Vector3(GetComponent<RectTransform>().sizeDelta.x / 2f, GetComponent<RectTransform>().sizeDelta.y / 2f);
                grid[x, y].GetComponent<Cell>().positionInGrid = new Vector2(x, y);
            }
        }
    }

    void SelectCell()
    {
        grid[(int)currentCell.x, (int)currentCell.y].GetComponent<InputField>().Select();
    }

    public void MoveRight()
    {
        if (currentCell.x < gridWidth - 1) currentCell.x++;
        else if (currentCell.y >0)
        {
            currentCell.y--;
            currentCell.x = 0;
        }
        SelectCell();
    }

    public void MoveLeft()
    {
        if (currentCell.x > 0) currentCell.x--;
        else if (currentCell.y < gridHeight - 1)
        {
            currentCell.y++;
            currentCell.x = gridWidth - 1;
        }
        SelectCell();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentCell.y < gridHeight-1) currentCell.y++;
            SelectCell();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentCell.y > 0) currentCell.y--;
            SelectCell();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        //else if (Input.GetKeyDown(KeyCode.Backspace))
        //{
        //    MoveLeft();
        //    grid[(int)currentCell.x-1, (int)currentCell.y].GetComponent<InputField>().text = "";
        //}
    }

    public string GetTextContent()
    {
        string finalString = "";
        for (int y = gridHeight - 1; y >= 0; y--)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                string newText = grid[x, y].GetComponentInChildren<Text>().text;
                finalString += newText == "" ? "\u00A0" : newText;
            }
            finalString += "\n";
        }
        return finalString;
    }

    public void LoadText(string text)
    {
        int newHeight = text.Split('\n').Length - 1;
        int newWidth = (text.Length-1)/newHeight;

        ReInit(newWidth, newHeight);

        char[,] textArray = new char[gridWidth, gridHeight];
        text = text.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
        for (int y = gridHeight - 1; y >= 0; y--)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                textArray[x, gridHeight - y - 1] = text[x + ((y * gridWidth))];
            }
        }

        for (int y = gridHeight - 1; y >= 0; y--)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if (textArray[x, y].ToString() == "\u00A0") grid[x, y].GetComponentInChildren<InputField>().text = "";
                else grid[x, y].GetComponentInChildren<InputField>().text = textArray[x, y].ToString();
            }
        }
    }

    public void SetColor(Color color)
    {
        for (int y = gridHeight - 1; y >= 0; y--)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                grid[x, y].GetComponentInChildren<Text>().color = color;
            }
        }
    }
}
