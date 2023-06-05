using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        RubyController controller = collision.GetComponent<RubyController>();
        controller.Changehealth(-10);
    }
}
