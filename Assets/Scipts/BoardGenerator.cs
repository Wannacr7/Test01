using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject figure;
    //(rc) rows and columns are betwen 2 and 8
    [SerializeField] private int rc;
    
    
    
    private GameObject[,] figures;
    private const float MIN_SPACE = 2f;
    private float spaceFigures;


    private void Start()
    {
        figures = new GameObject[rc,rc];
        GenerateBoard();
    }

    public void GenerateBoard()
    {
        var scale = Vector3.one;
        if (rc > 4) scale = new Vector3 (.6f, .6f, .6f);
        spaceFigures = CalculateFiguresSpace(scale.x);
        //Debug.Log(spaceFigures);



        float offsetX = (rc - 1) * spaceFigures * 0.5f;
        float offsetY = (rc - 1) * spaceFigures * 0.5f;

        for (int x = 0; x < rc; x++)
        {
            for (int y = 0; y < rc; y++)
            { 
                var temp = Instantiate(figure,transform,false);

                float xPos = y * spaceFigures - offsetX ;
                float yPos = x * spaceFigures - offsetY;

                temp.transform.localScale = scale;
                //Debug.Log(temp.transform.localScale);
                temp.transform.position = new Vector3(xPos, yPos, 0);
                //Debug.Log(temp.transform.position);

                figures[x,y] = temp;

            }
        }
    }
    private float CalculateFiguresSpace(float _scale)
    {
        return Mathf.Min(MIN_SPACE, _scale * 2f);
    }


}
