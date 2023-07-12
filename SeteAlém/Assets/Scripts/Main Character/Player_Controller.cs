using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Controller : MonoBehaviour
{

    private Vector2 direction;
    private Vector2 lookDirection;

    [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivity;
    private CharacterController cc;
    private Transform playerBody;

    void Start()
    {
        
        cc = GetComponent<CharacterController>();
        playerBody = gameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        cc.Move(new Vector3 (direction.x, 0, direction.y) * speed * Time.deltaTime);

        
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        playerBody.Rotate(Vector3.up);
    }

    public void SetDirection(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
    }
    
    /*public void SetMouseDirection(InputAction.CallbackContext value)
    {
        
      
    }*/
    
    
}
