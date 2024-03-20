using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;
    public TMP_Dropdown dropdown;
    public Slider slider;

    public Villager archer;
    public Villager thief;
    public Villager merchant;


    public void DropDownHasChanged(int index)
    {

        Debug.Log(index);

        if (index == 0)
        {
            SetSelectedVillager(archer);
            Debug.Log("archer");
        }
        if (index == 1)
        {
            SetSelectedVillager(thief);
            Debug.Log("thief");
        }
        if (index == 2)
        {
            SetSelectedVillager(merchant);
            Debug.Log("merchant");
        }

    }

    public void SliderInput(Single value)
    {
        SelectedVillager.transform.localScale = new Vector3(value, value, 0);
    }



    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
    }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        //if(SelectedVillager != null)
        //{
        //    currentSelection.text = SelectedVillager.GetType().ToString();
        //}
    }


}
