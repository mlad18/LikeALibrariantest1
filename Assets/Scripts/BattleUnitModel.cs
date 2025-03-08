using System;
using System.Collections.Generic;
using Game_DiceSystem;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnitModel : BattleUnitBaseModel
{
    public int TakeDamage(int v, BattleUnitModel attacker = null)
    {
        if (base.IsDead())
        {
            return 0;
        }
        int num = (int)this.hp;
        int num2 = v;
        if (num2 <= 0)
        {
            num2 = 0;
        }
        this.hp -= num2;
        healthbar.fillAmount = this.hp / (float)MaxHp;
        if (this.hp <= 0f)
        {
            this.Die();
        }
        return num2;
    }
    public void SetSprite(string x)
    {
        switch (x)
        {
           case "N":
           this.GetComponent<SpriteRenderer>().sprite = N;
           break;
           case "M":
           this.GetComponent<SpriteRenderer>().sprite = M;
           break;
           case "S":
           this.GetComponent<SpriteRenderer>().sprite = S;
           break;
           case "G":
           this.GetComponent<SpriteRenderer>().sprite = G;
           break;
           case "E":
           this.GetComponent<SpriteRenderer>().sprite = E;
           break;
           default:
           this.GetComponent<SpriteRenderer>().sprite = N;
           break;
        }
    }
    public void Die()
    {
        Debug.Log("Unit Dead");
        this._isDead = true;
    }
    public int MaxHp;
    public int MinHp = -999;
    public float hp;

    public Image healthbar;
    public Sprite N;
    public Sprite M;
    public Sprite S;
    public Sprite G;
    public Sprite E;

}
