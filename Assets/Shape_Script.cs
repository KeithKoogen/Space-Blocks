using System;
using Unity.VisualScripting;
using UnityEngine;

public class Shape_Script : MonoBehaviour
{
    public float fallSpeed = 0.4f;
    float timer = 0;
    int hasStoppedCount = 0;
    public static event Action InstantiateNewShape;
    public static event Action<GameObject[,]> SendArraytoBlockDestroyer;


    // bool allowmove = false;


    void ShapecanMove(GameObject[,] blockArray)
    {
        if (gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }


        int lowestBlockinShape = 100;
        int mostLeftBlockinShape = 100;
        int mostRightBlockinShape = 100;
        int noObstruction = 0;


        Block_Script[] childBlocks = GetComponentsInChildren<Block_Script>();

        // foreach (Block_Script block in childBlocks)
        // {
        //     blockArray[block.positionY, block.positionX] = block.gameObject;
        // }




        // Loop through each block and find the lowest block in the shape
        foreach (Block_Script block in childBlocks)
        {
            if (lowestBlockinShape == 100)
            {
                lowestBlockinShape = block.positionY;

            }
            else if (lowestBlockinShape > block.positionY)
            {
                lowestBlockinShape = block.positionY;
            }
        }

        // Loop through each block and find the most left block in the shape

        foreach (Block_Script block in childBlocks)
        {
            if (mostLeftBlockinShape == 100)
            {
                mostLeftBlockinShape = block.positionX;

            }
            else if (mostLeftBlockinShape > block.positionX)
            {
                mostLeftBlockinShape = block.positionX;
            }
        }

        // Loop through each block and find the most right block in the shape

        foreach (Block_Script block in childBlocks)
        {
            if (mostRightBlockinShape == 100)
            {
                mostRightBlockinShape = block.positionX;

            }
            else if (mostRightBlockinShape < block.positionX)
            {
                mostRightBlockinShape = block.positionX;
            }
        }




        // if a part of the shape ends up outside the boundary move it back inside
        // this accounts for shapes that are rotated, because when they are rotated the fall outside of the boundary some times

        if (mostLeftBlockinShape < 0 || mostRightBlockinShape > 9)
        {
            if (mostLeftBlockinShape < 0)
            {
                foreach (Block_Script block in childBlocks)
                {
                    if (block.positionX != mostLeftBlockinShape)
                    {
                        blockArray[block.positionY, block.positionX] = null;

                    }



                }
                transform.position += new Vector3(1, 0, 0);
            }


            if (mostRightBlockinShape > 9)
            {
                foreach (Block_Script block in childBlocks)
                {

                    if (block.positionX != mostRightBlockinShape)
                    {
                        blockArray[block.positionY, block.positionX] = null;

                    }

                }
                transform.position += new Vector3(-1, 0, 0);
            }

        }





        foreach (Block_Script block in childBlocks)
        {
            if (lowestBlockinShape > 1)
            {
                if (blockArray[block.positionY - 1, block.positionX] == null)
                {
                    ++noObstruction;
                }
                else
                {
                    if (blockArray[block.positionY - 1, block.positionX].transform.parent == gameObject.transform)
                    {
                        ++noObstruction;
                    }
                }
            }

        }



        // check to see if there is space between blocks and make blocks move down if there is














        if (noObstruction == gameObject.transform.childCount && noObstruction != 0 && lowestBlockinShape > 1)
        {

            foreach (Block_Script block in childBlocks)
            {

                blockArray[block.positionY, block.positionX] = null;


            }
            MoveDown();



        }


        else
        {

            foreach (Block_Script block in childBlocks)
            {





                blockArray[block.positionY, block.positionX] = block.gameObject;



            }






            ++hasStoppedCount;
            if (hasStoppedCount == 1)
            {

                SendArraytoBlockDestroyer.Invoke(blockArray);

                InstantiateNewShape.Invoke();

            }





        }
    }


    void FillBlockwithHoles(GameObject[,] blockArray)
    {





        if (this)
        {
            Block_Script[] childBlocks = GetComponentsInChildren<Block_Script>();
            int lowestBlockinShape = 100;
            bool blockhasmoved = false;

            foreach (Block_Script block in childBlocks)
            {
                if (lowestBlockinShape == 100)
                {
                    lowestBlockinShape = block.positionY;

                }
                else if (lowestBlockinShape > block.positionY)
                {
                    lowestBlockinShape = block.positionY;
                }
            }

            foreach (Block_Script block in childBlocks)
            {
                int sameBlocksOnLine = 0;
                int blockswithspacesbelowinshape = 0;
                if (blockArray[block.positionY, block.positionX] != null)
                {
                    if (block.positionY != lowestBlockinShape && block.positionY > 1)
                    {
                        if (blockArray[block.positionY - 1, block.positionX] == null)
                        {
                            sameBlocksOnLine = 0;
                            blockswithspacesbelowinshape = 0;

                            for (int i = 0; i < 10; i++)
                            {

                                if (blockArray[block.positionY, i] != null && blockArray[block.positionY, i].transform.parent == blockArray[block.positionY, block.positionX].transform.parent)
                                {



                                    ++sameBlocksOnLine;

                                    if (blockArray[block.positionY - 1, i] == null)
                                    {
                                        ++blockswithspacesbelowinshape;

                                    }

                                }
                            }

                            if (sameBlocksOnLine == blockswithspacesbelowinshape && sameBlocksOnLine != 0)
                            {




                                for (int i = 0; i < 10; i++)
                                {
                                    if (blockArray[block.positionY, i] != null)
                                    {


                                        if (blockArray[block.positionY, i]?.transform.parent == blockArray[block.positionY, block.positionX]?.transform.parent)
                                        {
                                            if (block.positionY > 1)
                                            {
                                                int k = block.positionY;
                                                while (blockArray?[k - 1, i] == null && k > 1)
                                                {
                                                    if (blockArray[k, i] != null)
                                                    {

                                                        blockArray[k - 1, i] = blockArray[k, i];

                                                        blockArray[k, i].transform.position += new Vector3(0, -1, 0);
                                                        blockhasmoved = true;


                                                        blockArray[k, i] = null;


                                                    }
                                                    --k;

                                                }

                                            }

                                        }

                                    }

                                }
                            }

                            if (blockhasmoved == true)
                            {
                                SendArraytoBlockDestroyer.Invoke(blockArray);
                                blockhasmoved = false;
                            }
                            // else
                            // {
                            //     SendArraytoBlockDestroyer.Invoke(blockArray);

                            // }


                        }


                    }


                }


            }
        }

    }
    void MoveDown()
    {
        timer += Time.deltaTime;


        if (timer >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            timer = 0;
        }
    }

    private void OnEnable()
    {
        BlockArray_Script.SendArray += ShapecanMove;

    }

    void Start()
    {

        BlockArray_Script.SendArray += FillBlockwithHoles;
        BlockDestroyer_Script.SendArraytoCheckforHolesAfterDestroyLine += FillBlockwithHoles;



    }

    private void OnDestroy()
    {
        BlockArray_Script.SendArray -= ShapecanMove;
        BlockArray_Script.SendArray -= FillBlockwithHoles;
        BlockDestroyer_Script.SendArraytoCheckforHolesAfterDestroyLine -= FillBlockwithHoles;


    }


    void Update()
    {


    }
}
