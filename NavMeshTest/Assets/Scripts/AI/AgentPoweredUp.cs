using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPoweredUp : AgentBaseState
{
    private Vector3 whereToGo = Vector3.zero;
    private Vector3 closestPlayer = Vector3.zero;
    private GameObject closestPlayerGO = null;
    // Start is called before the first frame update
    public override void EnterState(AgentController_FSM theAgent)
    {
        Debug.Log("Entered");
    }

    public override void OnCollisionEnter(AgentController_FSM theAgent)
    {

    }

    public override void Update(AgentController_FSM theAgent)
    {
        if (theAgent.gameObject.GetComponent<PoweredUp>()!=null)
        {
            IndividualScoreTracker[] players = GameObject.FindObjectsOfType<IndividualScoreTracker>();
            foreach (IndividualScoreTracker player in players)
            {
                if ((closestPlayerGO == null || (player.transform.position).magnitude<=(closestPlayerGO.transform.position).magnitude) && player.gameObject != theAgent.gameObject && player.canBeStolenFrom)
                {
                    closestPlayerGO = player.gameObject;
                }
            }
            if (closestPlayerGO != null && closestPlayerGO.GetComponent<IndividualScoreTracker>().canBeStolenFrom)
            {
                whereToGo = closestPlayerGO.transform.position;
            }
            else
            {
                closestPlayerGO = null;
                whereToGo = theAgent.center;
            }
            theAgent.NavMeshAgent.SetDestination(whereToGo);

        }
        else
        {
            theAgent.TransitionToState(theAgent.RetrieveState);
        }
    }
}
