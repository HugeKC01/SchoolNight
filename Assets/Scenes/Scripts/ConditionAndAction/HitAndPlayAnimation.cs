using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndPlayAnimation : MonoBehaviour
{
	[Header("Condition")]
	public CheckType checkType;
	[Tooltip("Object name to check")] public string objectName;
	[Header("Action")]
	[Tooltip("Target to play Animation")] public Animation target;
	public string enterAnimName;
	public string exitAnimName;
	Collider col;
	public enum CheckType
	{
		Collision,
		Trigger
	}

	void OnCollisionEnter(Collision col)
	{
		if(string.IsNullOrEmpty(objectName))
		{
			Debug.LogWarning("objectName is missing from "+this.name);
			return;
		}
		if(!target)
		{
			Debug.LogWarning("target is missing from "+this.name);
			return;
		}
		if(string.IsNullOrEmpty(enterAnimName))
		{
			return;
		}

		if (checkType == CheckType.Collision)
		{
			if(col.gameObject.name == objectName)
			{
				target.Play(enterAnimName);
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(string.IsNullOrEmpty(objectName))
		{
			Debug.LogWarning("objectName is missing from "+this.name);
			return;
		}
		if(!target)
		{
			Debug.LogWarning("target is missing from "+this.name);
			return;
		}
		if(string.IsNullOrEmpty(enterAnimName))
		{
			return;
		}

		if (checkType == CheckType.Trigger)
		{
			if(col.gameObject.name == objectName)
			{
				target.Play(enterAnimName);
			}
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(string.IsNullOrEmpty(objectName))
		{
			Debug.LogWarning("objectName is missing from "+this.name);
			return;
		}
		if(!target)
		{
			Debug.LogWarning("target is missing from "+this.name);
			return;
		}
		if(string.IsNullOrEmpty(exitAnimName))
		{
			return;
		}

		if (checkType == CheckType.Collision)
		{
			if(col.gameObject.name == objectName)
			{
				target.Play(exitAnimName);
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(string.IsNullOrEmpty(objectName))
		{
			Debug.LogWarning("objectName is missing from "+this.name);
			return;
		}
		if(!target)
		{
			Debug.LogWarning("target is missing from "+this.name);
			return;
		}
		if(string.IsNullOrEmpty(exitAnimName))
		{
			return;
		}

		if (checkType == CheckType.Trigger)
		{
			if(col.gameObject.name == objectName)
			{
				target.Play(exitAnimName);
			}
		}
	}
}
