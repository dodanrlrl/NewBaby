using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed = 10f;
    Rigidbody2D Rigidbody;
    Animator animator;

    WaitForSeconds WaitSeconds = new WaitForSeconds(1f);
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void DestoryBulletInvoke()//낙하 대기
    {
        Rigidbody.gravityScale = 1.9f;
        Invoke(nameof(DestroyBullet), 0.2f);
    }
    private void DestroyBullet()//낙하
    {
        Rigidbody.gravityScale = 0f;
        Rigidbody.velocity = Vector2.zero;
        animator.Play("Destroy");
        StartCoroutine(DelayDestroy());
    }
    IEnumerator DelayDestroy()//사라지는 애니메이션 대기
    {
        yield return WaitSeconds;
        ObjectPool.Instance.ReturnObj(this);
    }
    public void MoveUp()
    {
        Rigidbody.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }
    public void MoveDown()
    {
        Rigidbody.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
    }
    public void MoveLeft()
    {
        Rigidbody.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
    }
    public void MoveRight()
    {
        Rigidbody.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }




    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            //DestroyBullet();
        }
        else if (other.tag == "Enemy" || other.tag == "Boss")
        {
            DestroyBullet();
        }
        else if (other.tag == "Boundary")
        {
            DestroyBullet();
        }
    }
}
