using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Controller : MonoBehaviour
{

    private Vector2 direction;
    private Vector2 lookDirection;
    private Vector3 Movement;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private CharacterController cc;
    private GameObject pOV;

    void Start()
    {
        
        cc = GetComponent<CharacterController>();
        pOV = GetComponentInChildren<GameObject>();
        Cursor.lockState = CursorLockMode.Locked;


    }

    void Update()
    {
        cc.Move(Movement * speed * Time.deltaTime);
        Movement.y += gravity * Time.deltaTime; 
    }

    public void SetDirection(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
        Movement = new Vector3 (direction.x, 0, direction.y);
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        Movement.y = jumpForce / 10;
    }

    public void SetCrounch()
    {

    }
    
    /*public void SetMouseDirection(InputAction.CallbackContext value)
    {
        
      
    }*/
    
    
}
