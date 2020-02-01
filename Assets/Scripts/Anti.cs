using System;
using UnityEngine;

public class Anti : Cell
{
    public int glycoproteinCost = 10;
    public int aminoAcidCost = 20;

    private void Update()
    {
        AttackOrMove("virus");
        CheckAlive();
    }   
    void CheckAlive()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
