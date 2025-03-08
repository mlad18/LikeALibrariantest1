using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Game_DiceSystem;
using UnityEngine;

public class DataLoader
{
    
    public List<DiceSkillXmlInfo> LoadSkill()
    {
        List<DiceSkillXmlInfo> list = new List<DiceSkillXmlInfo>();
        list.AddRange(this.LoadNewSkill("Xml/testskills").skillXmlList);

        
        return list;
    }
    private DiceSkillXmlRoot LoadNewSkill(string path)
    {
        DiceSkillXmlRoot result;
        using (StringReader stringReader = new StringReader(Resources.Load<TextAsset>(path).text))
        {
            result = (DiceSkillXmlRoot)new XmlSerializer(typeof(DiceSkillXmlRoot)).Deserialize(stringReader);
        }
        
        return result;
    }
}
