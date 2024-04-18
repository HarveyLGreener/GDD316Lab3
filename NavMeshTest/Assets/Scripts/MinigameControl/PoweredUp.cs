using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoweredUp : MonoBehaviour
{
    public IndividualScoreTracker tracker;
    private void Start()
    {
        tracker = this.gameObject.GetComponent<IndividualScoreTracker>();
        this.gameObject.GetComponent<NavMeshAgent>().speed*=1.5f;
        this.gameObject.transform.localScale *= 1.5f;
        StartCoroutine(TimeToDestroy());
        this.gameObject.GetComponent<Collider>().isTrigger = true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<IndividualScoreTracker>() != null && collision.gameObject.GetComponent<IndividualScoreTracker>().canBeStolenFrom)
        {
            Debug.Log("Stealing coins");
            int points = collision.gameObject.GetComponent<IndividualScoreTracker>().score/2;
            collision.gameObject.GetComponent<IndividualScoreTracker>().GainPoints(points * -1);
            tracker.GainPoints(points);
            collision.gameObject.GetComponent<IndividualScoreTracker>().canBeStolenFrom = false;
        }
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(10f);
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        this.gameObject.GetComponent<NavMeshAgent>().speed /= 1.5f;
        this.gameObject.transform.localScale /= 1.5f;
        Destroy(this);
    }
}
