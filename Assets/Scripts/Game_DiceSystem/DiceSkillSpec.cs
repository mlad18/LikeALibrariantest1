using System;
using System.Xml.Serialization;

namespace Game_DiceSystem
{
     public class DiceSkillSpec
    {
        public DiceSkillSpec Copy()
        {
            return new DiceSkillSpec
            {
                Cost = this.Cost,
                affection = this.affection
            };
        }
        [XmlAttribute("Cost")]
        public int Cost;
        public SkillAffection affection;
    }
}