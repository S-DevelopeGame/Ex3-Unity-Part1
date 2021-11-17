using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] float JumpImpulse = 7f;
    [SerializeField] float SideSpeed = 2f;

    public ContactFilter2D ContactFilter;

    private Rigidbody2D m_Rigidbody;
    private bool m_ShouldJump;
    private float m_SideSpeed;
    [SerializeField] private Animator animator;
    private bool isRight = true;
    [SerializeField] private NumberField numberField;
    [SerializeField] private float accelerationToJump;



    // We can check to see if there are any contacts given our contact filter
    // which can be set to a specific layer and normal angle.
    public bool IsGrounded = true;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Set jump/
        if (Input.GetKeyDown(KeyCode.Space))
            m_ShouldJump = true;

        // Set movement.


        m_SideSpeed = (Input.GetKey(KeyCode.LeftArrow) ? -SideSpeed : 0f) + (Input.GetKey(KeyCode.RightArrow) ? SideSpeed : 0f);


        if(Input.GetKey(KeyCode.LeftArrow) && !isRight)
        {
            animator.SetBool("isWalking", true);
        }
        else if(Input.GetKey(KeyCode.RightArrow) && isRight)
        {
            animator.SetBool("isWalking", true);
        }
        else
            animator.SetBool("isWalking", false);


        if (!isRight && Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = true;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (isRight && Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            isRight = false;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }



    }

    void FixedUpdate()
    {
        // Handle jump.
        // NOTE: If instructed to jump, we'll check if we're grounded.
        if (m_ShouldJump && IsGrounded)
        {
            if (m_Rigidbody.velocity.x > accelerationToJump) 
                m_Rigidbody.AddForce(Vector2.up * (JumpImpulse+3f), ForceMode2D.Impulse);
            else
                m_Rigidbody.AddForce(Vector2.up * JumpImpulse, ForceMode2D.Impulse);
            Debug.Log("is jumping");
        }
            

        // Set sideways velocity.
        m_Rigidbody.AddForce(Vector2.right*m_SideSpeed, ForceMode2D.Force);

        // Reset movement.
        m_ShouldJump = false;
        m_SideSpeed = 0f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((ContactFilter.layerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            //Debug.Log("Hit with Layermask");
            IsGrounded = true;


        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
        Debug.Log("exit");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((ContactFilter.layerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
           // Debug.Log("Hit with Layermask");
            IsGrounded = true;


        }
    }



}
