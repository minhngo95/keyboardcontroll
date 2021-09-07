using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool StatusGround;
    public bool StatusJumpDouble = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ABC:" + collision.transform.tag);
        if (collision.gameObject.tag == "Ground")
        {
            StatusGround = true;
            StatusJumpDouble = false;
            Debug.Log("Da va cham vao Nen");
        }    
    }

}

