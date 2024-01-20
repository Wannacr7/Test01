
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Data gameData;
    [SerializeField] GameObject figures;
    [SerializeField] BoardGenerator board;
    [SerializeField] DataLoader loader;
    private void Start()
    {
        SetupGame();
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

    private int GetMaxRows(Data _data)
    {
        return _data.Blocks.OrderByDescending(b => b.R).FirstOrDefault().R;
    }
    private int GetMaxColumn(Data _data)
    {
        return _data.Blocks.OrderByDescending(b => b.C).FirstOrDefault().C;
    }


}
