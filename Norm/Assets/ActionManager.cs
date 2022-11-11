using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour
{
    public void CheckedPToggle(Toggle PCheckBox)
    {
        Singelton.Instance.CanvasManager.CheckP(PCheckBox.isOn);
    }

    public void MakeArray()
    {
        Singelton.Instance.CanvasManager.MakeArray();
    }
    public void Calculate()
    {
        Singelton.Instance.CanvasManager.Calculate();
    }
}
