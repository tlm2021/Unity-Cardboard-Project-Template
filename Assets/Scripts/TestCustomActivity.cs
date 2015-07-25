using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCustomActivity : MonoBehaviour {

	private AndroidJavaObject mActivity;
	private float sinceRequest = 0f;
	private Text mText;

	// Use this for initialization
	void Start () {
		AndroidJavaClass playerClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		mActivity = playerClass.GetStatic<AndroidJavaObject> ("currentActivity");
		mText = GameObject.Find ("FilePathText").GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {

		Debug.Log ("Calling myCustomMethod");
		mActivity.CallStatic ("myCustomMethod");

		updateRequestTimer ();

		if (sinceRequest > 10){
			Debug.Log ("Calling requestFile");
			mActivity.Call ("requestFile");
			resetRequestTimer();
		}
	}

	void updateRequestTimer(){
		sinceRequest = sinceRequest + Time.deltaTime;
	}

	void resetRequestTimer(){
		sinceRequest = 0;
	}

	void Java_updateText(string newText){
		updateText (newText);
	}

	void updateText(string newText){
		mText.text = newText;
	}
}