using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceManager : MonoBehaviour
{
	[SerializeField] private PlaceIndicator placeIndicator;
	[SerializeField] private Animator panelAnimator;

	[SerializeField] private GameObject[] gameObjects = new GameObject[4];
	[SerializeField] private int selectedObjectIndex;
	[SerializeField] private GameObject placeModel;
	[SerializeField] private GameObject informationIcon;
	[SerializeField] private GameObject arPlanePrefab;
	[SerializeField] private JSONDataImporter dataImport;


	private bool hasSelectedObject;

	private void Update()
	{
		placeModel.SetActive(hasSelectedObject);
		informationIcon.SetActive(hasSelectedObject);

	}
	public void SelectedObject(int index)
	{
		selectedObjectIndex = index;
		hasSelectedObject = true;
		dataImport.ImportData(index);
	}
	public void ClickToPlace()
	{
		Instantiate(gameObjects[selectedObjectIndex], placeIndicator.transform.position, placeIndicator.transform.rotation);
		hasSelectedObject = false;
	}

	public void PanelPopUp()
	{
		panelAnimator.SetBool("ShowInfo", true);
	}
	public void PanelPopOut()
	{
		panelAnimator.SetBool("ShowInfo", false);

	}
	public void Back()
	{
		SceneManager.LoadScene(0);
	}
}
