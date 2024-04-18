using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController_FSM : MonoBehaviour
{
    #region Agent Variables

    public GameObject myCube;

    public Vector3 safePos;
    public Vector3 fightPos;
    public Vector3 patrolPos;

    //private Rigidbody rbody;
    private MeshRenderer meshRenderer;
    private NavMeshAgent agent;

    //public Rigidbody Rigidbody
    //{
    //    get { return rbody; }
    //}

    public MeshRenderer MeshRenderer
    {
        get { return meshRenderer;}
    }
    public NavMeshAgent NavMeshAgent
    {
        get { return agent; }
    }
    #endregion

    private AgentBaseState currentState;

    public Vector3 center;

    public AgentBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly AgentAttackState AttackState = new AgentAttackState();
    public readonly AgentPatrolState PatrolState = new AgentPatrolState();
    public readonly AgentRetreatSate RetreatState = new AgentRetreatSate();
    public readonly AgentRetrieveState RetrieveState = new AgentRetrieveState();
    public readonly AgentUpRetrieve UpRetrieveState = new AgentUpRetrieve();
    public readonly AgentPoweredUp PoweredUpState = new AgentPoweredUp();

    private void Awake()
    {
        //rbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        safePos = new Vector3(2, 0, 2);
        fightPos = new Vector3(-2, 0, -2);
        patrolPos = new Vector3(2, 0, -2);
    }

    private void Start()
    {
        TransitionToState(RetrieveState);
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the update method of the current state and applies it to this
        currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Gets the OnCollisionEnter method of the current state and applies it to this
        currentState.OnCollisionEnter(this);
    }

    public void TransitionToState(AgentBaseState state)
    {
        //Sets the state to the one passed through as "state" and has this enter that state
        currentState = state;
        currentState.EnterState(this);
    }


}
