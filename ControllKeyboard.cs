using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllKeyboard : MonoBehaviour
{
    protected Animator ani;
    private Rigidbody2D rg;
    public GameObject Player;
    public float Speed;
    public float JumpSpeed = 6;
    public float MaxSpeed = 3f;


    void Start()
    {  
        ani = Player.GetComponent<Animator>();
        rg = Player.GetComponent<Rigidbody2D>();
    }


    void Update()

    {
        AddForce(Speed);
        
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            if (Input.GetKey(KeyCode.D))
                {
                Speed = MaxSpeed;
                Vector3 scale = Player.transform.localScale;
                scale.x = 1f;
                Player.transform.localScale = scale;
                ani.SetInteger("Status", 2);
                }
            if (Input.GetKey(KeyCode.LeftShift))
            {

                ani.SetInteger("Status", 1);
                Speed = 5;
            }
        }



        else if (h < 0)
        {
            if (Input.GetKey(KeyCode.A))

            {
                Speed = -MaxSpeed;
                Vector3 scale = Player.transform.localScale;
                scale.x = -1f;
                Player.transform.localScale = scale;
                ani.SetInteger("Status", 2);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {

                ani.SetInteger("Status", 1);
                Speed = -5;
            }
        }
        else if (h == 0)
        {
            Speed = 0;
            ani.SetInteger("Status", 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Player.GetComponent<Collision>().StatusGround)
            {
                rg.velocity = new Vector3(rg.velocity.x, JumpSpeed, 0);
                Player.GetComponent<Collision>().StatusGround = false;
            }
            ani.SetInteger("Status", 3);
        }    
            
      
}
        public void AddForce (float Speed)
       {
        rg.velocity = new Vector3(Speed, rg.velocity.y, 0);
       }
}
    


    
    
   


