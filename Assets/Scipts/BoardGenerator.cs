
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject figure;
    //(rc) rows and columns are betwen 2 and 8
    private int row;
    private int col;
    
    
    
    
    public List<GameObject> figures;
    private const float MIN_SPACE = 2f;
    private float spaceFigures;



    public void GenerateBoard( Data _data, int _row, int _col)
    {
        row = _row; 
        col = _col; 
        
        figures = new List<GameObject>();
        var scale = Vector3.one;
        if ((row*col) > 16) scale = new Vector3 (.6f, .6f, .6f);
        spaceFigures = CalculateFiguresSpace(scale.x);
        //Debug.Log(spaceFigures);



        float offsetX = (row) * spaceFigures * 0.5f;
        float offsetY = (col) * spaceFigures * 0.5f;

        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < col; y++)
            {

                Block block = _data.Blocks.Find(b => b.R == x + 1 && b.C == y + 1);
                //Debug.Log(block.Number);

                var temp = Instantiate(figure,transform,false);

                temp.GetComponent<Figure>().AssigFigure(x, y, block.Number);

                float xPos = y * spaceFigures - offsetX ;
                float yPos = x * spaceFigures - offsetY;

                temp.transform.localScale = scale;
                //Debug.Log(temp.transform.localScale);
                temp.transform.position = new Vector3(xPos, -yPos, 0);
                //Debug.Log(temp.transform.position);

                figures.Add(temp);

            }
        }
    }
    private float CalculateFiguresSpace(float _scale)
    {
        return Mathf.Min(MIN_SPACE, _scale * 2f);
    }

 


}
