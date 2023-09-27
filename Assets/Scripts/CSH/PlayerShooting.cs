using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private CharacterController _controller;

    [Header("Head")]
    public Transform Head;
    Animator HeadAnimator;


    private void Awake()
    {
        HeadAnimator = Head.GetComponent<Animator>();
        _controller = GetComponent<CharacterController>(); 
    }
    private void Start()
    {
        _controller.OnShootEvent += Shoot;
    }

    public void Shoot()
    {

        Bullet bullet = ObjectPool.Instance.GetObject();
        bullet.transform.position = transform.position;
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            HeadAnimator.Play("HeadUp");
            bullet.MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HeadAnimator.Play("HeadDown");
            bullet.MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HeadAnimator.Play("HeadLeft");
            bullet.MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HeadAnimator.Play("HeadRight");
            bullet.MoveRight();
        }

        bullet.Invoke("DestoryBulletInvoke",0.45f);

    }
}
