using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero: MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private int _lives = 2;
    [SerializeField] private GameObject _diebody;
    private Animator _anim;
    private int _stoptrigger  = 1;

    private bool _control = true;
    private bool _isGrounded = false;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private Transform _herotransform;
    private Traking _traking;
    private ClickMove _clickmove;

    public static Hero Instance {get; set;}

    private States State
    {
        get {return (States)_anim.GetInteger("state");}
        set {_anim.SetInteger("state",(int)value);}
    }

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        Instance = this;
        _traking = GetComponentInChildren<Traking>();
        _clickmove = GetComponent<ClickMove>();
        _herotransform = GetComponent<Transform>();
        
    }

    private void Update() 
    {
        if(_anim.GetBool("damage")|_anim.GetBool("jerk")|_anim.GetBool("falling")|_anim.GetBool("Attack"))
        {
            _control =false;
        }
        else
        {
            _control =true;
        }

        if(!_isGrounded&&!_anim.GetBool("jerk")) 
        {
            _anim.SetBool("falling",true);
        }
        else
        {
            _anim.SetBool("falling",false);
        }

        if(_control)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SwitchState();
            }

            if (Input.GetButton("Horizontal"))
            {
                Run();
            }
            else
            {
                State = States.hold;
            }
        }
    }

    private void Die()
    {
        Instantiate (_diebody,_herotransform.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void Run()
    {
        State = States.run;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position+dir,_speed * Time.deltaTime * _stoptrigger);
        _sprite.flipX = dir.x <0.0f;
    }

    public void SetGround(bool InGround)
    {
        _isGrounded= InGround; 
    }

    public void GetDamage()
    {
        _anim.SetBool("damage",true);
        this._lives -= 1;
        if(_lives<1)
        {
            Die();
        }
    }

    public void SwitchState()
    {
        _traking.enabled = !_traking.enabled;
        _clickmove.enabled = !_clickmove.enabled;
    }

    public void SetGravity(int gravity)
    {
        _rb.gravityScale = gravity;
    }

     public void FlipX()
    { 
          _sprite.flipX = !_sprite.flipX;    
    }
    public bool GetFlipX()
    {
        return _sprite.flipX;
    }

    public bool GetGround()
    {
        return _isGrounded;
    }

    public Vector3 GetPositionHero()
    {
        return _herotransform.transform.position;
    }

    public void SetStopTrigger(int instoptriger)
    {
        _stoptrigger = instoptriger;
    }

    public void StopAttack()
    {
       _anim.SetBool("Attack",false);
    }
    public void StopDamageAnim()
    {
         _control =true;
        _anim.SetBool("damage",false);
    }

    public void OnControl()
    {
        _control = true;
    }
    public void OffControl()
    {
        _control = false;
    }

    public bool IsTraking()
    {
        return _traking.enabled;
    }

    public bool IsClickmove()
    {
        return _clickmove.enabled;
    }
}


public enum States 
{
    hold,
    run
}