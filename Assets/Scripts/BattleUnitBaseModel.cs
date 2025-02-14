using System;

public class BattleUnitBaseModel : BattleObjectModel
{
    public bool IsDead()
    {
        return this._isDead;
    }
    public bool IsExtinction()
    {
        return this._isExtinction;
    }
    public bool CanRetargeting()
    {
        return this._retarget;
    }
    public void AfterRetargeting()
    {
        this._elapsedRetargeting = 0f;
        this._retarget = false;
    }
    public virtual void OnFixedUpdate(float deltaTime)
    {
        this._elapsedRetargeting += deltaTime;
        if (this._elapsedRetargeting > 5f)
        {
            this._retarget = true;
            this._elapsedRetargeting = 0f;
        }
    }
    protected virtual void OnFixedUpdateSkill(float deltaTime)
    {
    }
    protected virtual void OnDie(bool callEvent = true)
    {
    }
    public virtual void Damage()
    {
    }
    public virtual void AtkStart()
    {
    }
    public virtual void AtkEnd()
    {   
    }
    public bool IsCasting
    {
        get
        {
            return this.bCasting;
        }
    }
    public virtual void CastSkill()
    {
    }
    public virtual void AfterAttackSuccess(bool killed, BattleUnitModel attackedUnit)
    {
    }
    
    protected bool _isDead;
    protected bool _isExtinction;
    private float _elapsedRetargeting;
    private bool _retarget;
    protected bool bCasting;
}
