using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Gesture : MonoBehaviour {
	
	GestureRecognizer recognizer;

    void Start()
    {
        //实例化手势识别的对象
        recognizer = new GestureRecognizer();
        //设置手势的类型
        //00001  tap
        //00010  hold
        //00100  double tap
        //01000
        //10000

        //00011
        //00111
        //01111
        //10001


        //bit mask 位标记
        recognizer.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.Hold | GestureSettings.DoubleTap);

        //注册事件的监听函数
        recognizer.Tapped += Recognizer_Tapped;
        recognizer.HoldStartedEvent += Recognizer_HoldStartedEvent;
        recognizer.HoldCanceled += Recognizer_HoldCanceled;
        recognizer.HoldCompleted += Recognizer_HoldCompleted;

        //开启手势识别
        recognizer.StartCapturingGestures();
    }

    private void Recognizer_HoldCompleted(HoldCompletedEventArgs obj)
    {

    }

    private void Recognizer_HoldCanceled(HoldCanceledEventArgs obj)
    {

    }

    private void Recognizer_HoldStartedEvent(InteractionSourceKind source, Ray headRay)
    {
        
    }

    private void Recognizer_Tapped(TappedEventArgs obj)
    {
        GameObject cube = GameObject.Find("Cube");
        cube.transform.localScale += Vector3.one * 0.1f;
    }

    void Update () {
		
	}


    void OnDisable()
    {
        recognizer.StopCapturingGestures();
    }
}
