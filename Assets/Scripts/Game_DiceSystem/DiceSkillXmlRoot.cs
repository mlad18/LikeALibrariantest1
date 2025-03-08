using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game_DiceSystem
{
    public class DiceSkillXmlRoot
    {
        [XmlElement("Skill")]
        public List<DiceSkillXmlInfo> skillXmlList;
    }
}