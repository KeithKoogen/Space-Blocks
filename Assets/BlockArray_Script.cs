using System;
using UnityEngine;

public class BlockArray_Script : MonoBehaviour

{
    public static event Action<GameObject[,]> SendArray;

    int maxY = 30;
    int maxX = 12;
    public GameObject[,] blockArray;


    private void Awake()
    {
        blockArray = new GameObject[maxY, maxX];

        Block_Script.RemoveBlock += RemoveDestroyedBlockfromArray;


    }



    void Start()
    {
        SendArray.Invoke(blockArray);










    }
    void RemoveDestroyedBlockfromArray(int positionY, int positionX)
    {

        blockArray[positionY, positionX] = null;


    }

    // Update is called once per frame
    void Update()
    {
        SendArray.Invoke(blockArray);

    }

    private void OnApplicationQuit()
    {
        // for (int i = 0; i < 20; i++)
        // {
        //     string str = "";
        //     for (int j = 0; j < 10; j++)
        //     {
        //         if (blockArray[i, j] == null)
        //         {
        //             str += "0";
        //         }
        //         else
        //         {
        //             str += "x";
        //         }
        //     }
        //     print(str);

        // }

    }



    private void OnDestroy()
    {
        Block_Script.RemoveBlock -= RemoveDestroyedBlockfromArray;

    }






}
