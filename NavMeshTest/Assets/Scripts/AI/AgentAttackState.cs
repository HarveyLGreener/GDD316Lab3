using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttackState : AgentBaseState
{
    public override void EnterState(AgentController_FSM theAgent)
    {
        Debug.Log("attack");
        theAgent.MeshRenderer.material.color = Color.red;
    }

    public override void OnCollisionEnter(AgentController_FSM theAgent)
    {
    }

    public override void Update(AgentController_FSM theAgent)
    {
        //Checks if the agent is still around the correct distance to attack. If the magnitude is too low, it retreats
        Vector3 neighborhood = theAgent.transform.position - theAgent.fightPos;
        if (neighborhood.magnitude < 1.5f )
        {
            theAgent.TransitionToState(theAgent.RetreatState);
        }
        theAgent.NavMeshAgent.SetDestination(theAgent.fightPos);
    }
}
