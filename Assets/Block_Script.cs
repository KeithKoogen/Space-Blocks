using System;
using UnityEngine;

public class Block_Script : MonoBehaviour
{
    int OffsetY = 10;
    int OffsetX = 6;
    public int positionY;
    public int positionX;
    public static event Action<int, int> RemoveBlock;
    bool gameIsOverChecker = false;







    void UpdateBlockPosition()
    {
        if (gameObject != null)
        {
            positionX = Mathf.RoundToInt(transform.position.x) + OffsetX;
            positionY = Mathf.RoundToInt(transform.position.y) + OffsetY;

        }




    }





    private void Awake()
    {

        UpdateBlockPosition();
        ShapeInstantiator_Script.ActivateGameOverScreen += GameisOver;






    }

    private void OnEnable()
    {




    }




    void Start()
    {

        UpdateBlockPosition();









    }
    void GameisOver()
    {
        gameIsOverChecker = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBlockPosition();






    }
    private void OnDisable()
    {










    }



    private void OnDestroy()
    {
        if (gameIsOverChecker == false)
        {
            RemoveBlock.Invoke(positionY, positionX);


        }
        ShapeInstantiator_Script.ActivateGameOverScreen -= GameisOver;











    }
}
