using UnityEngine;

public class Infector : MonoBehaviour
{
    public PatientObject MyPatient;
    public TimeObject InGameTime;
    public float TimeToICU = 28800;
    public float Infection;
    public bool isHealed;

    void Start()
    {
        Infection = 0;
    }
    
    void Update()
    {
        InfectionGrowth();
    }

    public void InfectionGrowth()
    {
        if (Infection >= 0)
        {
            if (!isHealed)
            {
                Infection = (100 * Mathf.Pow(10, InGameTime.SecondsPassed / TimeToICU) - 100) / 9;
            }
            else
            {
                Infection = (100 * Mathf.Pow(10, InGameTime.SecondsPassed / TimeToICU) + 100) / 9; // how do we make this go the other way?
            }            
        }
    }
}
