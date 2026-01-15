
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rigidbody;
    public PlayerInput playerInput;
    public InputAction moveH;
    public InputAction jump;
    public InputAction down;

    public InputAction punch1;
    public InputAction punch2;
    public InputAction kick1;
    public InputAction kick2;

    public Animator animator;


    public Transform raycastEmissor;

    public bool isGrounded = false;

    public bool isOnleft = false;

    public Vector3 lastPosition = Vector3.zero;

    public float life = 1f;
    public PlayerController otherPlayer;
    // Update is called once per frame
    float movimientoH = 0f;
    public float velocidadX = 1f;

    public float salto = 10f;


    public Slider lifeSlide;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        moveH = playerInput.actions.FindAction("MoveH");
        down = playerInput.actions.FindAction("Down");
        jump = playerInput.actions.FindAction("Jump");

        punch1 = playerInput.actions.FindAction("Punch1");
        punch2 = playerInput.actions.FindAction("Punch2");
        kick1 = playerInput.actions.FindAction("Kick1");
        kick2 = playerInput.actions.FindAction("kick2");

       

    }

    private void FixedUpdate()
    {

       // distance = Vector3.Magnitude(lastPosition - transform.position);


        //Debug.Log(distance);
        //lastPosition = transform.position;

        //if (distance>0.1f)
        //{
        //    Debug.Log(distance);


        //}






        if (isOnleft)
        {

            movimientoH = moveH.ReadValue<float>();

        }
        else
        {
            movimientoH = -moveH.ReadValue<float>();
        }




        if (punch1.triggered)
        {

            animator.SetTrigger("UpperL");
        
        }
        if (punch2.triggered)
        {

            animator.SetTrigger("UpperR");

        }



        //Debug.Log("Movimiento: " + movimientoH);


        if (movimientoH != 0)
        {

            rigidbody.linearVelocity = transform.forward * movimientoH * velocidadX + new Vector3(0, rigidbody.linearVelocity.y, 0);

            if (movimientoH > 0)
            {
                animator.SetBool("Forward", true);
                animator.SetBool("Backward", false);
            }
            else
            {
                animator.SetBool("Forward", false);
                animator.SetBool("Backward", true);


            }


        }
        else
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Backward", false);
        }

        if (kick1.triggered)
        {
            animator.SetTrigger("Kick1");
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
           //w rigidbody.linearVelocity -= transform.up * Time.fixedDeltaTime * 10f;
           
            
        }



    }
    public void getdamage(float damage)
    {

        life -= damage;

        if (life<=0f)
        {
            Debug.Log("Game Over");
            life = 0;
        }


        lifeSlide.value = life;

    }

}
