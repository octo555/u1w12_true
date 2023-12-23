using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour
{
    [SerializeField] GameObject[] subMenus;

    public void ShowSubMenu(int index)
    {
        foreach (var menu in subMenus) { menu.SetActive(false); }
        subMenus[index].SetActive(true);
    }
}
