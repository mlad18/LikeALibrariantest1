using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game_DiceSystem
{
    public class SpeedDiceRule
    {
        public SpeedDiceRule(int min, int max, int num, int breakNum = 0)
        {
            this.diceMin = min;
            this.diceNum = num;
            this.diceMax = max;
            this.speedDiceList = new List<SpeedDice>();
            for (int i = 0; i < this.diceNum; i++)
            {
                this.speedDiceList.Add(new SpeedDice
                {
                    min = min,
                    value = 0,
                    max = max,
                    breaked = (breakNum > 0)
                });
                breakNum--;
                if (breakNum < 0)
                {
                    breakNum = 0;
                }
            }
        }
       public List<SpeedDice> Roll(BattleUnitModel unitmodel)
        {
            for (int i = 0; i < this.speedDiceList.Count; i++)
            {
                SpeedDice speedDice = this.speedDiceList[i];
                speedDice.value = UnityEngine.Random.Range(speedDice.min, speedDice.max + 1);
            }
            return this.speedDiceList;
        }

        public string GetDiceRangeText()
        {
            return this.diceMin + "~" + this.diceMax;
        }

        public int diceNum;
        public int breakedNum;
        public int diceMin = 1;
        public int diceMax;
        public List<SpeedDice> speedDiceList;
    }
}