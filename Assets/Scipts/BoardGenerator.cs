using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject figure;
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    
    private GameObject[,] figures;
    private const float SPACE = 2;


    private void Start()
    {
        figures = new GameObject[rows,columns];
        GenerateBoard();
    }

    public void GenerateBoard()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            { 
                var temp = Instantiate(figure,transform,false);
                //temp.transform.SetParent(transform,false);
                temp.transform.position = new Vector3(x * SPACE, y * SPACE, 0);
                figures[x,y] = temp;
                Debug.Log(figures[x, y]);
            }
        }
    }


}
