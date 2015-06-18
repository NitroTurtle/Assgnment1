using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	static bool _isLoaded;
	int _score;
	public GameObject playerPrefab;
	static GameObject playerReference;
	public Canvas Screen_Title;
	public Canvas Screen_HUD;
	public Canvas pause;
	public Canvas QuitGame;
	public AudioClip puaseClip;
	public Canvas GameOver;
	
	// Use this for initialization
	void Start () {
		Screen_HUD.GetComponent<CanvasGroup>().alpha = 0;
		
		if (isLoaded) {
			DestroyImmediate (gameObject);
		} else {
			isLoaded = true;
			DontDestroyOnLoad (gameObject);
			playerReference = playerPrefab;
			pause.enabled = false;
			QuitGame.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (pause.enabled == false){
				pause.enabled = true;
				//SoundManager.instance.PlaySingle(puaseClip);
			}
			else{
				pause.enabled = false;
				
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Application.LoadLevel(1);
			
			if(Application.loadedLevelName == "title"){
				Application.LoadLevel("stageSelect"); 
				pause.enabled =false;
			}
			
			if(Application.loadedLevelName == "stageSelect")
			{
				Screen_HUD.GetComponent<CanvasGroup>().alpha = 0;
				Screen_Title.enabled = true;
				Application.LoadLevel("title"); 
				pause.enabled =false;
			}
			
		}
		if (pause.enabled == true)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
		
		//if (lives == 0) {
		//	if (GameOver.enabled == true)
		//		GameOver.enabled = false;
		//	else {
		//		GameOver.enabled = false;
		//	}
		//}
	}
	
	public void StartGame()
	{
		Application.LoadLevel("stageSelect");
		Screen_Title.enabled = false;
		//Screen_HUD.enabled = true;
		Screen_HUD.GetComponent<CanvasGroup>().alpha = 1;
	}
	public void StartLevel()
	{
		Application.LoadLevel("topman_level");
		//Screen_Title.enabled = false;
		Screen_HUD.enabled = true;
		Screen_HUD.GetComponent<CanvasGroup>().alpha = 1;
	}
	public void EndGame()
	{
		Debug.Log ("quit");
		Application.Quit ();
		
	}
	
	/*public static void SpawnPlayer()
	{
		string spawnPoint = "SpawnPoint" + Application.loadedLevel;
		
		Transform spawnPointTransform = GameObject.Find(spawnPoint).GetComponent<Transform>();
		
		Instantiate(playerReference,spawnPointTransform.position, Quaternion.identity);
	}*/
	
	public static bool isLoaded
	{
		get
		{
			return _isLoaded;
		}
		
		set
		{
			_isLoaded = value;
		}
	}
	
}