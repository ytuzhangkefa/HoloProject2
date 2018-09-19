using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.XR.WSA;
using UnityEngine.XR.WSA.Persistence;

public class AnchorGesture : MonoBehaviour {

    GestureRecognizer recognizer;
    //表示物体是否被锁定在世界中
    bool locked = false;

    //定义空间锚仓库
    WorldAnchorStore store;

    void Start()
    {
        //实例化手势识别的对象
        recognizer = new GestureRecognizer();

        recognizer.SetRecognizableGestures(GestureSettings.DoubleTap);

        //注册事件的监听函数
        recognizer.Tapped += Recognizer_Tapped;

        //开启手势识别
        recognizer.StartCapturingGestures();

        WorldAnchorStore.GetAsync((store) =>
        {
            this.store = store;

            WorldAnchor anchor = this.store.Load("cube", GameObject.Find("Cube"));
        });

    }
    private void Recognizer_Tapped(TappedEventArgs obj)
    {
        if (obj.tapCount == 2)
        {
            GameObject cube = GameObject.Find("Cube");
            if (!locked)
            {
                WorldAnchor anchor = cube.AddComponent<WorldAnchor>();
                if (this.store != null)
                {
                    this.store.Save("cube", anchor);
                }
                locked = true;
            }
            else
            {
                DestroyImmediate(cube.GetComponent<WorldAnchor>());
                if (this.store != null)
                {
                    this.store.Delete("cube");
                    this.store.Clear();
                }
                locked = false;
            }

        }
    }

    void Update()
    {

    }


    void OnDisable()
    {
        recognizer.StopCapturingGestures();
    }
}
