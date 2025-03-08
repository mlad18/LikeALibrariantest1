using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitTestButtons : MonoBehaviour
{

    public void DealDamage()
    {
        Debug.Log("Dealing damage");
        this.unit.TakeDamage(20);
    }
    public void ChangeSprite()
    {
        Debug.Log("Sprite Changed");
        this.unit.SetSprite("S");
    }
    public BattleUnitModel unit;
}
