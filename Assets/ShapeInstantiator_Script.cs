using Unity.VisualScripting;
using UnityEngine;
using System;

public class ShapeInstantiator_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject[] Shape1;
    // int gameObjectNumber = 0;
    GameObject currentGameObject;

    public static event Action<GameObject> SendCurrentShapeToController;
    public static event Action ActivateGameOverScreen;
    bool canInstantiate = true;
    private void Awake()
    {
        BlockArray_Script.SendArray += CheckifTopBlockfilled;
    }

    void ShapeInstantiotor()
    {

        if (canInstantiate == true)
        {
            currentGameObject = Instantiate(Shape1[UnityEngine.Random.Range(0, Shape1.Length)], this.gameObject.transform.position, this.gameObject.transform.rotation);
            // currentGameObject.name = gameObjectNumber.ToString();
            // gameObjectNumber++;

            SendCurrentShapeToController.Invoke(currentGameObject);

        }
        else
        {
            SendCurrentShapeToController.Invoke(null);
            ActivateGameOverScreen.Invoke();

        }






    }

    void CheckifTopBlockfilled(GameObject[,] blockArray)
    {
        for (int x = 0; x < 10; x++)
        {
            if (blockArray[21, x] != null)
            {
                canInstantiate = false;
            }

        }


    }
    void Start()
    {
        Shape_Script.InstantiateNewShape += ShapeInstantiotor;

        ShapeInstantiotor();





    }



    // Update is called once per frame
    void Update()
    {




    }

    private void OnDestroy()
    {
        Shape_Script.InstantiateNewShape -= ShapeInstantiotor;
        BlockArray_Script.SendArray -= CheckifTopBlockfilled;
    }
}
