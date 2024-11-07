using UnityEngine;
using TMPro;

public class TargetText_Script : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    int target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Awake()
    {
        ScoreTracker_Script.UpdateTargetDisplay += UpdateTarget;
    }
    void Start()
    {

    }
    void UpdateTarget(int targetFromScoreTracker)
    {
        target = targetFromScoreTracker;


    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(target.ToString("00"));
    }
}
