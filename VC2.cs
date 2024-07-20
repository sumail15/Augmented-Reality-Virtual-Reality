using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;


public class VC2 : MonoBehaviour
{
	private KeywordRecognizer k;
    public RunJets1 runjet1;
	private Dictionary<string, Action> actions = new Dictionary<string, Action>();
	void Start()
	{
		actions.Add("ant", () => CheckAnswer("ant"));
		actions.Add("bear", () => CheckAnswer("bear"));
		actions.Add("cat", () => CheckAnswer("cat"));
		actions.Add("dog", () => CheckAnswer("dog"));
		actions.Add("elephant", () => CheckAnswer("elephant"));
		actions.Add("frog", () => CheckAnswer("frog"));
		actions.Add("grasshopper", () => CheckAnswer("grasshopper"));
		actions.Add("horse", () => CheckAnswer("horse"));
		actions.Add("ibex", () => CheckAnswer("ibex"));
		actions.Add("lion", () => CheckAnswer("lion"));
		actions.Add("snake", () => CheckAnswer("snake"));
		actions.Add("monkey", () => CheckAnswer("monkey"));
		actions.Add("zebra", () => CheckAnswer("zebra"));
		actions.Add("tiger", () => CheckAnswer("tiger"));
		runjet1 = GetComponent<RunJets1>();
		k = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Low);
		k.OnPhraseRecognized += rec;
		k.Start();
	}
	private void rec(PhraseRecognizedEventArgs speech)
	{
		Debug.Log(speech.text);
		if (actions.ContainsKey(speech.text))
		{
			actions[speech.text].Invoke();
		}
	}
	public void CheckAnswer(string answer)
	{
		if ( answer == "bear")
		{
			runjet1.inputText = "Right answer";
			runjet1.TextToSpeech();
		}
		else
		{
			runjet1.inputText = "Wrong answer";
			runjet1.TextToSpeech();
		}
		runjet1.inputText="which animal is this";
	}
    
}