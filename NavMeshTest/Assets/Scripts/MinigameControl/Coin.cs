using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;
    private float transformAmount = 0f;
    private float transformChange = 0.005f;

    private void Update()
    {
        this.transform.eulerAngles += new Vector3(0f, 0f, 3f);
        this.transform.position += new Vector3(0f, transformAmount, 0f);
        if (Mathf.Abs(transformAmount) > 0.05f)
        {
            transformChange *= -1f;
        }
        transformAmount += transformChange;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IndividualScoreTracker>() == null)
        {
            Destroy(this.gameObject);
        }
        other.gameObject.GetComponent<IndividualScoreTracker>().GainPoints(points);
        other.gameObject.GetComponent<AgentController_FSM>().RetrieveState.ResetCloseCoin();
        Destroy(this.gameObject);
    }
}
