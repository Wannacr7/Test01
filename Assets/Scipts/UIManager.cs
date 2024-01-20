using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text clicks;
    [SerializeField] TMP_Text time;

    public void UpdateClickCount(int _clickCount) => clicks.text = "Total Clicks: " + _clickCount.ToString("000");
    public void UpdateTimeElapsed(float _time) => time.text = "Time Elapsed: " + _time.ToString("000.00");

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

}
