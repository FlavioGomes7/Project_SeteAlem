using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Controller : MonoBehaviour
{

    private Vector2 direction;
    private Vector3 Movement;
    private float _threshold = 0.01f;

    [SerializeField] private float speed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float crunchHeight;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject pOV;
    [SerializeField] private GameObject CinemachineCameraTarget;
    private CharacterController cc;

    //Camera attributes
    private bool IsCurrentDeviceMouse;
    private float _cinemachineTargetPitch;
    [SerializeField] private float TopClamp = 90.0f;
    [SerializeField] private float BottomClamp = -90.0f;
    [SerializeField] private float RotationSpeed;
    private float _rotationVelocity;

    void Start()
    {
        
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;


    }

    void Update()
    {
        cc.Move(Movement * speed * Time.deltaTime);
        Movement = transform.right * direction.x + transform.forward * direction.y;
        Movement.y += gravity * Time.deltaTime;
        Debug.Log(speed); 
    }


    public void OnMove(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();
        Movement = new Vector3(direction.x, 0, direction.y);
        //Movement = transform.right * direction.x + transform.forward * direction.y;
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        Movement.y = jumpForce / 10;
    }

    public void OnCrounch(InputAction.CallbackContext value)
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
    
    public void OnSprint(InputAction.CallbackContext value)
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

    public void OnCameraMove(InputAction.CallbackContext value)
    {
        if(value.ReadValue<Vector2>().sqrMagnitude >= _threshold )
        {
            //Não multiplique o mouse input por DeltaTime
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            _cinemachineTargetPitch += value.ReadValue<Vector2>().y * RotationSpeed * deltaTimeMultiplier;
            _rotationVelocity = value.ReadValue<Vector2>().x * RotationSpeed * deltaTimeMultiplier;

            // clamp our pitch rotation
			_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // Update Cinemachine camera target pitch
            CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

            // rotate the player left and right
			transform.Rotate(Vector3.up * _rotationVelocity);

        
        }

    }
    
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
	{
		if (lfAngle < -360f) lfAngle += 360f;
		if (lfAngle > 360f) lfAngle -= 360f;
		return Mathf.Clamp(lfAngle, lfMin, lfMax);
	}

    
}
