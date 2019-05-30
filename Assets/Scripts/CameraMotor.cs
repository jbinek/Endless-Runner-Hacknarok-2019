using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 offset;
    private Vector3 moveVector;
    private Vector3 animationOffset = new Vector3(0,5,3);
    public State state;
    
    // Start is called before the first frame update
    void Start()
    {
       lookAt= GameObject.FindGameObjectWithTag("Player").transform;
       offset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + offset;
        
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if (state.transition >= 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, state.transition);
            //transform.LookAt(lookAt.position+Vector3.up);
        }
    }
}
