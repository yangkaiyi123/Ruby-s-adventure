using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rigidbody2d;
    //轴向控制
    public bool vertical;
    //方向控制
    private int direction = 1;
    //方向改变时间间隔，常量
    public float changetime = 3.0f;
    //计时器
    private float timer;

    private bool broken;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changetime;
        broken = true;
    }
        
    // Update is called once per frame
    void Update()
    {

        if(!broken ) return; 
        //方向更改
        timer-=Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changetime;
        }

        Vector2 pos = rigidbody2d .position;
        if (vertical)
        {
            pos.y = pos.y + Time.deltaTime * speed*direction;
        }
        else
        {
            pos.x= pos.x + Time.deltaTime *speed*direction;
        }
        //pos.x = pos.x + Time.deltaTime * speed;
        rigidbody2d.MovePosition(pos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController rubyController = collision.gameObject.GetComponent<RubyController>();
        if (rubyController != null)
        {
            rubyController.Changehealth(-10);
        }
    }

    public void isfixed()
    {
        broken = false;
        rigidbody2d.simulated = false;
    }
}
