using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;

    public override void Enter()
    {
        Enemy.Agent.SetDestination(Enemy.LastKnowPos);
    }

    public override void Perform()
    {
        if(Enemy.CanSeePlayer())
            stateMachine.ChangeState(new AttackState());        

        if (Enemy.Agent.remainingDistance < Enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.time;

            if (searchTimer > 3) 
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }    
    }  
}
