using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Toggle NormPCheckBox;
    [SerializeField] private Toggle NormInfinityCheckBox;
    [SerializeField] private InputField PValueField;
    [SerializeField] private InputField NumberOfDimensionsField;
    [SerializeField] private GameObject XsFieldPrefab;
    [SerializeField] private Transform XsFieldPrefabParent;

    public void CheckP(bool IsPChecked)
    {
        PValueField.gameObject.SetActive(IsPChecked);
    }

    public void MakeArray()
    {
        GameObject NewPrefab;
        int length = System.Convert.ToInt16(NumberOfDimensionsField.text);
        
        for (int i = 0; i < length; i++)
        {
            NewPrefab = Instantiate(XsFieldPrefab, XsFieldPrefabParent);
            NewPrefab.transform.GetChild(0).GetComponent<Text>().text = "X" + i;
        }
    }

    public void Calculate()
    {
        int P = System.Convert.ToInt16(PValueField.text);
        // warning of p
        InputField[] XText = XsFieldPrefabParent.GetComponentsInChildren<InputField>();
        int[] X = new int[XText.Length];
        for (int i = 0; i < XText.Length; i++)
        {
            X[i] = System.Convert.ToInt16(XText[i].text);
            Debug.Log(X[i]);
        }
    }
}
