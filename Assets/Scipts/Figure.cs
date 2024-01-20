using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Figure : MonoBehaviour
{
    public static UnityAction<Block> onFLipFigure;
    [SerializeField] private FigureData figureData;
    [SerializeField] Sprite cover;

    //public int row;
    //public int column;
    ///public int number;
    public Block figureVars;
    private bool matched = false;

    private void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = cover;
    }


    public void AssigFigure(int _row,int _column, int _num)
    {
        figureVars.R = _row;
        figureVars.C = _column;
        figureVars.Number = _num;
        
    }

    public void FLipFigure()
    {
        if (!matched)
        {
            this.gameObject.GetComponent<Image>().sprite = figureData.figures.Find(a => a.id == figureVars.Number).image;
            onFLipFigure?.Invoke(figureVars);

        }

    }
    
    public void ResetFigure()
    {
        this.gameObject.GetComponent<Image>().sprite = cover;
    }
    public void MatchFigure()
    {
        matched = true;
        this.gameObject.GetComponent<Image>().color = Color.green;
    }



}
