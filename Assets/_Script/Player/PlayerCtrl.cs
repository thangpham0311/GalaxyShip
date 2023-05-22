using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    protected static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    private void Awake()
    {
        PlayerCtrl.instance = this;
    }

}
