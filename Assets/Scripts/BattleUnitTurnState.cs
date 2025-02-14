using System;

public enum BattleUnitTurnState
{
    WAIT_TURN,
    WAIT_CARD,
    DOING_ACTION,
    DONE_ACTION,
    DOING_INTERLACE,
    DOING_PARRYING,
    SKIP_TURN,
    BREAK
}
