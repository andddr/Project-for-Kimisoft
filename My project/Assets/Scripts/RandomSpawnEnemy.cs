using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private Vector2 _spawnPisition;

    void Start()
    {
        RandomSpawn(-19,-10f,1f,2);
        RandomSpawn(-4f,28,1f,3);
    }

    private void SpawnEnemy2(float X,float Y)
    {
        _spawnPisition.Set(X,Y);
        Instantiate (_enemy,_spawnPisition,Quaternion.Euler(0f,0f,0f));
    }

    private void RandomSpawn(float XFirst,float XSecond, float YCor, int count)
    {
        for(int i=0;i<count;i++)
        {
             SpawnEnemy2(Random.Range(XFirst,XSecond),YCor);
        }
    }
}
