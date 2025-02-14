using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_DiceSystem;

public class BattleDiceSkillModel : MonoBehaviour
{
    public DiceSkillXmlInfo XmlData
    {
        get 
        {
            return this._xmlData;
        }
    }
    public int CurCost
    {
        get
        {
            return this._curCost;
        }
    }
    public string GetName()
    {
        return _xmlData.Name;
    }
    public static BattleDiceSkillModel CreatePlayingSkill(DiceSkillXmlInfo skillInfo)
    {
        BattleDiceSkillModel battleDiceSkillModel = new BattleDiceSkillModel();
        battleDiceSkillModel._xmlData = skillInfo.Copy(false);
        return battleDiceSkillModel;

    }
    public List<BattleDiceBehaviour> CreateDiceSkillBehaviourList()
    {
        List<BattleDiceBehaviour> list = new List<BattleDiceBehaviour>();
	int num = 0;
	foreach (DiceBehaviour diceBehaviour in this._xmlData.DiceBehaviourList)
	{
		string script = diceBehaviour.Script;
		BattleDiceBehaviour battleDiceBehavior = new BattleDiceBehaviour();
		battleDiceBehavior.behaviourInCard = diceBehaviour.Copy();
		battleDiceBehavior.SetIndex(num);
		list.Add(battleDiceBehavior);
		num++;
	}
	return list;
    }
    private DiceSkillXmlInfo _xmlData;
    private int _curCost;
}
