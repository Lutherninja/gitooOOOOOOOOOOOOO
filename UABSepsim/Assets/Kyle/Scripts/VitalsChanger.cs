using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalsChanger : MonoBehaviour
{
    public PatientObject myPatientObject;
    public float TempDefault = 98.6f;
    public float TempMax = 111f;
    private float TempDifference;


    // Start is called before the first frame update
    void Start()
    {
        TempDifference = TempMax - TempDefault;
    }


    // Update is called once per frame
    void Update()
    {
        myPatientObject.Temperature = TempDefault + (myPatientObject.InfectionCurrent * (TempDifference / 100));
    }
}
