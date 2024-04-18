using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPatrolState : AgentBaseState
{
    public override void EnterState(AgentController_FSM theAgent)
    {
        Debug.Log("patrol");
        theAgent.MeshRenderer.material.color = Color.green;
    }

    public override void OnCollisionEnter(AgentController_FSM theAgent)
    {
        
    }

    public override void Update(AgentController_FSM theAgent)
    {
        //Gets distance between this and the cube.
        Vector3 neighborhood = theAgent.transform.position - theAgent.myCube.transform.position;
        //Checks if the magnitude of hte position is less than 1.5, if it is it starts to attack
        Debug.Log(neighborhood.magnitude);
        if (neighborhood.magnitude < 1.5f)
        {
            theAgent.TransitionToState(theAgent.AttackState);
        }

        //Built in function that sets the destination of the navmesh
        theAgent.NavMeshAgent.SetDestination(theAgent.patrolPos);

    }
}
