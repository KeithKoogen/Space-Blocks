using System;
using UnityEngine;

public class ShapeController_Script : MonoBehaviour
{
    GameObject controlledGameobject;
    GameObject[,] CurrentblockArray;
    int MaxBlockLeft = 0;
    int MaxBlockRight = 9;
    // public DirectionofShape directionofshape;
    public enum DirectionofShape
    {
        left,
        right
    }




    void PassCurrentShapeToController(GameObject currentGameObject)
    {
        controlledGameobject = currentGameObject;

    }

    void MoveShapeLeftorRight(DirectionofShape direction)
    {


        int noObstruction = 0;
        int x_direction = 0;



        if (direction == DirectionofShape.left)
        {
            x_direction = -1;
        }
        if (direction == DirectionofShape.right)
        {
            x_direction = 1;
        }


        Block_Script[] childBlocks = controlledGameobject.GetComponentsInChildren<Block_Script>();


        foreach (Block_Script block in childBlocks)
        {
            if ((block.positionX + x_direction >= MaxBlockLeft) && (block.positionX + x_direction <= MaxBlockRight))
            {
                if (CurrentblockArray[block.positionY, block.positionX + x_direction] == null)
                {
                    ++noObstruction;
                }
                else
                {
                    if (CurrentblockArray[block.positionY, block.positionX + x_direction].transform.parent == gameObject.transform)
                    {
                        ++noObstruction;

                    }
                }
            }
        }

        if (noObstruction == controlledGameobject.transform.childCount && noObstruction != 0)
        {

            foreach (Block_Script block in childBlocks)
            {

                CurrentblockArray[block.positionY, block.positionX] = null;

            }
            controlledGameobject.transform.position += new Vector3(x_direction, 0, 0);

        }
    }



    void RotateShape()
    {


        int noObstruction = 0;
        int x_direction = 0;

        Block_Script[] childBlocks = controlledGameobject.GetComponentsInChildren<Block_Script>();














        foreach (Block_Script block in childBlocks)
        {
            if ((block.positionX >= MaxBlockLeft) && (block.positionX <= MaxBlockRight))
            {
                if (CurrentblockArray[block.positionY, block.positionX + x_direction] == null)
                {
                    ++noObstruction;
                }
                else
                {
                    if (CurrentblockArray[block.positionY, block.positionX + x_direction].transform.parent == gameObject.transform)
                    {
                        ++noObstruction;

                    }
                }
            }
        }

        if (noObstruction == controlledGameobject.transform.childCount && noObstruction != 0)
        {
            // foreach (Block_Script block in childBlocks)
            // {

            //     CurrentblockArray[block.positionY, block.positionX] = null;

            // }
            controlledGameobject.transform.Rotate(0, 0, 90);




        }
        else
        {
            // foreach (Block_Script block in childBlocks)
            // {

            //     CurrentblockArray[block.positionY, block.positionX] = null;

            // }
            controlledGameobject.transform.Rotate(0, 0, 180);
        }
    }


    void CurrentShapeController()
    {





        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveShapeLeftorRight(DirectionofShape.left);


        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveShapeLeftorRight(DirectionofShape.right);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotateShape();
        }






    }


    void PassBlockArraytoController(GameObject[,] blockArray)
    {
        CurrentblockArray = blockArray;
    }


    private void OnEnable()
    {
        BlockArray_Script.SendArray += PassBlockArraytoController;
        ShapeInstantiator_Script.SendCurrentShapeToController += PassCurrentShapeToController;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrentShapeController();

    }

    private void OnDestroy()
    {
        BlockArray_Script.SendArray -= PassBlockArraytoController;

    }
}
