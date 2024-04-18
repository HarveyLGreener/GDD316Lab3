using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPoweredUpState : AgentBaseState
{
    [SerializeField] private Vector3 closestPlayer = Vector3.zero;
    public override void EnterState(AgentController_FSM theAgent)
    {
        Debug.Log("entered state");
    }

    public override void OnCollisionEnter(AgentController_FSM theAgent)
    {

    }

    public override void Update(AgentController_FSM theAgent)
    {
        if (theAgent.gameObject.GetComponent<PoweredUp>()!=null)
        {
            Debug.Log("checked if it had power up");
            IndividualScoreTracker[] players = GameObject.FindObjectsOfType<IndividualScoreTracker>();
            foreach (IndividualScoreTracker player in players)
            {
                Debug.Log("entered for loop");
                if (player.gameObject != theAgent.gameObject && player.canBeStolenFrom)
                {
                    Debug.Log("entered if stetement1");
                    Vector3 distFromPlayer = player.gameObject.transform.position - theAgent.transform.position;
                    Vector3 distFromClosest = theAgent.transform.position - distFromPlayer;
                    if (distFromPlayer.magnitude < distFromClosest.magnitude || distFromPlayer == Vector3.zero)
                    {
                        Debug.Log("Entered if statement2");
                        Debug.Log(closestPlayer);
                        closestPlayer = player.gameObject.transform.position;
                    }
                }
            }
            theAgent.NavMeshAgent.SetDestination(closestPlayer);
        }
        else
        {
            theAgent.TransitionToState(theAgent.RetrieveState);
        }
    }

}
