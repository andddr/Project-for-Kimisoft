using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traking : MonoBehaviour
{
    [SerializeField] private GameObject _equipment;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private Animator _anim;
    private Vector3 _TPosition;
    private Vector3 _mousePos;
    private float _timeBtwShots;
    private float _startTimeBtwShots= 0.3f;

    public static Traking Instance {get; set;}

    private void Awake() 
    {
        Instance = this;
    }
    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(_mousePos.y,_mousePos.x) * Mathf.Rad2Deg-90f;
        transform.rotation = Quaternion.Euler(0f,0f,rotZ);

        if (_timeBtwShots <= 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                _anim.SetBool("Attack",true);
                TriggerPosition();
                Instantiate (_equipment, _shotPoint.position, Quaternion.Euler(0f,0f,rotZ+90f));
                _timeBtwShots = _startTimeBtwShots;
                
                if (!Hero.Instance.GetFlipX()&&(Hero.Instance.GetPositionHero().x > _TPosition.x))
                {
                    Hero.Instance.FlipX();  
                }
                if (Hero.Instance.GetFlipX()&&!(Hero.Instance.GetPositionHero().x > _TPosition.x))
                {
                    Hero.Instance.FlipX();  
                }  
            }
        }
        else
        {
            _timeBtwShots-=Time.deltaTime;
        }
    }

    private void TriggerPosition()
    {
        _TPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _TPosition.z = transform.position.z;
        _line.SetPosition(0,_shotPoint.position);
        _line.SetPosition(1,_TPosition);
    }
    public Vector3 GetshootPosition()
    {
       return _TPosition;
    }
  
}
