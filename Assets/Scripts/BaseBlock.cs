using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    public BlockColor color;
    [SerializeField] Transform pivotTransform; //transform of pivot point of block. Scale this to adjust size of block

    public void AddSize(Vector2 amount)
    {
        pivotTransform.localScale += new Vector3(amount.x, amount.y, 0f);
        
    }

    public void ResetSize()
    {
        int scoreToAdd = (int)(pivotTransform.localScale.x + pivotTransform.localScale.y) - 2; //-2 because scale starts at 1 for both x and y
        GameControl.control.UpdateScore(scoreToAdd);

        pivotTransform.localScale = new Vector3(1f, 1f, 1f);
        
    }
}
