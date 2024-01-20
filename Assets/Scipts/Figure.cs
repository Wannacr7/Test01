using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Figure : MonoBehaviour
{
    [SerializeField] private FigureData figureData;
    [SerializeField] Sprite cover;

    public int row;
    public int column;
    public int number;

    private void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = cover;
    }




    public void AssigFigure(int _row,int _column, int _num)
    {
        row = _row;
        column = _column;
        number = _num;
        
    }

    public void FLipFigure()
    {
        this.gameObject.GetComponent<Image>().sprite = figureData.figures.Find(a => a.id == number).image;
    }



}
