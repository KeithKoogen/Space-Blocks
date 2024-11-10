using System;
using UnityEngine;

public class BlockDestroyer_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int blockRowCounter = 0;
    int rowsDestroyedcounter = 0;
    public static event Action<int> NumberofRowsDestroyed;
    public float fallSpeed = 0.4f;



    void FindBlocksToDestroy(GameObject[,] blockArray)
    {

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (blockArray[i, j] != null)
                {
                    ++blockRowCounter;
                }
                if (blockRowCounter == 10)
                {
                    ++rowsDestroyedcounter;

                    for (int k = 0; k < 10; k++)
                    {

                        // reset blocks if there are are the same
                        // for (int a = 0; a < 20; a++)
                        // {
                        //     for (int b = 0; b < 10; b++)
                        //     {
                        //         if (blockArray[a, b] == blockArray[i, k] && a != i && b != k)
                        //         {
                        //             blockArray[a, b] = null;
                        //         }

                        //     }

                        // }


                        Destroy(blockArray[i, k]);

                        blockArray[i, k] = null;








                    }



                }

            }

            blockRowCounter = 0;
            // FindBlocksWithHolesinThem(blockArray);
        }








    }

    // void FindBlocksWithHolesinThem(GameObject[,] blockArray)
    // {
    //     bool hasConnectedBlock = false;
    //     for (int y = 0; y < 20; y++)
    //     {
    //         for (int x = 0; x < 10; x++)
    //         {

    //             if (blockArray[y, x] != null && y > 2 && blockArray[y - 1, x] == null)
    //             {
    //                 for (int j = 0; j < 10; j++)
    //                 {
    //                     if (blockArray[y, j] != null)
    //                     {
    //                         if (j != x && blockArray[y, x].transform.parent == blockArray[y, j].transform.parent)
    //                         {
    //                             hasConnectedBlock = true;

    //                         }
    //                     }
    //                 }


    //                 for (int i = y - 1; i > 0; i--)
    //                 {

    //                     // for (int k = 0; k < 10; k++)
    //                     // {
    //                     // if (blockArray[i, x] != null)
    //                     // {

    //                     for (int k = 0; k < 10; k++)
    //                     {

    //                         if (blockArray[i, k] != null)
    //                         {
    //                             if (blockArray[y, x] != null)
    //                             {
    //                                 if (blockArray[i, k].transform.parent == blockArray[y, x].transform.parent && hasConnectedBlock == false)
    //                                 {
    //                                     print($"{blockArray[y, x].transform.parent.name}block has space in it");


    //                                     blockArray[y, x].transform.position += new Vector3(0, -1, 0);


    //                                     // blockArray[y - 1, x] = blockArray[y, x];



    //                                     blockArray[y, x] = null;



    //                                 }


    //                             }




    //                         }


    //                     }


    //                     // print($"ik {i} {blockArray[i, k].transform.parent} ");
    //                     // print($"yx {y} {blockArray[y, x].transform.parent}");

    //                     // }


    //                     // }


    //                 }




    //             }



    //         }

    //     }



    // }



    void Start()
    {
        BlockArray_Script.SendArray += FindBlocksToDestroy;
        // BlockArray_Script.SendArray += FindBlocksWithHolesinThem;

    }

    // Update is called once per frame
    void Update()
    {
        if (rowsDestroyedcounter > 0)
        {
            NumberofRowsDestroyed?.Invoke(rowsDestroyedcounter);
            rowsDestroyedcounter = 0;

        }

    }
}
