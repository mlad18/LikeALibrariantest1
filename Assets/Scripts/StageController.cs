using System.Collections;
using System.Collections.Generic;
/* using Game_DiceSystem;
using UnityEngine;

public class StageController : Singleton<StageController>
{
    
    private int _timeLevel = 1;
    public enum StageState
    {
        None,
        Battle
    }
    public enum StagePhase
    {
        RoundStartPhase_UI,
        RoundStartPhase_System,
        DrawCardPhase,
        SortUnitPhase,
        ApplyEnemySkillPhase,
        ApplyLibrarianSkillPhase,
        PeekFirstTurnUnitPhase,
        ExecuteParrying,
        EndParrying,
        RoundEndPhase,
        RoundEndPhase_2,
        ExecuteUnitsActionPhase,
        ChangeMapPhase,
        ArrangeEquippedCards,
        ActivateStartBattleEffect,
        WaitStartBattleEffect,
        SetCurrentDiceAction,
        CheckParrying,
        MoveUnits,
        WaitUnitsArrive,
        CheckOneSideAction,
        ExecuteOneSideAction,
        EndOneSideAction,
        ProcessViewAction,
        EndBattle
    }
    public enum StageMapState
    {
        Librarian,
        Enemy
    }
    public delegate void OnChangePhaseDelegate(StageController.StagePhase prevPhase, StageController.StagePhase nextPhase);
    public enum BattleState
    {
        None,
        Battle,
        Setting
    }
    private struct ParryingCards
    {
        internal BattlePlayingSkillDataInUnitModel skillA;
        internal BattlePlayingSkillDataInUnitModel skillB;
    }
    private class AddedSkillSet
    {
        public BattlePlayingSkillDataInUnitModel skill;
        public BattleUnitModel target;
        public int targetSlot = -1;
    }
}
*/