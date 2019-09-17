using UnityEngine;
using UnityEngine.UI;

public class InGameTimePasser : MonoBehaviour
{
    public TimeObject MyTimeObject;
    public Transform SecondHand, MinuteHand, HourHand;
    public Text SecondText, MinuteText, HourText;
    public int StartHour;
    private float totalGameSeconds;
    public float secondsPerSecond = 20;
    public bool IsAnalog;

    private void Start()
    {
        float StartMinute = StartHour * 60;
        totalGameSeconds = StartMinute * 60;

        totalGameSeconds += secondsPerSecond * Time.deltaTime;
        
        if (IsAnalog)
        {
            SecondHand = gameObject.transform.GetChild(0);
            MinuteHand = gameObject.transform.GetChild(1);
            HourHand = gameObject.transform.GetChild(2);
        }
        else
        {
            Transform canvas = gameObject.transform.GetChild(0);
            Transform canvasChild0 = canvas.transform.GetChild(0);
            Transform canvasChild1 = canvas.transform.GetChild(1);
            Transform canvasChild2 = canvas.transform.GetChild(2);
            SecondText = canvasChild0.gameObject.GetComponent<Text>();
            MinuteText = canvasChild1.gameObject.GetComponent<Text>();
            HourText = canvasChild2.gameObject.GetComponent<Text>();
        }
        
    }

    void Update()
    {
        if (MyTimeObject.TimeShouldPass)
        {
            if(IsAnalog)
            {
                totalGameSeconds += secondsPerSecond * Time.deltaTime;

                MyTimeObject.Second = totalGameSeconds;
                MyTimeObject.Minute = totalGameSeconds / 60;
                MyTimeObject.Hour = MyTimeObject.Minute / 60;

                float secondAngle = -360 * (MyTimeObject.Second / 60);
                float minuteAngle = -360 * (MyTimeObject.Minute / 60);
                float hourAngle = -360 * (MyTimeObject.Hour / 12);

                SecondHand.localRotation = Quaternion.Euler(0, 0, secondAngle);
                MinuteHand.localRotation = Quaternion.Euler(0, 0, minuteAngle);
                HourHand.localRotation = Quaternion.Euler(0, 0, hourAngle);
            }
            else
            {
                totalGameSeconds += secondsPerSecond * Time.deltaTime;

                MyTimeObject.Second = totalGameSeconds;
                MyTimeObject.Minute = totalGameSeconds / 60;
                MyTimeObject.Hour = MyTimeObject.Minute / 60;

                SecondText.text = (((int)MyTimeObject.Second) % 60).ToString();
                MinuteText.text = (((int)MyTimeObject.Minute) % 60).ToString();
                HourText.text = (((int)MyTimeObject.Hour) % 12).ToString();
            }
        }
    }
}