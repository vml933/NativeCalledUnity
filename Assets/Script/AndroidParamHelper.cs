using UnityEngine;
using UnityEngine.UI;

public class AndroidParamHelper : MonoBehaviour
{

    public Text myLabel;

#if UNITY_ANDROID
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (AndroidJavaObject intent = activity.Call<AndroidJavaObject>("getIntent"))
                    {
                        bool hasExtra = intent.Call<bool>("hasExtra", "levelinfo");

                        if (hasExtra)
                        {
                            AndroidJavaObject extras = intent.Call<AndroidJavaObject>("getExtras");
                            string level = extras.Call<string>("getString", "levelinfo");
                            myLabel.text = level;
                        }
                    }
                }
            }
        }
    }
#endif
}
