using Unity.VisualScripting;
using UnityEngine;

public class ShapeInstantiator_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject[] Shape1;
    int gameObjectNumber = 0;
    GameObject currentGameObject;

    void ShapeInstantiotor()
    {

        currentGameObject = Instantiate(Shape1[Random.Range(0, Shape1.Length)], this.gameObject.transform.position, this.gameObject.transform.rotation);
        currentGameObject.name = gameObjectNumber.ToString();
        gameObjectNumber++;




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
