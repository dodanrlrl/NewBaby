using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnShootEvent;

    protected bool IsShooting;
    protected float _timeSinceLastAttack = 0;


    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        if (_timeSinceLastAttack < 0.5f)//ÃÑ¾Ë ¼Óµµ
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallShootEvent()
    {
        OnShootEvent?.Invoke();
    }
}
