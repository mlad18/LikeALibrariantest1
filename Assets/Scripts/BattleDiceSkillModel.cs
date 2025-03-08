using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_DiceSystem;

public class BattleDiceSkillModel
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
    public static BattleDiceSkillModel XmlLoader(int id)
    {
        List<DiceSkillXmlInfo> list = new List<DiceSkillXmlInfo>();
        BattleDiceSkillModel battleDiceSkillModel = new BattleDiceSkillModel();
        list.AddRange(battleDiceSkillModel.loader.LoadSkill());
        DiceSkillXmlInfo info = list.Find((DiceSkillXmlInfo x) => x._id == id);
        return CreatePlayingSkill(info);
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
		battleDiceBehavior.behaviourInSkill = diceBehaviour.Copy();
		battleDiceBehavior.SetIndex(num);
		list.Add(battleDiceBehavior);
		num++;
	}
	return list;
    }
    private DiceSkillXmlInfo _xmlData = new DiceSkillXmlInfo();
    private int _curCost;
    public DataLoader loader = new DataLoader();
}
