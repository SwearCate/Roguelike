using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [System.Serializable]

    public struct Grid
    {

        public int columns, rows;

        public float verticalOffeset, horizontalOffeset;
    }

    public Grid grid;
    public GameObject gridTile;
    public List<Vector2> availablePoints = new List<Vector2>();

    void Awake()
    {
        grid.rows = 8;
        grid.columns = 8;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        grid.verticalOffeset += transform.localPosition.y;
        grid.horizontalOffeset += transform.localPosition.x;

        for (int y = 0; y < grid.rows; y++)
        {
            for(int x = 0; x < grid.columns; x++)
            {
                GameObject go = Instantiate(gridTile, transform);
                go.GetComponent<Transform>().position = new Vector2(x - (grid.columns - grid.horizontalOffeset), y - (grid.rows - grid.verticalOffeset));
                go.name = "X: " + x + ", Y " + y;
                availablePoints.Add(go.transform.position);
            }
        }
    }
}
