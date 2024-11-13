using System;
using UnityEngine;

public class BlockDestroyer_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int blockRowCounter = 0;
    int rowsDestroyedcounter = 0;
    public static event Action<int> NumberofRowsDestroyed;
    public static event Action<GameObject[,]> SendArraytoCheckforHolesAfterDestroyLine;
    public float fallSpeed = 0.4f;
    bool lineDestroyed = false;



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
                    lineDestroyed = true;

                    for (int k = 0; k < 10; k++)
                    {

                        // reset blocks if there are are the same
                        for (int a = 0; a < 20; a++)
                        {
                            for (int b = 0; b < 10; b++)
                            {
                                if (blockArray[a, b] == blockArray[i, k] && a != i && b != k)
                                {
                                    blockArray[a, b] = null;
                                }

                            }
                        }





                        Destroy(blockArray[i, k]);

                        // blockArray[i, k] = null;









                    }









                }

            }

            blockRowCounter = 0;




            // FindBlocksWithHolesinThem(blockArray);
        }


        // for (int i = 0; i < 20; i++)
        // {
        //     for (int j = 0; j < 10; j++)
        //     {
        //         if (blockArray[i, j] != null)
        //         {
        //             if (i > 1 && blockArray[i - 1, j] == null)
        //             {
        //                 SendArraytoCheckforHolesAfterDestroyLine.Invoke(blockArray);

        //             }


        //         }


        //     }


        // }



        if (lineDestroyed == true)
        {
            // SendArraytoCheckforHolesAfterDestroyLine?.Invoke(blockArray);

            NumberofRowsDestroyed.Invoke(rowsDestroyedcounter);
            rowsDestroyedcounter = 0;

            lineDestroyed = false;

        }




    }





    void Start()
    {

        Shape_Script.SendArraytoBlockDestroyer += FindBlocksToDestroy;


    }

    // Update is called once per frame
    void Update()
    {


    }
}
