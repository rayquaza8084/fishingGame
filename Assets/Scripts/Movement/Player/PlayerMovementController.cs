using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float horizontalMoveSpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private float MaxAirVelocity;
    [SerializeField] private float gravity;
    [Header("Ground check")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask isGround;
    private bool isGrounded;
    [Header("Jump")]
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float jumpCD;
    [Header("Keybinds")]
    // [SerializeField] private KeyCode forward = KeyCode.W;
    // [SerializeField] private KeyCode backward = KeyCode.S;
    // [SerializeField] private KeyCode right = KeyCode.D;
    // [SerializeField] private KeyCode left = KeyCode.A;
    // [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    // [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;

    [SerializeField] private Transform orientation;
    [SerializeField] private float horiSen;
    [SerializeField] private float vertSens;
    [SerializeField] private CharacterController charController;
    [SerializeField] private float horizontalSpeedIncrease = 1;

    private float verticalVelocity =0;
    private Vector2 horizontalVelocity = new Vector2(0,0);
    

    private void FixedUpdate(){
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f + charController.skinWidth + 0.1f, isGround);
        ApplyFallForce();
        Move();
    }
    private void Move()
    {
        Vector3 movement = new Vector3(horizontalVelocity.x, verticalVelocity, horizontalVelocity.y);
        charController.Move(movement*Time.fixedDeltaTime);
    }
    
    public void Jump(){
        if (isGrounded)
        {
            //apply vertical velocity to make character jump
            verticalVelocity = jumpVelocity;
        }
    }
    // private void resetJump(){
    //     isReadytoJump = true;
    public void ChangeHorizontalMovement(InputAction.CallbackContext context)
    {
        horizontalVelocity = context.ReadValue<Vector2>() * horizontalMoveSpeed;
    }
        
    
    private void ApplyFallForce(){
        if (isGrounded)
        {
            if (verticalVelocity < 0f)
                verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        
    }
    

}

