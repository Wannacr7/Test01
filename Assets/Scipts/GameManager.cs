using Assets.Scipts.Models;
using System.Collections;
using System.Collections.Generic;
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
            if (rc >= 2 && rc <= 8)
            {
                Debug.Log(rc);
                board.GenerateBoard(gameData);
            }
            else
            {
                Debug.LogError("Out of Range");
            }
        }
        else
        {
            Debug.LogError("Game Data Null");
        }
    }

 
}
