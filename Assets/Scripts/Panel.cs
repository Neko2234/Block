using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject Popup;
    [SerializeField] private AudioClip mainSE;
    [SerializeField] private AudioClip subSE;

    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
    }

    public void MainView()
    {
        GManager.instance.PlaySE(mainSE);
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        GManager.instance.openingPanel = false;
    }

    public void SubView()
    {
        GManager.instance.PlaySE(subSE);
        mainPanel.SetActive(false);
        subPanel.SetActive(true);
        GManager.instance.openingPanel = true;
    }

    //Appear関数が呼び出されるとポップアップが表示される
    public void Appear()
    {

        Popup.SetActive(true);
        GManager.instance.PlaySE(mainSE);
    }



    //Delete関数が呼び出されるとポップアップが非表示になる
    public void Delete()
    {

        Popup.SetActive(false);
        //GManager.instance.PlaySE(mainSE);
    }

}
