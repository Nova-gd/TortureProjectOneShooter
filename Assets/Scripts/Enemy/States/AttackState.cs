using UnityEngine;

public class AttackState : BaseState
{
    private float _moveTimer;
    private float _losePlayerTimer;
    private float _shotTimer;
    private float _shotForce = 10f;
    private float _timeForChangeState = 3f;

    //private int minimumEnemyWasteTime = 1;
    //private int maximumEnemyWasteTime = 3;
    //private int movementInsideUnitSphere = 2;

    public override void Enter() { }

    public override void Exit() { }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            _losePlayerTimer = 0;
            _moveTimer += Time.deltaTime;
            _shotTimer += Time.deltaTime;

            enemy.transform.LookAt(enemy.Player.transform);

            if (_shotTimer > enemy.fireRate)
            {
                Shoot();
            }

            //if (moveTimer > Random.Range(3, 7))
            //{
            //    enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
            //    moveTimer = 0;
            //}

            enemy.LastKnowPos = enemy.Player.transform.position;
        }
        else
        {
            _losePlayerTimer += Time.deltaTime;

            if (_losePlayerTimer > _timeForChangeState)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }
    public void Shoot()
    {
        Transform sourceOfDamage = enemy.SourceOfDamage;

        GameObject projectile = GameObject.Instantiate(Resources.Load("Prefabs/FireOrb") as GameObject, sourceOfDamage.position, enemy.transform.rotation);

        Vector3 shootDirection = ((enemy.Player.transform.position + Vector3.up) - sourceOfDamage.transform.position).normalized;

        projectile.GetComponent<Rigidbody>().velocity = shootDirection * _shotForce;

        _shotTimer = 0;
    }
}