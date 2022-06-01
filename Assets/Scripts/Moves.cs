using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private bool grounded = true;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("zemin"))
        {
            grounded = true;
            _animator.SetBool("grounded", grounded);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("zemin"))
        {
            grounded = false;
            _animator.SetBool("grounded", grounded);
        } 
    }
    void FixedUpdate()
    {
        if (grounded)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(UserInt.speed, rb.velocity.y);
                _animator.SetFloat("kuvvet", 1f);
                _spriteRenderer.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-UserInt.speed, rb.velocity.y);
                _animator.SetFloat("kuvvet", 1f);
                _spriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                grounded = false;
                rb.velocity = new Vector2(rb.velocity.x, UserInt.jumpforce);
                _animator.SetFloat("kuvvet", 0.5f);
                _animator.SetBool("grounded", grounded);
            }
            if (!Input.anyKey)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
                _animator.SetFloat("kuvvet", 0f);
            }
        }
    }
}