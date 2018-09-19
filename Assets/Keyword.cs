using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class Keyword : MonoBehaviour {
    KeywordRecognizer recognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	void Start () {

        
        keywords.Add("activate", ()=> {
            TextMesh text = GameObject.Find("Text").GetComponent<TextMesh>();
            text.text = "Fine, thanks!";
        });

        string B = "good morning";
        keywords.Add(B, () =>
        {
            TextMesh text = GameObject.Find("Text").GetComponent<TextMesh>();
            text.text = "去你的";
        });


        recognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        recognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        recognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {

        TextMesh text = FindObjectOfType<TextMesh>();
        text.text = args.text;


        System.Action keywordAction;
        
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    void Update () {
		
	}


    
}
