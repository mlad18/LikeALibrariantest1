using System;
// using System.Xml.Serialization;

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

        public int Min = 1;

        public int Max;
        public BehaviourType Type;

        public BehaviourDetail Detail;

        public MotionDetail MotionDetail;

        public MotionDetail MotionDetailDefault = MotionDetail.N;

        public int KnockbackPower = 1;

        public string EffectRes = "";

        public string Script = "";

        public string ActionScript = "";

        public string Desc = "";

    }
}