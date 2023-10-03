using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    private Camera _camera;
    TopDownCharacter player;

    protected override void Start()
    {
        base.Start();
        player = Gamemanager.Instance.player;
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        CallMoveEvent(value.Get<Vector2>());
    }

    public void OnShoot()
    {
        //if (_timeSinceLastAttack < 0.5f)//ÃÑ¾Ë ¼Óµµ
        //{
        //    _timeSinceLastAttack += Time.deltaTime;
        //}
        //else if (IsShooting && _timeSinceLastAttack >= 0.5f)
        //{
        //    CallShootEvent(value.Get<Vector2>());
        //    _timeSinceLastAttack = 0;
        //}
        if (_timeSinceLastAttack >= 0.2f)
        {
            if(!player.m_die)
            CallShootEvent();
            _timeSinceLastAttack = 0;
            SoundManager.Instance.PlayEffect(SoundManager.Effect.Range);
        }

    }

}
