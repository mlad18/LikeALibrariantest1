using System.Collections;
using System.Collections.Generic;
using Game_DiceSystem;
using UnityEngine;

public class BattleSkillDataInUnit : MonoBehaviour
{
    public void InitSkill()
    {
        BattleDiceSkillModel Skill = BattleDiceSkillModel.XmlLoader(skillId);
        this.skill = Skill;
        this.ResetSkillQueue();
    }
    public void ResetSkillQueue()
    {
        if (this.skill == null)
        {
            return;
        }
        foreach (BattleDiceBehaviour battleDiceBehaviour in this.skill.CreateDiceSkillBehaviourList())
        {
            this.AddDice(battleDiceBehaviour);
        }
    }
    public List<BattleDiceBehaviour> GetDiceBehaviourList()
	{
		List<BattleDiceBehaviour> list = new List<BattleDiceBehaviour>();
		if (this.currentBehaviour != null)
		{
			list.Add(this.currentBehaviour);
		}
		foreach (BattleDiceBehaviour item in this.skillBehaviourQueue)
		{
			list.Add(item);
		}
		return list;
    }
    public BattleDiceBehaviour DequeueAbility()
    {
        BattleDiceBehaviour battleDiceBehaviour = null;
        while (this.skillBehaviourQueue.Count != 0 && !this.owner.IsDead())
        {
            battleDiceBehaviour = this.skillBehaviourQueue.Dequeue();
        }
        return battleDiceBehaviour;
    }
    public void NextDice()
    {
        this.currentBehaviour = this.DequeueAbility();
    }
    public void AddDice(BattleDiceBehaviour diceBehaviour)
    {
        this.skillBehaviourQueue.Enqueue(diceBehaviour);
        diceBehaviour.skill = this;
    }
    
    public BattleUnitModel owner;
    public BattleUnitModel target;
    public BattleDiceSkillModel skill;
    public Queue<BattleDiceBehaviour> skillBehaviourQueue = new Queue<BattleDiceBehaviour>();
    public BattleDiceBehaviour currentBehaviour;
    public int skillId;
}
