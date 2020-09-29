using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStandUp : MonoBehaviour
{
    public Hero hero;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Corporeal")
        {
            hero.ReSet();
        }
    }
}
