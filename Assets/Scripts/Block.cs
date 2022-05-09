using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockColor { red, blue, green, yellow, white };
public class Block : MonoBehaviour
{
    public bool baseBlock;
    public BlockColor blockColor;


    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BlockColor collisionColor = collision.gameObject.GetComponent<Block>().blockColor;
        if(blockColor == BlockColor.white)
        {
            //clear
        }
        else if(collisionColor == blockColor)
        {
           //attach
        }      

        else
        {
            //lose life
        }
    }
}
