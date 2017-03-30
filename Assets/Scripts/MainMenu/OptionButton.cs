using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour {

    bool selected = false;
    int index;
    public PlayerDataManager manager;
    Image buttonImage;
    Text spellName;

    private void Start()
    {
        //manager = GameObject.Find("Player Data").GetComponent<PlayerDataManager>();
        buttonImage = GetComponent<Image>();
        spellName = GetComponentInChildren<Text>();
        if (buttonImage != null && spellName!=null)
        {
            Debug.Log("we got the image and text");
        }
    }

    public void changeSelection()
    {
        Debug.Log(spellName.text + manager.spellList.Count);

        if (selected == false && manager.spellList.Count < 4)
        {
            buttonImage.color = Color.red;
            manager.spellList.Add(spellName.text);
            selected = true;
        }
        else if(selected == true)
        {
            buttonImage.color = Color.white;
            manager.spellList.Remove(spellName.text);
            selected = false;
        }
        else
        {
            Debug.Log("Max Spells number reached");
        }
    }
}
