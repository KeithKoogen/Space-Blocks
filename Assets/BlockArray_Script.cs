using System;
using UnityEngine;

public class BlockArray_Script : MonoBehaviour

{
    public static event Action<GameObject[,]> SendArray;
    int maxY = 20;
    int maxX = 10;
    GameObject[,] blockArray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        blockArray = new GameObject[maxY, maxX];


    }

    // Update is called once per frame
    void Update()
    {
        SendArray.Invoke(blockArray);




    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < 20; i++)
        {
            string str = "";
            for (int j = 0; j < 10; j++)
            {
                if (blockArray[i, j] == null)
                {
                    str += "0";
                }
                else
                {
                    str += "x";
                }
            }
            print(str);

        }

    }








}
