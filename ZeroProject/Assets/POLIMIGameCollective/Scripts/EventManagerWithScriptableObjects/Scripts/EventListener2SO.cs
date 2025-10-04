using System;
using UnityEngine;
using POLIMIGameCollective;

public class EventListener2SO : MonoBehaviour
{

	[SerializeField] private VoidEventChannelSO spawnEvent;
	
	void OnEnable() 
	{
		spawnEvent.OnEventRaised += Spawn;
	}
	
	void OnDisable() 
	{
		spawnEvent.OnEventRaised -= Spawn;
	}

	void Spawn () 
	{
		Debug.Log("SPAWN EVENT");
	}
}
