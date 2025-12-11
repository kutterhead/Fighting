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

        // rigidbody.linearVelocity = transform.forward * movimientoH * velocidadX;
        if (jump.triggered)
        {
        rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, rigidbody.linearVelocity.y + salto, rigidbody.linearVelocity.z);
            //rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, salto, rigidbody.linearVelocity.z); 
         //   rigidbody.linearVelocity += transform.up * salto;

        }




    }


}
