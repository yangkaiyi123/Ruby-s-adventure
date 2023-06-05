using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController rubyController = collision.GetComponent<RubyController>();
        //�ж��Ƿ�Ϊ��Ϸ����
        if (rubyController != null)
        {
            //����������Ѫ���ܼ�Ѫ
            if (rubyController.currentHealth < rubyController.maxHealth)
            {
                rubyController.Changehealth(20);
                Destroy(gameObject);
            }         
        } 
    }
}
