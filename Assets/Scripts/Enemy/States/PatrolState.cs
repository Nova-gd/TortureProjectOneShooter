using UnityEngine;

public class PatrolState : BaseState
{
    private float _enemyWaitOnPoint = 3;
    private float _minimalDistanceWayPoint = 0.2f;

    public int WayPointIndex;
    public float WaitTimer;

    public override void Perform()
    {
        PatrolCycle();

        if (Enemy.CanSeePlayer()) 
        { 
            stateMachine.ChangeState(new AttackState());
        }
    }

    public void PatrolCycle()
    {            
        if (Enemy.Agent.remainingDistance < _minimalDistanceWayPoint) 
        {
            WaitTimer += Time.deltaTime;

            if (WaitTimer > _enemyWaitOnPoint)
            {
                if (WayPointIndex < Enemy.Path.waypoints.Count -1)
                {
                    WayPointIndex++; ;
                }
                else
                {
                    WayPointIndex=0;
                }
            }
            Enemy.Agent.SetDestination(Enemy.Path.waypoints[WayPointIndex].position);
        }
    }
}
