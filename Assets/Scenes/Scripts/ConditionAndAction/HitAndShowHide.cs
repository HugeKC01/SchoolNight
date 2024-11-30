using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndShowHide : MonoBehaviour
{
	[Header("Condition")]
	public CheckType checkType;
	[Tooltip("Object name to check")] public string objectName;
	[Header("Action")]
	[Tooltip("Target to show/hide")] public GameObject target;
	public ShowHide action;
	public bool cancelOnExit;

	Collider col;
	public enum CheckType
	{
		Collision,
		Trigger
	}
	public enum ShowHide
	{
		Hide,
		Show
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
			Debug.LogWarning("target is missing from"+this.name);
			return;
		}

		if (checkType == CheckType.Collision)
		{
			if(col.gameObject.name == objectName)
			{
				target.SetActive(action == ShowHide.Show);
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
			Debug.LogWarning("target is missing from"+this.name);
			return;
		}

		if (checkType == CheckType.Trigger)
		{
			if(col.gameObject.name == objectName)
			{
				target.SetActive(action == ShowHide.Show);
			}
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(!cancelOnExit)return;
		if(string.IsNullOrEmpty(objectName))
		{
			Debug.LogWarning("objectName is missing from "+this.name);
			return;
		}
		if(!target)
		{
			Debug.LogWarning("target is missing from"+this.name);
			return;
		}

		if (checkType == CheckType.Collision)
		{
			if(col.gameObject.name == objectName)
			{
				target.SetActive(action != ShowHide.Show);
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(!cancelOnExit)return;
		if(string.IsNullOrEmpty(objectName))
		{
			Debug.LogWarning("objectName is missing from "+this.name);
			return;
		}
		if(!target)
		{
			Debug.LogWarning("target is missing from"+this.name);
			return;
		}

		if (checkType == CheckType.Trigger)
		{
			if(col.gameObject.name == objectName)
			{
				target.SetActive(action != ShowHide.Show);
			}
		}
	}
}
