using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEditor.PackageManager;

public class TopDownCharacter : MonoBehaviour, IAttackable
{

    private int maxHP;
    public int MaxHP
    {
        get { return maxHP; }
        private set { maxHP = Mathf.Clamp(value, 0, 10); }
    }
    private int currentHP;
    public int CurrentHp 
    {
        get { return currentHP;}
        private set { currentHP = Mathf.Clamp(value, 0, maxHP); }
    }
    private float Speed = 4f;
    public float attackPower;
    public float AttackPower
    {
        get { return attackPower; }
        private set { attackPower = value; }
    }
    public BulletType currentBulletType;
    public BulletType CurrentBulletType
    { get { return currentBulletType; } private set { currentBulletType = value; } }

    [HideInInspector]
    public bool m_die;//유닛 사망 여부
    private bool isInvincible;
   
    public Transform Head;
    public Transform Body;
    SpriteRenderer PlayerSpriteRenderer;
    SpriteRenderer BodySpriteRenderer;
    SpriteRenderer HeadSpriteRenderer;
    Rigidbody2D PlayerRigidBody;
    Animator Playeranimator;
    UIManager UI;

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        Playeranimator = GetComponent<Animator>(); 
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        HeadSpriteRenderer = Head.GetComponent<SpriteRenderer>();
        BodySpriteRenderer = Body.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        UI = UIManager.Instance;
        InitializePlayerInfo();
    }

    public void TakeDamage(float damage)
    {
        if(isInvincible || m_die ) { return; }
        ReduceHP((int)damage);
        if(!m_die)
        {
            StartCoroutine(Invincible());
        }
    }
    IEnumerator Invincible()
    {
        isInvincible = true;
        Color red = new Color(1, 0.2f, 0.2f, 1);

        float time = 0;
        float flashCD = 0;

        while (time < 1f)
        {
            time += Time.deltaTime;
            flashCD += Time.deltaTime;
            if (flashCD > 0)
            {
                if (BodySpriteRenderer.color == Color.white)
                {
                    BodySpriteRenderer.color = red;
                    HeadSpriteRenderer.color = red;
                }
                else if (BodySpriteRenderer.color == red)
                {
                    BodySpriteRenderer.color = Color.white;
                    HeadSpriteRenderer.color = Color.white;
                }
                flashCD -= 0.13f;
            }
            yield return null;
        }
        isInvincible = false;

    }

    public void ReduceHP(int damage)
    {
        currentHP -= damage;
        UI.hp.UpdateHP();
        if(currentHP == 0)
        {
            m_die = true;
            Playeranimator.SetBool("isDie", true);
            HeadSpriteRenderer.enabled = false;
            BodySpriteRenderer.enabled = false;
            PlayerSpriteRenderer.color = Color.gray;
            PlayerRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
        
    }

    public void TakeHeal(int heal, int maxHP = 0)//체력회복or최대체력 증가
    {
        MaxHP += maxHP;
        currentHP += heal;

        if(currentHP > MaxHP)
        {
            currentHP = MaxHP;
        }
        UI.hp.UpdateHP();
    }

    public void UpAttackPower(float power) 
    {
        attackPower += power;
    }
    public void UpSpeed(float speed) 
    {
        Speed += speed;
    }
    public float GetSpeed()
    {
        return Speed;
    }
    public int GetMaxHp()//없앨 예정
    {
        return maxHP;
    }
    public int GetCurrentHp()
    {
        return currentHP;
    }
    public void InitializePlayerInfo()
    {
        MaxHP = 6;
        CurrentHp = MaxHP;
        AttackPower = 1;
        CurrentBulletType = BulletType.BaseBullet;
        m_die = false;
        isInvincible = false;
        UI.InitializeHp();
    }

    public void ChangeBullet(BulletType value)//아이템 먹었을때 공격타입 변경위해
    {
        CurrentBulletType = value;
    }


}
