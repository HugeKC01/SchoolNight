using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndLoadScene : MonoBehaviour
{
	[Header("Condition")]
	public CheckType checkType;
	[Tooltip("Object name to check")] public string objectName;
	[Header("Action")]
	[Tooltip("Scene name")] public string loadSceneName;

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
		if(string.IsNullOrEmpty(loadSceneName))
		{
			Debug.LogWarning("loadSceneName is missing from"+this.name);
			return;
		}

		if (checkType == CheckType.Collision)
		{
			if(col.gameObject.name == objectName)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneName);
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
		if(string.IsNullOrEmpty(loadSceneName))
		{
			Debug.LogWarning("loadSceneName is missing from"+this.name);
			return;
		}

		if (checkType == CheckType.Trigger)
		{
			if(col.gameObject.name == objectName)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneName);
			}
		}
	}
}
