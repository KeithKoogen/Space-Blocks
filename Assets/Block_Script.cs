using System;
using UnityEngine;

public class Block_Script : MonoBehaviour
{
    int OffsetY = 9;
    int OffsetX = 5;
    public int positionY;
    public int positionX;


    void UpdateBlockPosition()
    {

        positionX = Mathf.RoundToInt(transform.position.x) + OffsetX;
        positionY = Mathf.RoundToInt(transform.position.y) + OffsetY;


    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        UpdateBlockPosition();



    }

    // Update is called once per frame
    void Update()
    {
        UpdateBlockPosition();






    }

    private void OnDestroy()
    {

    }
}
