using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singelton : MonoBehaviour
{
    private static Singelton instance;
    public static Singelton Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Singelton>();
            return instance;
        }
    }

    public CanvasManager CanvasManager;
    public ActionManager ActionManager;
    public NormCalculater NormCalculater;
}
