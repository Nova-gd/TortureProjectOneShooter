using UnityEngine;

public class PatrolState : BaseState
{
    private float _enemyWaitOnPoint = 3;
    private float _minimalDistanceWayPoint = 0.2f;

    public int WayPointIndex;
    public float WaitTimer;    

    public override void Enter()
    {
       
    }

    public override void Perform()
    {
        PatrolCycle();

        if (enemy.CanSeePlayer()) 
        { 
            stateMachine.ChangeState(new AttackState());
        }
    }

    public override void Exit()
    {
        
    }

    public void PatrolCycle()
    {            
        if (enemy.Agent.remainingDistance < _minimalDistanceWayPoint) 
        {
            WaitTimer += Time.deltaTime;

            if (WaitTimer > _enemyWaitOnPoint)
            {
                if (WayPointIndex < enemy.path.waypoints.Count -1)
                {
                    WayPointIndex++; ;
                }
                else
                {
                    WayPointIndex=0;
                }
            }
            enemy.Agent.SetDestination(enemy.path.waypoints[WayPointIndex].position);
        }
    }
}
