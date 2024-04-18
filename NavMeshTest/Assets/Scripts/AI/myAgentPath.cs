using UnityEngine;
using UnityEngine.AI;

public class myAgentPath : MonoBehaviour
{
    public static Vector3[] path = new Vector3[0];

    private LineRenderer lr;
    NavMeshAgent myAgent;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        path = myAgent.path.corners;
        if (path != null && path.Length > 1)
        {
            lr.positionCount = path.Length;
            for (int i = 0; i < path.Length; i++)
            {
                lr.SetPosition(i, path[i]);
            }
        }
    }
}

