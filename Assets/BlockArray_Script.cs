using System;
using UnityEngine;

public class BlockArray_Script : MonoBehaviour

{
    public static event Action<GameObject[,]> SendArray;
    int maxY = 20;
    int maxX = 10;
    public GameObject[,] blockArray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // void SetInitialBlockPositioninArray(int y, int x, GameObject block)
    // {
    //     blockArray[y, x] = block;

    //     print($"y: {y} x: {x} {block}");


    // }

    private void Awake()
    {
        blockArray = new GameObject[maxY, maxX];
        // Block_Script.SendIndividualBlockPositionAtStart += SetInitialBlockPositioninArray;







    }
    private void OnEnable()
    {

    }

    void Start()
    {
        SendArray.Invoke(blockArray);
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








}
