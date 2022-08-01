using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Rigidbody rb = null;
    [SerializeField] private Vector3 direction = Vector3.up;
    [SerializeField] private float charge = 0f;
    [SerializeField] private float JumpForce = 50f;
    [SerializeField] private bool isGround = false;
    [SerializeField] private bool isHold = false;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !isHold && isGround){
            charge += 0.1f;
        }
        if(Input.GetMouseButtonUp(0)){
            isHold = true;
        }   
        if(!isGround){
            charge = 0f;
        }    
        charge = Mathf.Clamp(charge, 0f, 100f);
    }
    private void FixedUpdate() 
    {
        if(isHold){
            rb.AddForce(direction * JumpForce * charge);
            isHold = false;
            isGround = false;

        }    

    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            isGround = true;
        }    
    }

}
