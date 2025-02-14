using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// when clashing characters should be moving towards each other
// one sided only the attacking character should be moving
// when a character(s) reach their target they should slow down
// figure out how to implement stuff later (use chatGPT and YouTube)
/* public class BattleUnitMover : MonoBehaviour
{
    public bool IsArrived
    {
        get
        {
            return this._bArrived;
        }
    }
    
    public void SetFollower(Transform t)
    {
        this._target = t;
    }

    public void SetMoveDst(Vector3 pos)
    {
        this._destination = pos;
    }

    public void SetMoveDir(Vector3 dir)
    {
        this._direction = dir;
    }

    public void SetAcceleration(float accel)
    {
        this._acceleration = accel;
    }

    public void SetSpeed(float speed)
    {
        this._speed = speed;
    }

    public void Stop()
    {
        this._speed = 0f;
    }

    private void FixedUpdate()
    {
        if(!this.CheckArrived())
        {
            this.UpdateByFollowing();
            this.Move();
        }
    }
    
    private void UpdateByFollowing()
    {
        if (this._target != null)
        {
            this._direction = (this_target.position - base.transform.position).normalized;
            float d = SingletonBehaviour<
        }
    }
}
*/