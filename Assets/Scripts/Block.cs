using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockColor { red, blue, green, yellow, white };
public class Block : MonoBehaviour
{    
    public BlockColor blockColor;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseBlock contactBase = collision.gameObject.GetComponent<BaseBlock>();
        
        if(blockColor == BlockColor.white)
        {
            contactBase.ResetSize();
        }
        else if(contactBase.color == blockColor)
        {
            contactBase.AddSize(CalculateScale());
        }      

        else
        {
            //lose life
        }

        Destroy(this); //removes block after collision 
    }

    Vector2 CalculateScale()
    {
        Vector2 amountToAdd = new Vector2(0, 0);
        switch (blockColor)
        {
            case BlockColor.red:
                amountToAdd += new Vector2(1, 0);
                break;
            case BlockColor.blue:
                amountToAdd += new Vector2(1, 0);
                break;
            case BlockColor.yellow:
                amountToAdd += new Vector2(0, 1);
                break;
            case BlockColor.green:
                amountToAdd += new Vector2(0, 1);
                break;
        }
        
        return amountToAdd;
    }
}
