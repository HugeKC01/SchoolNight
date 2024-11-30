using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HitAndDestroy : MonoBehaviour
{
	[Header("Condition")]
	public CheckType checkType;
	[Tooltip("Object name to check")] public string objectName;
	[Header("Action (Choose one)")]
	[Tooltip("Destroy objectName instead")] public bool destroySelf;
	[Tooltip("Object to destroy")] public GameObject target;
	Collider col;

	public enum CheckType
	{
		Collision,
		Trigger
	}

	void OnValidate()
	{
		if(destroySelf)
			target = null;
	}

	void OnCollisionEnter(Collision col)
	{
		if(string.IsNullOrEmpty(objectName))
		{
			Debug.LogWarning("objectName is missing from "+this.name);
			return;
		}
		if(!destroySelf && target==null)
		{
			Debug.LogWarning("target is missing from "+this.name);
			return;
		}

		if (checkType == CheckType.Collision)
		{
			if(col.gameObject.name == objectName)
			{
				if(destroySelf)
					Destroy(col.gameObject);
				else
					Destroy(target);
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
		if(!destroySelf &&target==null)
		{
			Debug.LogWarning("target is missing from "+this.name);
			return;
		}

		if(checkType == CheckType.Trigger)
		{
			if(col.gameObject.name == objectName)
			{
				if(destroySelf)
					Destroy(col.gameObject);
				else
					Destroy(target);
			}
		}
	}
}
