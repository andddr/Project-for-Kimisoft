using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCheckGround : MonoBehaviour
{
    [SerializeField] private float _radius;
    private bool _isGrounded = false;

    private void FixedUpdate() 
    {
        CheckGround();
        Hero.Instance.SetGround(_isGrounded);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, _radius);
        _isGrounded = collider.Length > 1;
    }
}
