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
        pivotTransform.localScale = new Vector3(1f, 1f, 1f);
        //update score
    }
}
