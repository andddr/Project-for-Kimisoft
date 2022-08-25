using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLiveBar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SpriteRen;
    [SerializeField] private Sprite sprite_0;
    [SerializeField] private Sprite sprite_1;
    [SerializeField] private Sprite sprite_2;
    private Enemy enemy;

    void Awake()
    {
       // SpriteRen = GetComponentInChildren<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if(enemy.GetLives()> 1)
        {
            SpriteRen.sprite = sprite_0;
        }
        if(enemy.GetLives() == 1)
        {
            SpriteRen.sprite = sprite_1;
        }
        if(enemy.GetLives()<=0)
        {
            SpriteRen.sprite = sprite_2;
        }
        
    }
}
