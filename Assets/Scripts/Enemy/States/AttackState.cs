using UnityEngine;

public class AttackState : BaseState
{
    private float _moveTimer;
    private float _losePlayerTimer;
    private float _shotTimer;
    private float _shotForce = 10f;
    private float _timeForChangeState = 3f;
    private int resetNumber = 0;

    public override void Perform()
    {
        if (Enemy.CanSeePlayer())
        {
            _losePlayerTimer = resetNumber;
            _moveTimer += Time.deltaTime;
            _shotTimer += Time.deltaTime;

            Enemy.transform.LookAt(Enemy.Player.transform);

            if (_shotTimer > Enemy.fireRate)
            {
                Shoot();
            }    

            Enemy.LastKnowPos = Enemy.Player.transform.position;
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
        Transform sourceOfDamage = Enemy.SourceOfDamage;

        GameObject projectile = GameObject.Instantiate(Resources.Load("Prefabs/FireOrb") as GameObject, sourceOfDamage.position, Enemy.transform.rotation);

        Vector3 shootDirection = ((Enemy.Player.transform.position + Vector3.up) - sourceOfDamage.transform.position).normalized;

        projectile.GetComponent<Rigidbody>().velocity = shootDirection * _shotForce;

        _shotTimer = resetNumber;
    }
}