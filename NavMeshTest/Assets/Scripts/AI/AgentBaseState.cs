using UnityEngine;

public abstract class AgentBaseState
{
    public abstract void EnterState(AgentController_FSM theAgent);

    public abstract void Update(AgentController_FSM theAgent);

    public abstract void OnCollisionEnter(AgentController_FSM theAgent);
}
