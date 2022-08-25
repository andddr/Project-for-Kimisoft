using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _lives = 5;
    [SerializeField] private GameObject _diebody;

    public static Enemy Instance {get; set;}

    private void Awake() 
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            Hero.Instance.GetDamage();
        }
    }
    
    private void ReciveDamage()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1f,0.5f,0.5f,1f);
    }

    public int GetLives()
    {
        return _lives;
    }

    public void Die()
    {
        Instantiate (_diebody,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void GetDamage ()
    {
        _lives--;
        if (_lives <2)
        {
            ReciveDamage();
        }
        if (_lives<1)
        {
            Die();
        }
    }
}
