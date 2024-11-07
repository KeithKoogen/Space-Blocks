using System;
using UnityEngine;

public class ScoreTracker_Script : MonoBehaviour
{
    int score = 0;
    int target = 20;
    int level = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action<int> UpdateScoreDisplay;
    public static event Action<int> UpdateTargetDisplay;
    public static event Action<int> UpdateLevelDisplay;
    void Start()
    {

        BlockDestroyer_Script.NumberofRowsDestroyed += UpdateScore;

        UpdateTargetDisplay?.Invoke(target);

    }

    void UpdateScore(int rowsDestroyed)
    {


        score += rowsDestroyed;
        UpdateScoreDisplay?.Invoke(score);




        target -= rowsDestroyed;
        UpdateTargetDisplay?.Invoke(target);

        if (target <= 0)
        {
            ++level;
            target = 20;
            UpdateLevelDisplay.Invoke(level);
        }





    }



    // Update is called once per frame
    void Update()
    {


    }
}
