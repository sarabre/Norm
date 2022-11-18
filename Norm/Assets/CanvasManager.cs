using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Toggle NormPCheckBox;
    [SerializeField] private Toggle NormInfinityCheckBox;
    [SerializeField] private InputField PValueField;
    [SerializeField] private InputField NumberOfDimensionsField;
    [SerializeField] private GameObject XsFieldPrefab;
    [SerializeField] private Transform XsFieldPrefabParent;
    [SerializeField] private Text WarningText;
    [SerializeField] private Image WarningImage;
    [SerializeField] private GameObject Warning;
    [SerializeField] private Text ResultText;
    private List<GameObject> IndexesPrefab = new List<GameObject>();

    public void CheckP(bool IsPChecked)
    {
        PValueField.gameObject.SetActive(IsPChecked);
    }

    public void MakeArray()
    {
        int length = System.Convert.ToInt16(NumberOfDimensionsField.text);
        
        if(length > IndexPool.SharedInstance.amountToPool)
        {
            ShowAlert($"Currently it's not possible to initialaze more that {IndexPool.SharedInstance.amountToPool}. Check value of 'amountToPool'");
            return;
        }

        for (int i = 0; i < length; i++)
        {
            GameObject NewIndex = IndexPool.SharedInstance.GetPooledObject();

            if (NewIndex != null)
            {
                NewIndex.transform.GetChild(0).GetComponent<Text>().text = "X" + i;
                NewIndex.SetActive(true);
                IndexesPrefab.Add(NewIndex);
            }
        }
    }

    public void ResetAmounts()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Calculate()
    {
        int P = -2;
        if (NormPCheckBox.isOn)
        {
            #region Check P
            try
            {
                P = System.Convert.ToInt16(PValueField.text);
            }
            catch
            {
                StartCoroutine(ShowAlert("Enter P"));
                return;
            }
            if (P < 0)
            {
                StartCoroutine(ShowAlert("P should be nonnegetive number"));
                return;
            }
            #endregion
        }

        InputField[] XText = XsFieldPrefabParent.GetComponentsInChildren<InputField>();
        float[] X = new float[XText.Length];
        for (int i = 0; i < XText.Length; i++)
        {
            try
            {
                Debug.Log($"Log >> Xi = {float.Parse(XText[i].text)}");
                X[i] = float.Parse(XText[i].text);
            }
            catch
            {
                X[i] = 0;
            }
            Debug.Log(X[i]);
        }

        float result = 0;

        Singelton.Instance.NormCalculater.CalculateNorm(P, X,out result);
        ResultText.text = result.ToString();
    }

    IEnumerator ShowAlert(string WarningContent)
    {
        WarningText.text = WarningContent;
        Warning.SetActive(true);
        WarningImage.DOFade(0, 0);
        WarningImage.DOFade(0.6f, 1);
        yield return new WaitForSeconds(2f);
        WarningImage.DOFade(0, 1).OnComplete(() => Warning.SetActive(false));
    }
}
