using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    [SerializeField] private int _health = 100;
    public int Health
    {
        get { return _health;}
        set
        {
            _health = value;
            if(_health <0)
            {
                IsAlive = false;
            }
        }
    }
    
    [SerializeField] private bool _isAlive = true;
    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {
            _isAlive = value;
            _animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log($"IsAlive set {value}");
        }
    }

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private bool _isInvincible;
    [SerializeField]private float _invincibilityTime = 0.25f;
    private float _timeSinceHit;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isInvincible)
        {
            if (_timeSinceHit > _invincibilityTime)
            {
                _isInvincible = false;
                _timeSinceHit = 0;
            }

            _timeSinceHit += Time.deltaTime;
        }
        
        TakeDamage(10);
    }

    public void TakeDamage(int damage)
    {
        if (IsAlive && !_isInvincible)
        {
            Health -= damage;
            _isInvincible = true;
        }
    }
}
