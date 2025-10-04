using UnityEngine;
using System.Collections;
using POLIMIGameCollective;

public class EventTriggerSO : MonoBehaviour
{
	[SerializeField] private VoidEventChannelSO spawnEvent;
	[SerializeField] private VoidEventChannelSO explodeEvent;
	[SerializeField] private VoidEventChannelSO runawayEvent;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B))
		{
			Debug.Log("Spwan a bomb to trigger and explosion!");
			// EventManager.TriggerEvent("Explode");
			spawnEvent.RaiseEvent();
			explodeEvent.RaiseEvent();
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			// EventManager.TriggerEvent ("RunAway");			
			runawayEvent.RaiseEvent();
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			// EventManager.TriggerEvent("Spawn");
			spawnEvent.RaiseEvent();
		}
	}
}
