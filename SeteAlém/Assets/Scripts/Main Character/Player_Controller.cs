using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Controller : MonoBehaviour
{

    private Vector2 direction;
    private Vector3 Movement;

    [SerializeField] private float speed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float crunchHeight;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject pOV;
    private CharacterController cc;

    void Start()
    {
        
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;


    }

    void Update()
    {
        cc.Move(Movement * speed * Time.deltaTime);
        Movement.y += gravity * Time.deltaTime;
        Debug.Log(speed); 
    }

    public void SetDirection(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
        Movement = new Vector3(direction.x, 0, direction.y);
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        Movement.y = jumpForce / 10;
    }

    public void SetCrounch(InputAction.CallbackContext value)
    {
        if(value.ReadValueAsButton() == true)
        {
            pOV.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - crunchHeight, transform.localPosition.z);
        }
        else
        {
            pOV.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + crunchHeight, transform.localPosition.z);
        }
        //pOV.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.z - crunchHeight, transform.localPosition.y);
    }
    
    public void SetSprint(InputAction.CallbackContext value)
    {
        if(value.ReadValueAsButton() == true)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
      
    }
    
    
}
