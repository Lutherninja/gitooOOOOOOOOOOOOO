using UnityEngine;

public class Infector : MonoBehaviour
{
    public PatientObject MyPatient;
    public TimeObject InGameTime;
    public float TimeToICU = 28800;
    public float SecondsAtCure;
    public float Infection;
    public float HealSubtract;
    public float ModifiedCureSecond;
    public bool isHealed;
    public bool beenHealed;

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
                if(!beenHealed)
                {
                    SecondsAtCure = InGameTime.SecondsPassed;
                    beenHealed = true;
                }

                HealSubtract = (InGameTime.SecondsPassed - SecondsAtCure) * 2;
                ModifiedCureSecond = InGameTime.SecondsPassed - HealSubtract;


                Infection = (100 * Mathf.Pow(10, ModifiedCureSecond / TimeToICU) - 100) / 9;
            }            
        }
    }
}
