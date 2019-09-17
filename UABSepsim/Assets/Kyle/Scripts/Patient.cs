using UnityEngine;

public class Patient : MonoBehaviour
{
    public PatientObject ThisPatient;
    public float GameTime; // should this be a clock object?

    void Start()
    {
        // create PatientObject
        // generate stats
        // load patient object into room object
    }

    void Update()
    {
        // change infection
        // change hunger
        // change thirst
        // change comfort
        // if patient is critical, call ICU event
    }
}
