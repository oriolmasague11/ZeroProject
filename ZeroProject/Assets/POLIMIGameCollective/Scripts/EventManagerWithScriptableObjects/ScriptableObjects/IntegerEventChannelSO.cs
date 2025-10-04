using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Integer Event Channel")]
public class IntegerEventChannelSO : ScriptableObject
{
	public UnityAction<int> OnEventRaised;

	public void RaiseEvent(int value)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(value);
		else
		{
			Debug.LogWarning("Void event has been raised but there is no UnityAction associated.");
		}
	}
	
#if UNITY_EDITOR
	[TextArea(10,30)]
	[SerializeField] private string description;
#endif
}