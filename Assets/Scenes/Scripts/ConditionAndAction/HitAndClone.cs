using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndClone : MonoBehaviour
{
	[Header("Condition")]
	public CheckType checkType;
	[Tooltip("Object name to check")] public string objectName;
	[Header("Action")]
	[Tooltip("Original Prefab to clone")]public Transform sourcePrefab;
	[Tooltip("Clone start position")]public Transform startPosition;
	[Tooltip("Clone parent")]public Transform cloneParent;
	[Header("Repeat Behaviour")]
	public bool useRepeating;
	public bool cancelWhenExit;
	[Tooltip("Time gap between each clone")]public float interval;

	Collider col;
	bool isIn;

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
		if(sourcePrefab == null)
		{
			Debug.LogWarning("sourcePrefab is missing from "+this.name);
			return;
		}

		if (checkType == CheckType.Collision)
		{
			if(col.gameObject.name == objectName)
			{
				isIn = true;
				StartCoroutine(CloneRepeatingCoroutine());
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
		if(sourcePrefab == null)
		{
			Debug.LogWarning("sourcePrefab is missing from "+this.name);
			return;
		}

		if(checkType == CheckType.Trigger)
		{
			if(col.gameObject.name == objectName)
			{
				isIn = true;
				StartCoroutine(CloneRepeatingCoroutine());
			}
		}
	}

	IEnumerator CloneRepeatingCoroutine()
	{
		if(useRepeating)
		{
			var wait = new WaitForSeconds(interval);
			while(!cancelWhenExit || isIn)
			{
				CloneFunction();
				yield return wait;
			}
		}
		else
		{
			CloneFunction();
		}
	}

	void CloneFunction()
	{
		Transform clone = Instantiate(sourcePrefab);
		if(cloneParent!=null)
		{
			clone.SetParent(cloneParent,false);
		}
		if(startPosition!=null)
		{
			clone.position = startPosition.position;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(string.IsNullOrEmpty(objectName))
		{
			Debug.LogWarning("objectName is missing from "+this.name);
			return;
		}

		if (checkType == CheckType.Collision)
		{
			if(col.gameObject.name == objectName)
			{
				isIn = false;
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

		if(checkType == CheckType.Trigger)
		{
			if(col.gameObject.name == objectName)
			{
				isIn = false;
			}
		}
	}
}
