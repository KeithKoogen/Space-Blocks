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

    void ShapeInstantiotor()
    {

        currentGameObject = Instantiate(Shape1[UnityEngine.Random.Range(0, Shape1.Length)], this.gameObject.transform.position, this.gameObject.transform.rotation);
        // currentGameObject.name = gameObjectNumber.ToString();
        // gameObjectNumber++;

        SendCurrentShapeToController.Invoke(currentGameObject);





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
}
