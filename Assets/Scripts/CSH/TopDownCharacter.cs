using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacter : MonoBehaviour
{
    private static TopDownCharacter _instance = null;

    private int CurrentHP = 3;
    private int MaxHP = 10;
    private float Speed = 4f;
    private float attackPower = 5;
    private bool m_die = false;//À¯´Ö »ç¸Á ¿©ºÎ

    // Start is called before the first frame update
    public static TopDownCharacter Instance
    {
        get
        {
            if(null == _instance)
            {
                return null;
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(null == _instance) 
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject );
        }
    }

    public void TakeDamage(int damage)
    {
        if (m_die)
        {
            return;
        }

        CurrentHP = Mathf.Clamp(CurrentHP - damage, 0, MaxHP);

        if(CurrentHP == 0)
        {
            m_die = true;
        }
    }

    public void TakeHeal(int heal)
    {
        CurrentHP = Mathf.Clamp(CurrentHP + heal, 0, MaxHP);
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
    public int GetMaxHp()
    {
        return MaxHP;
    }
    public int GetCurrentHp()
    {
        return CurrentHP;
    }

}
