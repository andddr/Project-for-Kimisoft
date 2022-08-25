using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Animator _anim;
    private Vector3 _TPosition;
    private bool _isMoving = false;
    private LineRenderer _line;


     private void Awake() 
    {
        _anim = GetComponent<Animator>();
        _line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0)&&Hero.Instance.GetGround())
        {

            if (!Hero.Instance.GetFlipX()&&(Hero.Instance.GetPositionHero().x > _TPosition.x))
            {
                Hero.Instance.FlipX();  
            }
             if (Hero.Instance.GetFlipX()&&!(Hero.Instance.GetPositionHero().x > _TPosition.x))
            {
                Hero.Instance.FlipX();  
            }  

            Hero.Instance.SetStopTrigger(0);
            Hero.Instance.SetGravity(0);
            TriggerPosition();
        }

        if(_isMoving)
        {
            _anim.SetBool("jerk",true);
            ItsMove();
        }
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_isMoving)
        {
            _anim.SetBool("jerk",false);
            _isMoving = false;
            Hero.Instance.SetStopTrigger(1);
            Hero.Instance.SetGravity(1); 
        }
    }


    private void TriggerPosition()
    {
        _TPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _TPosition.z = transform.position.z;
        _line.SetPosition(0,Hero.Instance.GetPositionHero());
        _line.SetPosition(1,_TPosition);
 

        _isMoving = true;
    }

    private void ItsMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, _TPosition, _speed * Time.deltaTime);
        
        if(transform.position == _TPosition)
        {
            Hero.Instance.SetStopTrigger(1);
            Hero.Instance.SetGravity(1);
            _anim.SetBool("jerk",false);
            _isMoving = false;
        }
    }
}
