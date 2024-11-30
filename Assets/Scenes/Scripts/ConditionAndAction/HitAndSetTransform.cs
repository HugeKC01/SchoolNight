using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndSetTransform : MonoBehaviour
{
	[Header("Condition")]
	public CheckType checkType;
	[Tooltip("Object name to check")] public string objectName;
	[Header("Action (Choose one)")]
	[Tooltip("Set target")] public Transform target;
    [Tooltip("Set transform on self instead")] public bool onSelf;
    [Header("Desination")]
	public Vector3 position = Vector3.zero;
	public Vector3 rotation = Vector3.zero;
	public Vector3 scale = Vector3.one;
    public Space space;

    Collider col;
	public enum CheckType
	{
		Collision,
		Trigger
	}
	public enum Space
	{
		Local,
		World
	}

    void OnValidate()
    {
        if(onSelf)
        {
            target = null;
        }
    }

    void OnCollisionEnter(Collision col)
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
                if (onSelf)
                {
                    target = col.gameObject.transform;
                }
                if (space == Space.Local)
				{
					target.localPosition = position;
					target.localEulerAngles = rotation;
					target.localScale = scale;
				}
				else
				{
					target.position = position;
					target.eulerAngles = rotation;
					target.localScale = Vector3.one;
					target.localScale = new Vector3 (scale.x/target.lossyScale.x, scale.y/target.lossyScale.y, scale.z/target.lossyScale.z);
				}
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

		if (checkType == CheckType.Trigger)
		{
			if(col.gameObject.name == objectName)
			{
                if (onSelf)
                {
                    target = col.gameObject.transform;
                }
                if (space == Space.Local)
				{
					target.localPosition = position;
					target.localEulerAngles = rotation;
					target.localScale = scale;
				}
				else
				{
					target.position = position;
					target.eulerAngles = rotation;
					target.localScale = Vector3.one;
					target.localScale = new Vector3 (scale.x/target.lossyScale.x, scale.y/target.lossyScale.y, scale.z/target.lossyScale.z);
				}
			}
		}
	}
}
