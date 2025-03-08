using System.Collections;
using System.Collections.Generic;
using Game_DiceSystem;
using UnityEngine;

public class SimpleCombatExample : SingletonBehaviour<SimpleCombatExample>
{
    void Start()
    {
        this.playerSkill.InitSkill();
        this.enemySkill.InitSkill();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !battlePhase)
        {
            movePhase = true;
        }
        dst = Vector2.Distance(playerSkill.owner.transform.position, enemySkill.owner.transform.position);
        if (movePhase)
        {
            this.playerSkill.owner.SetSprite("M");
            this.enemySkill.owner.SetSprite("M");
            this.playerSkill.owner.transform.position = Vector2.MoveTowards(this.playerSkill.owner.transform.position, this.enemySkill.owner.transform.position, speed * Time.deltaTime);
            this.enemySkill.owner.transform.position = Vector2.MoveTowards(this.enemySkill.owner.transform.position, this.playerSkill.owner.transform.position, speed * Time.deltaTime);
        }
        if (dst < 5f && movePhase == true)
        {
            speed = 0f;
            movePhase = false;
            Singleton<BattleParryingManager>.Instance.StartParrying(this.playerSkill, this.enemySkill);
            battlePhase = true;
        }
    }

    public BattleSkillDataInUnit playerSkill;
    public BattleSkillDataInUnit enemySkill;
    public float speed = 25f;
    public float dst;
    private bool movePhase = false;
    private bool battlePhase = false;

}
