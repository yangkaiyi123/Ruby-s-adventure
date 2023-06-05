using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private Rigidbody2D newrigidbody2D;
    //人物血量
    public int maxHealth = 100;
    public int currentHealth;
    //角色移动速率
    public float speedRate = 0;
    //角色无敌时间
    public float timeInvincible = 2.0f;
    private bool isInvincible;
    private float invincibleTimer;
    void Start()
    {
        newrigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        invincibleTimer = timeInvincible;
    }

    public void Changehealth(int amount)
    {
        if(amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            //受到伤害
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currentHealth=Mathf.Clamp(currentHealth+amount, 0, maxHealth);  
        Debug.Log("当前血量："+currentHealth+" "+"最大血量："+maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0 )
            {
                isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        ////Debug.Log(Horizontal);
        Vector2 position = transform.position;
        position.x = position.x + speedRate * Horizontal * Time.deltaTime;
        position.y = position.y + speedRate * Vertical * Time.deltaTime;
        //transform.position = position;
        newrigidbody2D.MovePosition(position);
    }

}
