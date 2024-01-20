
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    [SerializeField] UIManager uiManager;

    //tracking variables
    private int clickCounter;
    private float timer;
    private bool startTimer = false;
    private float points;

    //Gameplay variables
    private bool isSecond = false;
    private Block firstPair;
    private Block secondPair;

    //Winner cond  variables
    private int matches;

    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            uiManager.UpdateTimeElapsed(timer);
        } 
    }
    private void OnEnable()
    {
        Figure.onFLipFigure += CompareFigures;
        Figure.OnclickHandler += CountClicks;
    }
    private void OnDisable()
    {
        Figure.onFLipFigure -= CompareFigures;
        Figure.OnclickHandler -= CountClicks;
    }
    public void SetupGame()
    {
        gameData = loader.LoadJsonFromStreamingAssets();
        var rc = gameData.Blocks.Count / 2;
        if (gameData != null)
        {
            if(GetMaxRows(gameData) >= 2 && GetMaxRows(gameData) <= 8 && GetMaxColumn(gameData) >= 2 && GetMaxColumn(gameData) <= 8)
            {
                board.GenerateBoard(gameData, GetMaxRows(gameData), GetMaxColumn(gameData));
                startTimer = true;
            }
            else
            {
                Debug.LogError("Game Data Not Valid");
                uiManager.RestartGame();
            }
                

            
        }
        else
        {
            Debug.LogError("Game Data Null");
            uiManager.RestartGame();
        }
    }

    private void HandleGameWin()
    {
        Debug.Log("The game has finished");
        startTimer = false;
        CalculateScore();
        SaveDataGame();
        uiManager.ShowScore(points);
        //uiManager.RestartGame();
    }

    private void SaveDataGame()
    {
        Results results = new Results
        {
            total_clicks = clickCounter,
            total_time = timer,
            pairs = matches,
            score = points
        };
        string json = JsonUtility.ToJson(results, true);
        string path = Path.Combine(Application.streamingAssetsPath, "gameResult.json");
        File.WriteAllText(path, json);
    }

    private void CalculateScore()
    {
        points = (matches * 2) - (clickCounter - timer * .2f);
        Debug.Log(points);
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
                matches++;
                if (matches == gameData.Blocks.Count/2)
                {
                    HandleGameWin();
                }
            }
            else
            {
                board.figures.Find(b => b.GetComponent<Figure>().figureVars == firstPair).GetComponent<Figure>().ResetFigure();
                board.figures.Find(b => b.GetComponent<Figure>().figureVars == secondPair).GetComponent<Figure>().ResetFigure();

            }
            Figure.OnclickHandler?.Invoke(true);
        }


        
    }

    




    private int GetMaxRows(Data _data)
    {
        return _data.Blocks.OrderByDescending(b => b.R).FirstOrDefault().R;
    }
    private int GetMaxColumn(Data _data)
    {
        return _data.Blocks.OrderByDescending(b => b.C).FirstOrDefault().C;
    }
    private void CountClicks(bool _click)
    {
        if (!_click)
        {
            clickCounter++;
            uiManager.UpdateClickCount(clickCounter);
        } 
    }



}
