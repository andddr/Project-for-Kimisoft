using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{

    void Start()
    {
        Destroy(this.gameObject,0.5f);
    }

}
