using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class RunGame : MonoBehaviour
{
    public float timeLeft = 60f;
    public bool gamePlaying = true;
    [SerializeField] private Renderer plane;
    private Vector3 planeSize;
    private bool powerSpawned = false;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private TextMeshProUGUI timeLeftText;
    void Start()
    {
        planeSize = plane.bounds.size;
    }
    void Update()
    {
        timeLeftText.text = "" + ((int)timeLeft);
        if (timeLeft <= 0)
        {
            gamePlaying = false;
            AgentController_FSM[] players = GameObject.FindObjectsOfType<AgentController_FSM>();
            foreach (AgentController_FSM player in players)
            {
                player.enabled = false;
                player.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            }
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }

        if (timeLeft < 15f && !powerSpawned)
        {
            Instantiate(powerUp, new Vector3(Random.Range(0f, planeSize.x - 2), 1f, Random.Range(0f, planeSize.x - 2)), powerUp.transform.rotation);
            powerSpawned = true;
        }
    }
}
