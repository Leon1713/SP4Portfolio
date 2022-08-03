using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;

    private void Start()
    {
        Score = 0;
    }

    public string getScore()
    {
        return Score.ToString();
    }
 
}
