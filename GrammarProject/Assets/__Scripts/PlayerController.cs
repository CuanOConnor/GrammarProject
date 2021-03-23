using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Windows.Speech;
using System.IO;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;

	private GrammarRecognizer gr;
	private Rigidbody2D rb;

	public Text pause;
	public Text gameOver;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		pause.enabled = false;

		gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath,
												"Grammar.xml"),
									ConfidenceLevel.Low);
		Debug.Log("Grammar loaded!");
		gr.OnPhraseRecognized += GR_OnPhraseRecognized;
		gr.Start();
		if (gr.IsRunning) Debug.Log("Recogniser running");
	}

    private void Update()
    {
        if(GameObject.Find("EnemyBullet").GetComponent<EnemyBullet>().isHit == true)
        {
			Time.timeScale = 0;
			gameOver.enabled = true;
        }
    }

    private void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		StringBuilder message = new StringBuilder();
		Debug.Log("Recognised a phrase");
		// read the semantic meanings from the args passed in.
		SemanticMeaning[] meanings = args.semanticMeanings;

		foreach (SemanticMeaning meaning in meanings)
		{
			string keyString = meaning.key.Trim();
			string valueString = meaning.values[0].Trim();
			string spokenPhrase = valueString;

			switch (spokenPhrase)
			{
				case "moveL":
					rb.velocity = new Vector2(-2f, 0f);
					Debug.Log("move L called");
					break;
				case "moveR":
					rb.velocity = new Vector2(2f, 0f);
					Debug.Log("move R called");
					break;
				case "stop":
					rb.velocity = new Vector2(0f, 0f);
					break;
				case "fire":
					Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
					break;
				case "pause":
					Time.timeScale = 0;
					pause.enabled = true;
					break;
				case "resume":
					Time.timeScale = 1;
					pause.enabled = false;
					break;
				default:
					// DEFAULT
					break;
			}

			message.Append("Key: " + keyString + ", Value: " + valueString + " ");
		}
		// use a string builder to create the string and out put to the user
		Debug.Log(message);
	}

	private void OnApplicationQuit()
	{
		if (gr != null && gr.IsRunning)
		{
			gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
			gr.Stop();
		}
	}

}