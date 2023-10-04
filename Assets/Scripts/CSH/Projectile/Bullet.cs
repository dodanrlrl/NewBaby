using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    BaseBullet,
    RedBullet,
    GreenBullet
}
public class Bullet : MonoBehaviour
{
    BulletType c_BulletType;
    protected float speed = 8f;
    private float bulletDamage;
    private float wholeDamage;//bulletType + 플레이어 공격력

    Rigidbody2D Rigidbody;
    Animator animator;
    SpriteRenderer BulletSprite;

    WaitForSeconds WaitSeconds = new WaitForSeconds(1f);
    private void Awake()
    {
        BulletSprite = GetComponent<SpriteRenderer>();   
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
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

    public void SetBulletInfo(BulletType currentBullet,float playerAttackPower)
    {

        switch (currentBullet)
        {
            case BulletType.BaseBullet:
                bulletDamage = 1f;//데미지, 스피드 설정 추후 변경
                BulletSprite.color = Color.white;
                break;
            case BulletType.RedBullet:
                bulletDamage = 2f;
                BulletSprite.color = Color.red;
                break;
            case BulletType.GreenBullet:
                bulletDamage = 3f;
                BulletSprite.color = Color.green;
                break;
        }
        wholeDamage = bulletDamage + playerAttackPower;
    }



    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            //DestroyBullet();
        }
        else if (other.tag == "Enemy" || other.tag == "Boss")
        {
            other.GetComponent<Zom2>().TakeDamage(wholeDamage);
            DestroyBullet();
        }
        else if (other.tag == "Monster")
        {
            other.GetComponent<Monster>().TakeDamage(wholeDamage);
            DestroyBullet();
        }
        else if (other.tag == "Boundary" || other.tag == "Wall" || other.tag == "Puzzle" || other.tag == "Box")
        {
            DestroyBullet();
        }
    }
}
