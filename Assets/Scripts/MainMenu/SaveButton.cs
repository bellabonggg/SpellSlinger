using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour {

    public Button saveButton;
    public PlayerDataManager manager;
    private GameObject customiseSpellPanel;

	// Use this for initialization
	void Start () {
        saveButton = GetComponent<Button>();
        Debug.Log("AddingListener");
        saveButton.onClick.AddListener(CheckSpellCount);
        customiseSpellPanel = GameObject.Find("Skills Modal");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CheckSpellCount()
    {
        if (manager.spellList.Count < 4)
        {
            Debug.Log("Choose 4 Spells, you have " + manager.spellList.Count);
        }
        else
        {
            customiseSpellPanel.SetActive(false);
        }
    }

    
}
