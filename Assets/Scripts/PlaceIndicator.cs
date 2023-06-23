using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceIndicator : MonoBehaviour
{
	[SerializeField]
	private ARRaycastManager rayCastManager;
	[SerializeField]
	private GameObject indicator;
	private List<ARRaycastHit> hits = new List<ARRaycastHit>();

	private void Start()
	{
		rayCastManager = FindObjectOfType<ARRaycastManager>();
		indicator = transform.GetChild(0).gameObject;
	}

	private void Update()
	{
		var ray = new Vector2(Screen.width / 2, Screen.height / 2);
		if (rayCastManager.Raycast(ray, hits, trackableTypes: TrackableType.Planes))
		{
			Pose hitPose = hits[0].pose;
			transform.position = hitPose.position;

		
			if (Vector3.Dot(hitPose.rotation * Vector3.up, Vector3.up) < 0.5f)
			{
				transform.rotation = Quaternion.Euler(0f, 90f, 0f);
			}
			else
			{

				transform.rotation = hitPose.rotation;
			}
		}
	}
}
