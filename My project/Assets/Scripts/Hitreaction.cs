using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitreaction : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Vector3 _shootPosition;
    private Animator _anim;
    private bool _IsMoving = true;

    private void Awake() 
    {
        _shootPosition = Traking.Instance.GetshootPosition();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(_IsMoving)
        {
          ItsMove();  
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        _anim.SetTrigger("boom");
        _IsMoving =false;
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().GetDamage();
        }
    }

    private void ItsMove()
    {
        transform.position = Vector3.MoveTowards(transform.position,_shootPosition, _speed * Time.deltaTime);
        
        if(transform.position == _shootPosition)
        {
            _anim.SetTrigger("boom");
        }
    }

    public void Destroyball()
    {
        Destroy(this.gameObject);
    }
}
