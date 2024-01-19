using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] private ScriptableObject figureData;
    [SerializeField] Sprite cover;

    public int row;
    public int column;
    public int number;

    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = cover;
    }



    public void AssigFigure(int _row,int _column, int _num)
    {
        row = _row;
        column = _column;
        number = _num;
    }

}
