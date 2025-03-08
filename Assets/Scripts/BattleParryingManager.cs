using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game_DiceSystem;
using UnityEngine;

public class BattleParryingManager : Singleton<BattleParryingManager>
{

    public void StartParrying(BattleSkillDataInUnit skillEnemy, BattleSkillDataInUnit skillLibrarian)
    {
        this._teamEnemy.Init(skillEnemy.owner, skillEnemy);
        this._teamLibrarian.Init(skillLibrarian.owner, skillLibrarian);
        this._teamEnemy.SetOpponent(this._teamLibrarian);
        this._teamLibrarian.SetOpponent(this._teamEnemy);
        this._teamEnemy.NextDice();
        this._teamLibrarian.NextDice();
        if (this._teamEnemy.unit.IsDead() || this._teamLibrarian.unit.IsDead() || (!this._teamEnemy.DiceExists() && !this._teamLibrarian.DiceExists()))
        {
            this.EndParrying();
            return;
        }
        this.FirstApproachPhase();
    }
    private void FirstApproachPhase()
    {
        this.Decision();
    }
    private void Decision()
    {
        this._teamEnemy.unit.SetSprite("N");
        this._teamLibrarian.unit.SetSprite("N");
        this.RollDice();
        if (this._teamEnemy.DiceExists() && !this._teamLibrarian.DiceExists())
        {
            this._decisionResult = BattleParryingManager.ParryingDecisionResult.WinEnemy;
        }
        else if (!this._teamEnemy.DiceExists() && this._teamLibrarian.DiceExists())
        {
            this._decisionResult = BattleParryingManager.ParryingDecisionResult.WinLibrarian;
        }
        else if (this._teamEnemy.DiceExists() && this._teamLibrarian.DiceExists())
        {
            this._decisionResult = this.GetDecisionResult(this._teamEnemy, _teamLibrarian);
        }
        if (this._teamEnemy.GetParryingDiceType() == BattleParryingManager.ParryingDiceType.Attack && this._teamLibrarian.GetParryingDiceType() == BattleParryingManager.ParryingDiceType.Defense)
		{
			this._currentAttackerTeam = this._teamEnemy;
			this._currentDefenderTeam = this._teamLibrarian;
		}
		else if (this._teamLibrarian.GetParryingDiceType() == BattleParryingManager.ParryingDiceType.Attack && this._teamEnemy.GetParryingDiceType() == BattleParryingManager.ParryingDiceType.Defense)
		{
			this._currentAttackerTeam = this._teamLibrarian;
			this._currentDefenderTeam = this._teamEnemy;
		}
        if (this._decisionResult == BattleParryingManager.ParryingDecisionResult.WinEnemy)
        {
            this._currentWinnerTeam = this._teamEnemy;
            this._currentLoserTeam = this._teamLibrarian;
        }
        else if (this._decisionResult == BattleParryingManager.ParryingDecisionResult.WinLibrarian)
        {
            this._currentWinnerTeam = this._teamLibrarian;
            this._currentLoserTeam = this._teamEnemy;
        }
        else 
        {
            this._currentWinnerTeam = null;
            this._currentLoserTeam = null;
        }
        if (this._teamLibrarian.DiceExists())
        {
            this._teamLibrarian.playingSkill.currentBehaviour.isBonusEvasion = false;
        }
        if (this._teamEnemy.DiceExists())
        {
            this._teamEnemy.playingSkill.currentBehaviour.isBonusEvasion = false;
        }
        this.ActionPhase();
    }
    private void ActionPhase()
    {
        if (this._decisionResult == BattleParryingManager.ParryingDecisionResult.Draw)
        {
            this.Draw();
        }
        else if (this._currentWinnerTeam.GetParryingDiceType() == BattleParryingManager.ParryingDiceType.Attack)
		{
			if (this._currentLoserTeam.GetParryingDiceType() == BattleParryingManager.ParryingDiceType.Attack)
			{
				this.ActionPhaseAtkVSAtk();
			}
			else
			{
				this.ActionPhaseAtkVSDfn();
			}
		}
		else if (this._currentLoserTeam.DiceExists())
		{
			if (this._currentLoserTeam.GetParryingDiceType() == BattleParryingManager.ParryingDiceType.Attack)
			{
				this.ActionPhaseAtkVSDfn();
			}
			else
			{
				this.ActionPhaseDfnVSDfn();
			}
		}
		this.EndAction();
    }
    private void ActionPhaseAtkVSAtk()
	{
		BattleUnitModel unit = this._currentWinnerTeam.unit;
		BattleUnitModel unit2 = this._currentLoserTeam.unit;
        if (this._currentWinnerTeam.playingSkill.currentBehaviour != null)
        {
            this._currentWinnerTeam.unit.SetSprite("S");
            this._currentWinnerTeam.playingSkill.currentBehaviour.GiveDamage(unit2);
            return;
        }
    }
    private void Draw()
    {
        this._teamEnemy.unit.SetSprite("E");
        this._teamLibrarian.unit.SetSprite("E");
    }
    private void ActionPhaseAtkVSDfn()
    {
        if (!this._currentDefenderTeam.DiceExists())
        {
            this._currentAttackerTeam.unit.SetSprite("S");
            this._currentAttackerTeam.playingSkill.currentBehaviour.GiveDamage(this._currentDefenderTeam.unit);
            return;
        }
        if (this._currentDefenderTeam.GetBehaviourDetail() == BehaviourDetail.Guard)
        {
            if (this._currentDefenderTeam == this._currentLoserTeam)
            {
                this._currentAttackerTeam.unit.SetSprite("S");
                this._currentAttackerTeam.playingSkill.currentBehaviour.SetDamageReduction(this._currentDefenderTeam.GetDiceValue());
                this._currentAttackerTeam.playingSkill.currentBehaviour.GiveDamage(this._currentDefenderTeam.unit);
                return;
            }
            else
            {
                this._currentDefenderTeam.unit.SetSprite("G");
                this._currentAttackerTeam.unit.SetSprite("S");
                Debug.Log("Defence Win");
                return;
            }

        }
        else if (this._currentDefenderTeam.GetBehaviourDetail() == BehaviourDetail.Evade)
        {
            if (this._currentDefenderTeam == this._currentLoserTeam)
            {
                this._currentAttackerTeam.unit.SetSprite("S");
                this._currentAttackerTeam.playingSkill.currentBehaviour.GiveDamage(this._currentDefenderTeam.unit);
                return;
            }
            else
            {
                this._currentDefenderTeam.unit.SetSprite("E");
                this._currentAttackerTeam.unit.SetSprite("S");
                this._currentDefenderTeam.playingSkill.currentBehaviour.isBonusEvasion = true;
                Debug.Log("Evade Win");
                return;
            }
        }
    }
    private void ActionPhaseDfnVSDfn()
    {
        this._teamEnemy.unit.SetSprite("G");
        this._teamEnemy.unit.SetSprite("G");
    }
    private void EndParrying()
    {
        Debug.Log("Clash End");
        return;
    }
    private void CheckParryingEnd()
    {
        if (this._teamEnemy.unit.IsDead() || this._teamLibrarian.unit.IsDead() || (!this._teamEnemy.DiceExists() && !this._teamLibrarian.DiceExists()))
        {
            this.EndParrying();
            return;
        }
        Debug.Log("Clash Continue");
        Task.Delay(1800).ContinueWith(t=> this.Decision());
    }
    private void EndAction()
    {
        if (this._teamEnemy.DiceExists() && !this._teamEnemy.playingSkill.currentBehaviour.isBonusEvasion)
        {
            this._teamEnemy.NextDice();
        }
        if (this._teamLibrarian.DiceExists() && !this._teamLibrarian.playingSkill.currentBehaviour.isBonusEvasion)
        {
            this._teamLibrarian.NextDice();
        }
        this.CheckParryingEnd();
    }
    public void RollDice()
    {
        this._teamEnemy.RollDice();
		this._teamLibrarian.RollDice();
		this._teamEnemy.UpdateDiceValue();
		this._teamLibrarian.UpdateDiceValue();
    }
    private BattleParryingManager.ParryingDecisionResult GetDecisionResult(BattleParryingManager.ParryingTeam teamA, BattleParryingManager.ParryingTeam teamB)
    {
        if (teamA.DiceExists() && teamB.DiceExists())
        {
            if (teamA.GetBehaviourDetail() == BehaviourDetail.Evade && teamB.GetBehaviourDetail() == BehaviourDetail.Evade)
            {
                return BattleParryingManager.ParryingDecisionResult.Draw;
            }
            int num = teamA.diceValue - teamB.diceValue;
            if (num >= 1)
            {
                return BattleParryingManager.ParryingDecisionResult.WinEnemy;
            }
            if (num <= -1)
            {
                return BattleParryingManager.ParryingDecisionResult.WinLibrarian;
            }
            return BattleParryingManager.ParryingDecisionResult.Draw;
        }
        else
        {
            if (teamA.DiceExists() && !teamB.DiceExists())
            {
                return BattleParryingManager.ParryingDecisionResult.WinEnemy;
            }
            if (!teamA.DiceExists() && teamB.DiceExists())
            {
                return BattleParryingManager.ParryingDecisionResult.WinLibrarian;
            }
            return BattleParryingManager.ParryingDecisionResult.Draw;
        }
    }
    private BattleParryingManager.ParryingDecisionResult _decisionResult;
    private BattleParryingManager.ParryingTeam _teamLibrarian = new BattleParryingManager.ParryingTeam();
    private BattleParryingManager.ParryingTeam _teamEnemy = new BattleParryingManager.ParryingTeam();
	private BattleParryingManager.ParryingTeam _currentWinnerTeam;
	private BattleParryingManager.ParryingTeam _currentLoserTeam;
	private BattleParryingManager.ParryingTeam _currentAttackerTeam;
	private BattleParryingManager.ParryingTeam _currentDefenderTeam;

    public enum ParryingDiceType
    {
        Attack,
        Defense
    }

    public class ParryingTeam
    {
        public void Init(BattleUnitModel unit, BattleSkillDataInUnit playingSkill)
        {
            this.unit = unit;
            this.playingSkill = playingSkill;
        }
        public void SetOpponent(BattleParryingManager.ParryingTeam opponent)
        {
            this.opponent = opponent;
        }
        public void NextDice()
        {
            this.playingSkill.NextDice();
        }
        public void RollDice()
        {
            if (this.playingSkill.currentBehaviour != null)
            {
                this.playingSkill.currentBehaviour.RollDice();
            }
        }
        public bool DiceExists()
        {
            return this.playingSkill.currentBehaviour != null;
        }
        public int GetDiceValue()
		{
			return this.diceValue;
		}
        public void UpdateDiceValue()
        {
            if (this.playingSkill.currentBehaviour != null)
            {
                this.diceValue = this.playingSkill.currentBehaviour.DiceResultValue;
                return;
            }
            this.diceValue = 0;
        }
        public BehaviourDetail GetBehaviourDetail()
        {
            if (this.playingSkill.currentBehaviour == null)
			{
				return BehaviourDetail.None;
			}
			return this.playingSkill.currentBehaviour.behaviourInSkill.Detail;
        }
        public BattleParryingManager.ParryingDiceType GetParryingDiceType()
		{
			if (this.playingSkill.currentBehaviour == null)
			{
				return BattleParryingManager.ParryingDiceType.Defense;
			}
			if (this.playingSkill.currentBehaviour.behaviourInSkill.Type == BehaviourType.Atk)
			{
				return BattleParryingManager.ParryingDiceType.Attack;
			}
			if (this.playingSkill.currentBehaviour.behaviourInSkill.Type == BehaviourType.Def)
			{
				return BattleParryingManager.ParryingDiceType.Defense;
			}
			BattleParryingManager.ParryingDiceType result = BattleParryingManager.ParryingDiceType.Defense;
			switch (this.playingSkill.currentBehaviour.behaviourInSkill.Detail)
			{
			case BehaviourDetail.Slash:
				result = BattleParryingManager.ParryingDiceType.Attack;
				break;
			case BehaviourDetail.Pierce:
				result = BattleParryingManager.ParryingDiceType.Attack;
				break;
			case BehaviourDetail.Blunt:
				result = BattleParryingManager.ParryingDiceType.Attack;
				break;
			case BehaviourDetail.Guard:
				result = BattleParryingManager.ParryingDiceType.Defense;
				break;
			case BehaviourDetail.Evade:
				result = BattleParryingManager.ParryingDiceType.Defense;
				break;
			case BehaviourDetail.None:
				result = BattleParryingManager.ParryingDiceType.Defense;
				break;
			}
			return result;
		}

        public BattleUnitModel unit;
        public BattleSkillDataInUnit playingSkill;
        private BattleParryingManager.ParryingTeam opponent;
        public int diceValue;
    }
    public enum ParryingDecisionResult
    {
        Draw,
        WinEnemy,
        WinLibrarian
    }
}
