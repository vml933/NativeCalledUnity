using UnityEngine;
using UnityEngine.UI;

public class IOSParamHelper : MonoBehaviour
{

    public Text myLabel;

#if UNITY_IOS
	public void OnReceiveSchemeURL(string url){
		Debug.Log("call from native:"+url);
		myLabel.text = url;
	}
#endif
}