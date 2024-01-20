
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static UnityAction onPairMatch;
    public static UnityAction onPairNoMatch;

    private Data gameData;
    [SerializeField] GameObject figures;
    [SerializeField] BoardGenerator board;
    [SerializeField] DataLoader loader;


    

    //Gameplay variables
    private bool isSecond = false;
    private bool isFirst = true;
    private Block firstPair;
    private Block secondPair;


    private void Start()
    {
        SetupGame();
    }
    private void OnEnable()
    {
        Figure.onFLipFigure += CompareFigures;
    }
    private void OnDisable()
    {
        Figure.onFLipFigure -= CompareFigures;
    }
    private void SetupGame()
    {
        gameData = loader.LoadJsonFromStreamingAssets();
        var rc = gameData.Blocks.Count / 2;
        if (gameData != null)
        {
            //Here code validations of rows and colums
            board.GenerateBoard(gameData, GetMaxRows(gameData), GetMaxColumn(gameData));
        }
        else
        {
            Debug.LogError("Game Data Null");
        }
    }
    private void CompareFigures(Block _figure)
    {

        if (!isSecond)
        {
            firstPair = _figure;
            isSecond = true;
            Figure.OnclickHandler?.Invoke(true);
        }
        else
        {
            
            secondPair = _figure;
            isSecond = false;
            if (firstPair.Number == secondPair.Number)
            {
                board.figures.Find(b => b.GetComponent<Figure>().figureVars == firstPair).GetComponent<Figure>().MatchFigure();
                board.figures.Find(b => b.GetComponent<Figure>().figureVars == secondPair).GetComponent<Figure>().MatchFigure();
            }
            else
            {
                board.figures.Find(b => b.GetComponent<Figure>().figureVars == firstPair).GetComponent<Figure>().ResetFigure();
                board.figures.Find(b => b.GetComponent<Figure>().figureVars == secondPair).GetComponent<Figure>().ResetFigure();

            }
            Figure.OnclickHandler?.Invoke(true);
        }

        Debug.Log(firstPair + "  " + secondPair);
        
    }

    




    private int GetMaxRows(Data _data)
    {
        return _data.Blocks.OrderByDescending(b => b.R).FirstOrDefault().R;
    }
    private int GetMaxColumn(Data _data)
    {
        return _data.Blocks.OrderByDescending(b => b.C).FirstOrDefault().C;
    }


}
