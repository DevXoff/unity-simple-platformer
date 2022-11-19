using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        var children = GetComponentsInChildren<SpriteRenderer>();
        foreach (var child in this.transform)
        {
            var gameobj = child as Transform;
            Debug.Log(gameobj.gameObject.name);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
