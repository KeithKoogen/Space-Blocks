using System;
using UnityEngine;

public class Shape_Script : MonoBehaviour
{
    float fallSpeed = 0.4f;
    float timer = 0;
    bool allowmove = false;


    void ShapecanMove(GameObject[,] blockArray)
    {
        if (gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }

        int lowestBlockinShape = 0;
        int checkCounter = 0;
        int blockCounter = 0;
        int noObstruction = 0;


        Block_Script[] childBlocks = GetComponentsInChildren<Block_Script>();







        // Loop through each block and find the lowest block in the shape
        foreach (Block_Script block in childBlocks)
        {
            if (lowestBlockinShape == 0)
            {
                lowestBlockinShape = block.positionY;
            }
            else if (lowestBlockinShape > block.positionY)
            {
                lowestBlockinShape = block.positionY;

            }

        }

        // check if all the blocks at the lowest point dont have anything obstruction them
        foreach (Block_Script block in childBlocks)
        {
            if (lowestBlockinShape == block.positionY)
            {
                ++blockCounter;

                if (blockArray[block.positionY - 1, block.positionX] == null)
                {
                    checkCounter++;
                }

            }


        }


        // if all the blocks in the shape dont have anything obstructing the shape must move


        if ((blockCounter == checkCounter) && (blockCounter != 0) && lowestBlockinShape > 1)
        {


            foreach (Block_Script block in childBlocks)
            {
                if (blockArray[block.positionY - 1, block.positionX] == null || blockArray[block.positionY - 1, block.positionX].transform.parent == gameObject)
                {
                    ++noObstruction;
                }
            }

            if (noObstruction == gameObject.transform.childCount && noObstruction != 0)
            {

                foreach (Block_Script block in childBlocks)
                {




                    blockArray[block.positionY, block.positionX] = null;




                }
                print($"no obstruction {noObstruction}");
                print($"child count {gameObject.transform.childCount}");

                //check if all the blocks in the shape are not obstructed by any other block, if the block is in front and belongs to the same parent we ignore it
                // allowmove = true;
                MoveShape();
            }
            else
            {
                foreach (Block_Script block in childBlocks)
                {



                    blockArray[block.positionY, block.positionX] = block.gameObject;



                }
            }

            // before we move the block we should store the blocks we want to move first in a temporaray variable
            // then we should make all those current locations null
            // when it stops again we should s













        }
        else
        {
            foreach (Block_Script block in childBlocks)
            {



                blockArray[block.positionY, block.positionX] = block.gameObject;



            }

        }
    }
    void MoveShape()
    {
        timer += Time.deltaTime;


        if (timer >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            timer = 0;

        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BlockArray_Script.SendArray += ShapecanMove;

    }

    private void OnDestroy()
    {
        BlockArray_Script.SendArray -= ShapecanMove;

    }

    // Update is called once per frame
    void Update()
    {


    }
}
