using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;

    public DeathMenu deathMenu;

    public State state;
    
    private float getVelocity()
    {
        return 4 + 2f * (Time.time/6.0f);
    }


    private float verticalVelocity = 0;
    private float gravity=2.0f;



    private Vector3 moveVector;

    private float last_point_dist = 0.0f;
    private float dist_per_point = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        state.distance = controller.transform.position.z;

        //        if (Time.time < animDur)
        //        {
        //            moveVector = Vector3.zero;
        //            moveVector.z = velocity;
        //            controller.Move(moveVector * Time.deltaTime);
        //            return;
        //        }
        //        
        if (state.isDead)
        {
            deathMenu.ToggleMenu();
            return;

        }



        getPoints();
        
        if (controller.isGrounded)
        {
            verticalVelocity = 0;
        }
        else
        {
            verticalVelocity -=gravity;
        }

        
        moveVector = Vector3.zero;
        moveVector.z = getVelocity();
        moveVector.y = verticalVelocity;
        
        
        if(state.transition>=1.0f)
            moveVector.x=5.0f*Input.GetAxisRaw("Horizontal");
        
        controller.Move(moveVector * Time.deltaTime);
    }

    void getPoints()
    {
        if (controller.transform.position.z - last_point_dist > dist_per_point)
        {
            state.score += 1;
            last_point_dist = controller.transform.position.z;
        }
    }

    private void OnTriggerEnter(Collider info)
    {
        switch (info.tag)
        {
            
            case "Lotek":
                state.score+=4;
                Destroy(info.gameObject);
                break;
           
        }
    }

    void OnControllerColliderHit (ControllerColliderHit info)
    {
//        Debug.Log(info.collider.tag);
        switch (info.collider.tag)
        {
            case "OBS":
                state.isDead = true;
            break;
            
        }

    }
}
