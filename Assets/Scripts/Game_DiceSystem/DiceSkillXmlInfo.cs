using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game_DiceSystem
{
    public class DiceSkillXmlInfo
    {
        public DiceSkillXmlInfo()
        {
        }

        public DiceSkillXmlInfo(LiGameId id)
        {
            this._id = id._id;
        }
    
        public LiGameId id
        {
            get { return new LiGameId(this._id); } 
        }

        public string Name
        {
            get
            {
                return this.skillName;
            }
        }
        
        public LiGameId TextId
        {
            get
            {
                if (this._textId != -1)
                {
                    return new LiGameId(this._textId);
                }
                return this.id;
            }
        }
        
        public DiceSkillXmlInfo Copy(bool deepCopy = false)
        {
            List<DiceBehaviour> list;
            if (deepCopy)
            {
                list = new List<DiceBehaviour>();
                using (List<DiceBehaviour>.Enumerator enumerator = this.DiceBehaviourList.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        DiceBehaviour diceBehaviour = enumerator.Current;
                        list.Add(diceBehaviour.Copy());
                    }
                    goto IL_48;
                }
            }
            list = this.DiceBehaviourList;
            IL_48:
            return new DiceSkillXmlInfo(this.id)
            {
                Artwork = this.Artwork,
                DiceBehaviourList = list,
                _textId = this._textId,
                Priority = this.Priority,
                Script = this.Script,
                ScriptDesc = this.ScriptDesc,
                Spec = this.Spec,
                SpecialEffect = this.SpecialEffect,
                PriorityScript = this.PriorityScript
            };
        }
        
        [XmlAttribute("ID")]
        public int _id;
        [XmlElement("Name")]
        public string skillName = "";

        [XmlElement("TextId")]
        public int _textId = -1;

        public string Artwork = "";

        public DiceSkillSpec Spec = new DiceSkillSpec();
        [XmlElement("Script")]
        public string Script = "";

        public string ScriptDesc = "";
        [XmlArray("BehaviourList")]
        [XmlArrayItem("Behaviour")]
        public List<DiceBehaviour> DiceBehaviourList = new List<DiceBehaviour>();

        public string SpecialEffect = "";

        public int Priority;

        public string PriorityScript = "";
    }
}