using System;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    [SerializeField] private bool _movingRight = true;

    private Vector3 _moveVector;
    
    private void Start()
    {
        _moveVector = new Vector3(_moveSpeed/10f, 0f, 0f);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        
    }

    private void Update()
    {
        CheckMovingfDirection();

        if (_movingRight)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
        
    }

    private void CheckMovingfDirection()
    {
        if (transform.localPosition.x >= _rightPoint.localPosition.x)
        {
            Debug.Log("Flip to Left");
            _movingRight = false;
            FlipSprite(true);
        }
        if (transform.localPosition.x <= _leftPoint.localPosition.x)
        {
            Debug.Log("Flip to Right");
            _movingRight = true;
            FlipSprite(false);
        }
    }

    private void FlipSprite(bool flipped)
    {
        _spriteRenderer.flipX = flipped;
    }
    
    private void MoveRight()
    {
        transform.localPosition += _moveVector * Time.deltaTime;
    }

    private void MoveLeft()
    {
        transform.localPosition -= _moveVector * Time.deltaTime;
    }
}
