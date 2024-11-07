using UnityEngine;
using TMPro;
public class LevelText_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TMP_Text text;
    int level = 1;

    private void Awake()
    {
        ScoreTracker_Script.UpdateLevelDisplay += UpdateLevel;
    }


    void UpdateLevel(int levelfromScoreTracker)
    {
        level = levelfromScoreTracker;

    }
    void Start()
    {
        text.SetText(level.ToString("00"));


    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(level.ToString("00"));

    }
}
