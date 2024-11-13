using UnityEngine;

public class GameOverMenu_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject gameOverMenu;

    void Start()
    {
        ShapeInstantiator_Script.ActivateGameOverScreen += ActivateGameOverScreen;
        gameOverMenu.SetActive(false);

    }

    // Update is called once per frame

    void ActivateGameOverScreen()
    {
        gameOverMenu.SetActive(true);
    }
    void Update()
    {

    }

    private void OnDestroy()
    {
        ShapeInstantiator_Script.ActivateGameOverScreen -= ActivateGameOverScreen;

    }
}
