using System.Collections;
using System.Collections.Generic;
using Game_DiceSystem;
using UnityEngine;

public class BattleDiceBehaviour
{
    public int DiceResultValue
    {
        get
        {
            return this._diceResultValue;
        }
    }
    public void SetIndex(int index)
    {
        this._index = index;
    }
    public void RollDice()
    {
        int diceMin = this.behaviourInSkill.Min;
        int diceMax = this.behaviourInSkill.Max;
        this._diceResultValue = Random.Range(diceMin, diceMax + 1);
        this.isUsed = true;
    }
    public void GiveDamage(BattleUnitModel target)
    {
        if (target != null)
        {
            int diceResultValue = this.DiceResultValue - this._damageReductionByGuard;
            if (diceResultValue < 0)
            {
                diceResultValue = 0;
            }
            int num = target.TakeDamage(diceResultValue);
        }
    }
    public void SetDamageReduction(int value)
    {
        this._damageReductionByGuard = value;
    }
    protected int _diceResultValue;
    public DiceBehaviour behaviourInSkill;
    public bool isBonusEvasion;
    public bool isUsed;
    private int _index;
    public BattleSkillDataInUnit skill;
    protected int _damageReductionByGuard;
}
