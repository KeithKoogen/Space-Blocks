using System;
using UnityEngine;

public class Block_Script : MonoBehaviour
{
    int OffsetY = 9;
    int OffsetX = 5;
    public int positionY;
    public int positionX;

    // public static event Action<int, int, GameObject> SendIndividualBlockPositionAtStart;



    void UpdateBlockPosition()
    {

        positionX = Mathf.RoundToInt(transform.position.x) + OffsetX;
        positionY = Mathf.RoundToInt(transform.position.y) + OffsetY;


    }

    // void BlockCanMove(GameObject[,] blockArray)
    // {
    //     if (positionY > 1 && blockArray[positionY - 1, positionX] == null)
    //     {
    //         if ((blockArray[positionY, positionX - 1] == null || blockArray[positionY, positionX - 1].transform.parent != gameObject.transform.parent)
    //         &&
    //         (blockArray[positionY, positionX + 1] == null || blockArray[positionY, positionX + 1].transform.parent != gameObject.transform.parent) &&
    //        (blockArray[positionY + 1, positionX].transform.parent != gameObject.transform.parent))
    //         {
    //             blockArray[positionY, positionX] = null;
    //             gameObject.transform.position += new Vector3(0, -1, 0);



    //         }
    //     }

    // }



    private void Awake()
    {
        // BlockArray_Script.SendArray += BlockCanMove;
        UpdateBlockPosition();






    }

    private void OnEnable()
    {
        // UpdateBlockPosition();



    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // SendIndividualBlockPositionAtStart.Invoke(positionY, positionX);
        UpdateBlockPosition();
        // SendIndividualBlockPositionAtStart.Invoke(positionY, positionX, this.gameObject);










    }

    // Update is called once per frame
    void Update()
    {
        UpdateBlockPosition();






    }

    private void OnDestroy()
    {

    }
}
