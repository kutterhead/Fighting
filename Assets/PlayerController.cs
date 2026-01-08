using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rigidbody;
    public PlayerInput playerInput;
    public InputAction moveH;
    public InputAction jump;
    public InputAction down;
    public Animator animator;


    public Transform raycastEmissor;

    private bool isGrounded = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        moveH = playerInput.actions.FindAction("MoveH");
        down = playerInput.actions.FindAction("Down");
        jump = playerInput.actions.FindAction("Jump");
    }

    // Update is called once per frame
    float movimientoH = 0f;
    public float velocidadX = 1f;
    void Update()
    {


    }
    public float salto = 10f;
    private void FixedUpdate()
    {
        movimientoH = moveH.ReadValue<float>();

        Debug.Log("Movimiento: " + movimientoH);


        if (movimientoH!=0)
        {

        rigidbody.linearVelocity = transform.forward * movimientoH * velocidadX  + new Vector3(0, rigidbody.linearVelocity.y,0) ;
        }





        if (jump.triggered && isGrounded)
        {
        rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, salto, rigidbody.linearVelocity.z);
            //rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, salto, rigidbody.linearVelocity.z); 
         //   rigidbody.linearVelocity += transform.up * salto;

        }
        RaycastHit hit;


        if ((Physics.Raycast(raycastEmissor.position, -raycastEmissor.up, out hit, 1f, LayerMask.GetMask("Ground"))))
        {
        Debug.DrawRay(raycastEmissor.position, -raycastEmissor.up,Color.red);
            isGrounded = true;
        }
        else
        {
            Debug.DrawRay(raycastEmissor.position, -raycastEmissor.up, Color.green);
            isGrounded = false;
        }

        if (rigidbody.linearVelocity.y<0)
        {
            rigidbody.linearVelocity -= transform.up * Time.fixedDeltaTime * 10f;
           
            
        }



    }


}
