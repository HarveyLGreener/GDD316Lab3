using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRetrieveState : AgentBaseState
{
    Vector3 closestCoin = Vector3.zero;
    private GameObject closeCoinGO = null;
    public override void EnterState(AgentController_FSM theAgent)
    {
    }

    public override void OnCollisionEnter(AgentController_FSM theAgent)
    {
    }

    public override void Update(AgentController_FSM theAgent)
    {
        
        if (GameObject.FindObjectOfType<PoweredUp>() != null)
        {
            GameObject powerfulGuy = GameObject.FindObjectOfType<PoweredUp>().gameObject;
            Vector3 neighborhood = theAgent.transform.position - powerfulGuy.transform.position;
            if (neighborhood.magnitude < 1.5f)
            {
                theAgent.TransitionToState(theAgent.RetreatState);
            }
        }
        if (GameObject.FindObjectOfType<PowerUp>() != null)
        {
            theAgent.TransitionToState(theAgent.UpRetrieveState);
        }
        else
        {
            //if (GameObject.FindObjectOfType<PoweredUp>() != null && GameObject.FindObjectOfType<PoweredUp>().gameObject != theAgent.gameObject)
            //{
            //theAgent.TransitionToState(theAgent.RetreatState);
            //}
            //else
            //{
            Coin[] coins = GameObject.FindObjectsOfType<Coin>();
            IndividualScoreTracker[] players = GameObject.FindObjectsOfType<IndividualScoreTracker>();
            foreach (Coin coin in coins)
            {
                Vector3 distFromCoin = coin.gameObject.transform.position - theAgent.transform.position;
                Vector3 distFromClosest = theAgent.transform.position - closestCoin;
                if (distFromCoin.magnitude <= distFromClosest.magnitude || closestCoin == Vector3.zero)
                {
                    foreach (IndividualScoreTracker player in players)
                    {
                        if (player == players[players.Length - 1] && distFromCoin.magnitude <= (player.gameObject.transform.position - coin.gameObject.transform.position).magnitude)
                        {
                            closeCoinGO = coin.gameObject;
                            closestCoin = coin.gameObject.transform.position;
                        }
                        else if (distFromCoin.magnitude <= (player.gameObject.transform.position - coin.gameObject.transform.position).magnitude)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            if (closestCoin != Vector3.zero && closeCoinGO != null)
            {
                theAgent.NavMeshAgent.SetDestination(closestCoin);
            }
            else
            {
                closestCoin = Vector3.zero;
                theAgent.NavMeshAgent.SetDestination(theAgent.center);
            }

            //}
        }
    }

    public void ResetCloseCoin()
    {
        closestCoin = Vector3.zero;
    }
}
