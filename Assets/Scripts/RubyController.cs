using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

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

    private Vector2 lookdirection=new Vector2(1,0); 

    public GameObject projecttilePrefab;

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
        //Debug.Log("当前血量："+currentHealth+" "+"最大血量："+maxHealth);
        UIHealthBar.instance.SetValue (currentHealth/(float)maxHealth);
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
        if(Input.GetKeyDown(KeyCode.J)) 
        {
            Launch();
        }

    }

    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector2 move=new Vector2(Horizontal, Vertical);
        if(!Mathf .Approximately (move.x, 0) ||!Mathf .Approximately(move.y, 0))
        {
            lookdirection.Set (move.x, move.y);
            lookdirection.Normalize();
        }
        ////Debug.Log(Horizontal);
        Vector2 position = transform.position;
        position.x = position.x + speedRate * Horizontal * Time.deltaTime;
        position.y = position.y + speedRate * Vertical * Time.deltaTime;
        //transform.position = position;
        newrigidbody2D.MovePosition(position);
    }

    private void Launch()
    {
        GameObject projecttileObject = Instantiate(projecttilePrefab, newrigidbody2D.position, Quaternion.identity);
        projectile projectile = projecttileObject.GetComponent<projectile>();
        projectile.Launch(lookdirection, 300);
    }

}
