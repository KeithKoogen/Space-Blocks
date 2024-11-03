using UnityEngine;

public class BlockDestroyer_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int blockRowCounter = 0;
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
                    for (int k = 0; k < 10; k++)
                    {
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

    }
}
