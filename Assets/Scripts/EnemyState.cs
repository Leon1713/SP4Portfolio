using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : State
{   
}

// Cannot Animated due to materials properties being shared in editor.
public class EnemyStateDead : State
{
    private Renderer renderer;
    private Animation animation;
    private ScoreManager scoreManager;
    public EnemyStateDead(GameObject go_Ref)
    {
        objectReference = go_Ref;
        animation = go_Ref.GetComponent<Animation>();
        renderer = go_Ref.GetComponent<Renderer>();
    }

    public override void enter() 
    {
        base.enter();
        animation.Play("Die");
        objectReference.GetComponent<NavMeshAgent>().isStopped = true;
        scoreManager = GameObject.Find("Managers").transform.GetChild(3).GetComponent<ScoreManager>();
       
    }

    public override void update()
    {
        base.update();
        if(animation.isPlaying == false)
        {
            scoreManager.Score += 30;
            objectReference.SendMessage("DestroySelf");
        }

    }

    public override void exit()
    {
        base.exit();
        
    }
}
public class EnemyStateIdle : State
{

    public EnemyStateIdle(GameObject go_Ref)
    {
        objectReference = go_Ref;
    }

    public override void enter()
    {
        // do nth at the moment
        base.enter();
    }

    public override void update()
    {
        base.update();
        if (objectReference.GetComponent<Enemy>().health <= 0)
        {
            objectReference.GetComponent<Enemy>().sm.setNextState("EnemyDead");
            return;
        }
        objectReference.GetComponent<Enemy>().sm.setNextState("EnemyChase");
       
    }

    public override void exit()
    {
        base.exit();
    }

}

public class EnemyStateWander : State
{
    GameObject player;
    float DistanceSee;
    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
    public EnemyStateWander(GameObject go_Ref)
    {
        
        objectReference = go_Ref;
    }

    public override void enter()
    {
        base.enter();
        player = GameObject.Find("Player");
        DistanceSee = 100;
    }

    public override void update()
    {
        base.update();
        if(objectReference.GetComponent<Enemy>().health <= 0)
        {
            objectReference.GetComponent<Enemy>().sm.setNextState("EnemyDead");
            return;
        }
        // wander
        if ((player.transform.position - objectReference.transform.position).sqrMagnitude <= 36)
        {
            objectReference.GetComponent<Enemy>().sm.setNextState("EnemyChase");
        }
        else if(objectReference.GetComponent<NavMeshAgent>().hasPath == false)
        {
            Vector3 newPos = RandomNavSphere(objectReference.transform.position, DistanceSee, -1);
            objectReference.GetComponent<NavMeshAgent>().SetDestination(newPos);
        }
    }

    public override void exit()
    {
        base.exit();
    }
}



public class EnemyStateChase : State
{
    private GameObject player;
    private float health;
    private float moveSpeed;
    public EnemyStateChase(GameObject go_Ref) // test move towards target which is player
    {
        player = GameObject.Find("Player"); // target is player
        objectReference = go_Ref; // go ref is reference to gameobject which is calling the statemachine (in this case is enemy gameObject)
        health = go_Ref.GetComponent<Enemy>().health;
        moveSpeed = go_Ref.GetComponent<Enemy>().moveSpeed;
    }

    public override void enter()
    {
        // do nth at the moment
        base.enter();
    }

    public override void update()
    {
        base.update();
        if (objectReference.GetComponent<Enemy>().health <= 0)
        {
            objectReference.GetComponent<Enemy>().sm.setNextState("EnemyDead");
            return;
        }
        // move towards target
        if ((player.transform.position - objectReference.transform.position).sqrMagnitude <= 36)
        {
            objectReference.GetComponent<NavMeshAgent>().destination = player.transform.position;
        }
        else
        {
            objectReference.GetComponent<Enemy>().sm.setNextState("EnemyWander");
        }
    }

    public override void exit()
    {
        base.exit();
    }
}
