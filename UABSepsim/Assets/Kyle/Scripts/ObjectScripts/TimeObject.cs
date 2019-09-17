using UnityEngine;

[CreateAssetMenu(fileName = "NewTime", menuName = "TimeObject")]
public class TimeObject : ScriptableObject
{
    public float Second, Minute, Hour;
    public bool TimeShouldPass;
}
