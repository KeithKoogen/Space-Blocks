using System;
using UnityEngine;

public class BlockDestroyer_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int blockRowCounter = 0;
    int rowsDestroyedcounter = 0;
    public static event Action<int> NumberofRowsDestroyed;

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
                        blockArray[i, k] = null;




                    }
                }

            }
            blockRowCounter = 0;



        }




    }
    void Start()
    {
        BlockArray_Script.SendArray += FindBlocksToDestroy;

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
