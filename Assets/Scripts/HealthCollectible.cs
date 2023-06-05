using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController rubyController = collision.GetComponent<RubyController>();
        //判断是否为游戏主角
        if (rubyController != null)
        {
            //限制主角满血不能加血
            if (rubyController.currentHealth < rubyController.maxHealth)
            {
                rubyController.Changehealth(20);
                Destroy(gameObject);
            }         
        } 
    }
}
