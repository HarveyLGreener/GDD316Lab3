using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentUpRetrieve : AgentBaseState
{
    public override void EnterState(AgentController_FSM theAgent)
    {
    }

    public override void OnCollisionEnter(AgentController_FSM theAgent)
    {

    }

    public override void Update(AgentController_FSM theAgent)
    {
        PowerUp powerUp = GameObject.FindObjectOfType<PowerUp>();

        if (theAgent.gameObject.GetComponent<PoweredUp>()!=null)
        {
            Debug.Log("transition attempted");
            theAgent.TransitionToState(theAgent.PoweredUpState);
        }
        else if (powerUp == null)
        {
            theAgent.TransitionToState(theAgent.RetrieveState);
        }
        else
        {
            theAgent.NavMeshAgent.SetDestination(powerUp.gameObject.transform.position);
        }
    }
}
