using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    protected CharacterController Controller;
    protected Rigidbody2D Rigidbody2D;

    protected Vector2 MovementDirection = Vector2.zero;


    [Header("Body")]
    public Transform Body;
    Animator BodyAnimator;
    SpriteRenderer BodySpriteRenderer;



    protected virtual void Start()
    {  
        Controller = GetComponent<CharacterController>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        BodySpriteRenderer = Body.GetComponent<SpriteRenderer>();
        BodyAnimator = Body.GetComponent<Animator>();
        Controller.OnMoveEvent += Move;
    }
    protected virtual void FixedUpdate()
    {
        ApplyMovement(MovementDirection);
    }

    private void Move(Vector2 direction)
    {
        MovementDirection = direction;

        if(direction.x < 0) 
        {
            
            BodySpriteRenderer.flipX = true;
            BodyAnimator.SetBool("isRun_R", true);
            
        }
        else if(direction.x > 0) 
        {
            BodyAnimator.SetBool("isRun_R", true);
            BodySpriteRenderer.flipX = false;
        }
        else if (direction.y < 0)
        {
            BodyAnimator.SetBool("isRun_UP", true);
            //transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (direction.y > 0)
        {       
            BodyAnimator.SetBool("isRun_UP", true);           
        }
        else
        {
            BodyAnimator.SetBool("isRun_UP", false);
            BodyAnimator.SetBool("isRun_R", false);
        }
        

    }

    private void ApplyMovement(Vector2 direction)
    {
        //direction = direction * 5;

        //Rigidbody2D.velocity = direction;
        Rigidbody2D.velocity = TopDownCharacter.Instance.GetSpeed() * direction;
    }

}
