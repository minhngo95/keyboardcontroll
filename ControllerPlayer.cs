using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    protected Animator ani;
    private Rigidbody2D rg;
    public GameObject Player;
    public float Speed;
    public float JumpSpeed = 6;
    public float MaxSpeed = 3f;
    float TimeJump;
    int countJump = 0;
    

    // Start is called before the first frame update6
    void Start()
    {
        //Debug.Log("start");
        ani = Player.GetComponent<Animator>();
        rg = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AddForce(Speed);
    }
    //Go Back
    public void BackUp_click()
    {
        Speed = 0;
        ani.SetInteger("Status", 0);
    }

    public void BackDown_click()
    {

        Speed = -MaxSpeed;
        Vector3 scale = Player.transform.localScale;
        scale.x = -1f;
        Player.transform.localScale = scale;
        ani.SetInteger("Status", 2);

    }
    //Go Ahead
    public void ForwardUp_click()
    {
        Speed = 0;
        ani.SetInteger("Status", 0);
    }

    public void ForwardDown_click()
    {
        Speed = MaxSpeed;
        Vector3 scale = Player.transform.localScale;
        scale.x = 1f;
        Player.transform.localScale = scale;
        ani.SetInteger("Status", 2);

    }
    //Jump
    public void AUp_click()
    {
        ani.SetInteger("Status", 0);
    }

    public void ADown_click()
    {
        Debug.Log("Jump");
        if (Player.GetComponent<Collision>().StatusGround)
        {
            Player.GetComponent<Collision>().StatusGround = false;
            Player.GetComponent<Collision>().StatusJumpDouble = true;
            Invoke("JumpDouble", 0);
        }
        if (Player.GetComponent<Collision>().StatusJumpDouble)
        {
            ;
            Debug.Log("countJump:" + countJump);
            ani.SetInteger("Status", 3);
            rg.velocity = new Vector3(rg.velocity.x, JumpSpeed, 0);
            if(countJump==3)
            {
                Player.GetComponent<Collision>().StatusJumpDouble = false;
                countJump = 0;
            }    
            
        }    
        


    }
    //Run
    public void BUp_click()
    {
        ani.SetInteger("Status", 0);
    }

    public void BDown_click()
    {
        ani.SetInteger("Status", 1);
    }
    public void AddForce(float Speed)
    {
        rg.velocity = new Vector3(Speed, rg.velocity.y, 0);
    }
    void JumpDouble()
    {
        Player.GetComponent<Collision>().StatusJumpDouble = true;
    }
}
