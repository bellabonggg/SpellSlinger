using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditCharacter : MonoBehaviour {

    //Reference to input field for player name.
    [SerializeField]
    protected InputField m_PlayerNameInput;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveButton()
    {
        /*
        PlayerDataManager dataManager = PlayerDataManager.s_Instance;
        if (dataManager != null)
        {
            dataManager.playerName = m_PlayerNameInput.text;
            dataManager.selectedTank = m_CurrentIndex;
            dataManager.selectedDecoration = m_CurrentDecoration;
            dataManager.SetSelectedMaterialForDecoration(m_CurrentDecoration, m_CurrentDecorationMaterial);
        }
        MainMenuUI.s_Instance.ShowDefaultPanel();
        */
    }
}
