using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Dictation : MonoBehaviour {

    DictationRecognizer dictation;

    void Start () {
        dictation = new DictationRecognizer();
        dictation.DictationComplete += Dictation_DictationComplete;
        dictation.DictationError += Dictation_DictationError;
        dictation.DictationHypothesis += Dictation_DictationHypothesis;
        dictation.DictationResult += Dictation_DictationResult;

        //关闭短语识别系统(关键字识别)
        PhraseRecognitionSystem.Shutdown();
        dictation.Start();
	}

    private void Dictation_DictationResult(string text, ConfidenceLevel confidence)
    {
        GameObject dictation = GameObject.Find("Text (1)");
        dictation.GetComponent<TextMesh>().text = text;
    }

    private void Dictation_DictationHypothesis(string text)
    {

    }

    private void Dictation_DictationError(string error, int hresult)
    {

    }

    private void Dictation_DictationComplete(DictationCompletionCause cause)
    {

    }

    void Update () {
		
	}


    private void OnDestroy()
    {
        dictation.DictationComplete -= Dictation_DictationComplete;
        dictation.DictationError -= Dictation_DictationError;
        dictation.DictationHypothesis -= Dictation_DictationHypothesis;
        dictation.DictationResult -= Dictation_DictationResult;
        dictation.Dispose();
        dictation.Stop();
        //重启短语识别
        PhraseRecognitionSystem.Restart();
    }
}
