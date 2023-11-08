using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Status_Script : MonoBehaviour
{
    public float maxHp;
    public float nowHp;
    public int defensePower;
    public float attackPower;
    public int durabilityNegation;
    public float attackSpeed;

    private float attackDelay;

    public void Attack(Unit_Status_Script target)
    {
        attackDelay += Time.deltaTime;

        if (attackSpeed <= attackDelay)
        {
            int defensePercent = target.defensePower - durabilityNegation;
            if (defensePercent <= 0)
            {
                defensePercent = 0;
            }

            float damage = attackPower - (attackPower * defensePercent / 100);

            target.nowHp -= damage;
            attackDelay = Time.deltaTime;
        }
    }

    public Boolean CheckingDying()
    {
        if (nowHp <= 0)
            return true;
        else
            return false; 
    }
}
