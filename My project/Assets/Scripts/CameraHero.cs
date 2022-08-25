using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHero : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 1f;
    private Vector3 _position;

    private void  Awake() 
    {
        if (!_player)
        {
            _player = FindObjectOfType<Hero>().transform;
        }
    }

    private void Update() 
    {
        if(_player)
        {
        _position = _player.position;
        _position.z = -10f;
        _position.y += 2f;
        transform.position = Vector3.Lerp(transform.position,_position, Time.deltaTime*_speed);
        }
    }
}
