using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
	[SerializeField]
	private GameObject[] placeablePrefab;

	private Dictionary<string, GameObject> spawnedPrefab;
	private ARTrackedImageManager trackedImageManager;

	private void Awake()
	{
		trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
		foreach(GameObject prefab in placeablePrefab)
		{
			GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
			newPrefab.name = prefab.name;
			spawnedPrefab.Add(prefab.name, newPrefab);
		}
	}

	private void OnEnable()
	{
		trackedImageManager.trackedImagesChanged += ImageChanged;
	}
	private void OnDisable()
	{
		trackedImageManager.trackedImagesChanged -= ImageChanged;
	}

	private void ImageChanged(ARTrackedImagesChangedEventArgs args)
	{
		foreach (ARTrackedImage trackedImage in args.added)
		{
			UpdateImage(trackedImage);
		}
		foreach (ARTrackedImage trackedImage in args.updated)
		{
			UpdateImage(trackedImage);
		}
		foreach (ARTrackedImage trackedImage in args.removed)
		{
			spawnedPrefab[trackedImage.name].SetActive(false);
		}
	}

	private void UpdateImage(ARTrackedImage trackedImage)
	{
		string name = trackedImage.referenceImage.name;
		Vector3 position = trackedImage.transform.position;

		GameObject prefab = spawnedPrefab[name];
		prefab.transform.position = position;	
		prefab.SetActive(true);
		foreach(GameObject go in spawnedPrefab.Values)
		{
			if (go.name != name) 
			{
				go.SetActive(false);
			}
		}
	}

}
