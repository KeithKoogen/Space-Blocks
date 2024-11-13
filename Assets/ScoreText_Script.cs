using TMPro;
using UnityEngine;

public class ScoreText_Script : MonoBehaviour
{
    [SerializeField] TMP_Text myText;
    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void UpdateScore(int scorefromScoreTracker)
    {
        score = scorefromScoreTracker;

    }
    void Start()
    {
        ScoreTracker_Script.UpdateScoreDisplay += UpdateScore;


    }

    // Update is called once per frame
    void Update()
    {
        myText.SetText(score.ToString("0000"));


    }
    private void OnDestroy()
    {
        ScoreTracker_Script.UpdateScoreDisplay -= UpdateScore;

    }
}
