using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject playerBox;
    Transform boxTransform;

    public bool rotating;
    public float rotateSpeed;
    float defaultRotateSpeed;
    
    Quaternion target;
    Vector3 oldRotation;
    Vector3 targetAngle;
    float t;

    void Awake()
    {
        boxTransform = playerBox.GetComponent<Transform>();
        defaultRotateSpeed = rotateSpeed;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating)
        {
            t += (Time.deltaTime * rotateSpeed); 
            boxTransform.rotation = Quaternion.Lerp(boxTransform.rotation, target, t);
            
            if(t >= 1)
            {
                rotating = false;
                t = 0;
                rotateSpeed = defaultRotateSpeed;
            }    
        }
    }

    public void RotateRight()
    {
        if (rotating)
        {
            //rotateSpeed = rotateSpeed * 3; //increases rotate to smoothen gameplay
            return;
        }
            
        oldRotation = boxTransform.rotation.eulerAngles;
        targetAngle = oldRotation + new Vector3(0, 0, -90);
        target = Quaternion.Euler(targetAngle);
        rotating = true;
        
    }
    
    public void RotateLeft()
    {
        if (rotating)
        {
            //rotateSpeed = rotateSpeed * 3;
            return;
        }
        oldRotation = boxTransform.rotation.eulerAngles;
        targetAngle = oldRotation + new Vector3(0, 0, 90);
        target = Quaternion.Euler(targetAngle);
        rotating = true;
        
    }

    
}
