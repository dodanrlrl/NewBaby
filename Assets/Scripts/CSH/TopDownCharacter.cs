using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    private float attackPower = 5;
    private bool m_die = false;//À¯´Ö »ç¸Á ¿©ºÎ
    private bool isInvincible = false;
   
    public Transform Head;
    public Transform Body;
    SpriteRenderer BodySpriteRenderer;
    SpriteRenderer HeadSpriteRenderer;
    UIManager UI;

    // Start is called before the first frame update
    private void Awake()
    {
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
        
    }

    public void TakeHeal(int heal)
    {
        currentHP = Mathf.Clamp(currentHP + heal, 0, maxHP);
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
    public int GetMaxHp()//¾ø¾Ù ¿¹Á¤
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
        UI.InitializeHp();
    }


}
