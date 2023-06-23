using UnityEngine;
using TMPro;
using System.IO;
using SimpleJSON;
[System.Serializable]
public class JSONData
{
	public int id;
	public string name;
	public string description;
	public string location;
	public string createdBy;
	public string date;
}


public class JSONDataImporter : MonoBehaviour
{
	[SerializeField] private TMP_Text nameText;
	[SerializeField] private TMP_Text descText;

	private JSONArray jsonDataArray;
	private int idData;
	public TextAsset jsonFile;
	private void Start()
	{
		if (jsonFile != null)
		{
			string json = jsonFile.text;

			jsonDataArray = JSONNode.Parse(json).AsArray;
		}
		else
		{
			Debug.LogError("JSON file is not assigned to the jsonFile field.");
		}
	}

	public void ImportData(int id)
	{

		foreach (JSONNode data in jsonDataArray)
		{
			if (data["id"].AsInt == id)
			{
				nameText.text = data["name"];
				descText.text = data["description"];
				break;
			}
		}
	}
}
