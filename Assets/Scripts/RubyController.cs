using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedRate = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //实现人物移动
        float Horizontal= Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        //Debug.Log(Horizontal);
        Vector2 position = transform.position;
        position.x = position.x + speedRate * Horizontal*Time.deltaTime;
        position.y = position.y + speedRate * Vertical*Time.deltaTime;
        transform.position = position;


    }
}
