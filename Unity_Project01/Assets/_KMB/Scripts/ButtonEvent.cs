using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneMgr.Instance.loadScene("GameScene");
    }

    public void OnMenuButtonClick()
    {

    }

    public void OnOptionButtonClick()
    {

    }
}
