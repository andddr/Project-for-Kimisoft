using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateImage : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Sprite _sprite_0;
    [SerializeField] private Sprite _sprite_1;
    [SerializeField] private Image _image;

    private void  Awake() 
    {
        if (!_player)
        {
            //_player = FindObjectOfType<Hero>().transform;
        }
    }

    void Update()
    {  
        if (_player)
        {
            if(Hero.Instance.IsTraking())
            {
                _image.sprite = _sprite_1;
            }
            else
            {
                _image.sprite = _sprite_0;
            }
        } 
    }
}
