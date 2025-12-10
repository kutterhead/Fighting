using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public PlayerInput playerInput;

    public InputAction moveH;

    public InputAction fordward;
    public InputAction backward;
    public InputAction jump;


    public Animator animator;




    
    void Start()
    {
        moveH = playerInput.actions.FindAction("Forward");
        fordward = playerInput.actions.FindAction("Forward");
        backward = playerInput.actions.FindAction("Backward");
        jump = playerInput.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Movimiento: " + ((moveH.ReadValue<float>() * 2) - 1f) );


        
        if (fordward.triggered)//getkeyDown
        {
            //Debug.Log("tecla pulsada");

        }
        if (fordward.IsPressed())//getkey
        {
            //Debug.Log("tecla pulsada");
            animator.SetBool("Forward", true);


        }
        else
        {
            animator.SetBool("Forward", false);
        }



        if (backward.IsPressed())//getkey
        {
           // Debug.Log("tecla pulsada");
            animator.SetBool("Backward",true);


        }
        else
        {
            animator.SetBool("Backward", false);
        }


    }
}
