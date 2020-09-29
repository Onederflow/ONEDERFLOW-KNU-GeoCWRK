using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReJumping : MonoBehaviour
{
    public Hero hero;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Corporeal")
            hero.countJumps = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hero.countJumps = 1;
    }
}
