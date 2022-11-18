using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormCalculater : MonoBehaviour
{
    public void CalculateNorm(int p,float[] Xs,out float Result)
    {
        Norm norm = new Norm(Xs);
        if(p == -2)
        {
            Result = norm.CalculateInfinityNorm();
            return;
        }
        
        Result = norm.CalculatePNorm(p);
        
    }
}

[System.Serializable]
public class Norm
{
    [SerializeField] public List<float> X = new List<float>();

    public Norm(float[] Xs)
    {
        X.Clear();
        foreach (var x in Xs)
        {
            Debug.Log($"Add >> x = {x}");
            X.Add(x);
        }
    }

    public float CalculateInfinityNorm()
    {
        float MaxNumber = 0;
        foreach (var x in X)
        {
            Debug.Log($"infinity >> x = {x}");
            if (Mathf.Abs(x) > MaxNumber)
                MaxNumber = Mathf.Abs(x);
        }

        return MaxNumber;
    }

    public float CalculatePNorm(int p)
    {
        float Sumindeces = 0;

        foreach (var x in X)
        {
            Debug.Log($"p = {p} >> x = {x} Sumindeces = {Sumindeces}");
            Sumindeces += Mathf.Pow(Mathf.Abs(x), p);
        }
        float Lp = Mathf.Pow(Sumindeces, 1.0f / p);
        Debug.Log($"Lp = {Lp} Sumindeces = {Sumindeces}");
        return Lp;
    }
}