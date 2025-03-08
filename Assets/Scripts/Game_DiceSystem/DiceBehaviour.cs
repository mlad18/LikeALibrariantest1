using System;
using System.Xml.Serialization;

namespace Game_DiceSystem
{
    public class DiceBehaviour
    {
        public string GetMinText()
        {
            return this.Min.ToString();
        }
        
        public string GetMaxText()
        {
            return this.Max.ToString();
        }
        
        public DiceBehaviour Copy()
        {
            return new DiceBehaviour
            {
                Min = this.Min,
                Max = this.Max,
                Type = this.Type,
                Detail = this.Detail,
                MotionDetail = this.MotionDetail,
                MotionDetailDefault = this.MotionDetailDefault,
                KnockbackPower = this.KnockbackPower,
                EffectRes = this.EffectRes,
                Script = this.Script,
                ActionScript = this.ActionScript,
                Desc = this.Desc
            };
        }
        [XmlAttribute]
        public int Min = 1;
        [XmlAttribute]
        public int Max;
        [XmlAttribute]
        public BehaviourType Type;
        [XmlAttribute]
        public BehaviourDetail Detail;
        [XmlAttribute("Motion")]
        public MotionDetail MotionDetail;
        [XmlAttribute("MotionDefault")]
        public MotionDetail MotionDetailDefault = MotionDetail.N;
        [XmlIgnore]
        public int KnockbackPower = 1;
        [XmlAttribute]
        public string EffectRes = "";
        [XmlAttribute]
        public string Script = "";
        [XmlAttribute]
        public string ActionScript = "";
        [XmlAttribute]
        public string Desc = "";

    }
}