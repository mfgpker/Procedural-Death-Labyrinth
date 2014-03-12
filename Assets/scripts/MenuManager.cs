using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public MenuManager instance;
	private string CurMenu = "";
	public GUIStyle skin;
	public GUISkin list;
	private string[] items = new string[]{"720x480", "800x600","1280x800", "1280x1024","1920x1080"};
    private Rect Box;
    private string slectedResolutions;
    private bool iswindowed;
    private bool editing = false;
    private string version = "0.1.6";
	// Use this for initialization
	void Start () {
		instance = this;
		CurMenu = "Main";
		iswindowed = GetBool("iswindow");
		
		if(string.IsNullOrEmpty(PlayerPrefs.GetString("Resolution"))){
			
			slectedResolutions = "1280x800";
			Screen.SetResolution(1280, 800, iswindowed);
			PlayerPrefs.SetString("Resolution", slectedResolutions);
		} else {
			
			slectedResolutions = PlayerPrefs.GetString("Resolution");
			changeResolutions();
		}
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ToMenu(string menu){
		CurMenu = menu;
	}
	
	void OnGUI(){
		GUI.skin = list;
		if(CurMenu == "Main")
			Main();
		if(CurMenu == "Play")
			Play();
		if(CurMenu == "Options")
			Options();
		if(CurMenu == "Credit")
			Credit();
        GUI.Label(new Rect(Screen.width - 190, Screen.height - 40, 250, 50), "version " + version);

	}

	public int Offset = 69;

	private void Main(){
        //GUI.Label(new Rect(Screen.width - 190, Screen.height - 40, 250, 50), "version " + version);
		if(GUI.Button(new Rect(Screen.width/2 - 125, Screen.height/2 - 120 - Offset, 250, 70), "Play", skin)){
			//Application.loadedLevelName("level1");
			ToMenu("Play");
		}
        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 0 - Offset, 250, 70), "Options", skin)) {
			ToMenu("Options");
		}
        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 + 120 - Offset, 250, 70), "Credit", skin)) {
			ToMenu("Credit");
		}
        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 + 240 - Offset, 250, 70), "Exit", skin)) {
			Application.Quit();
		}


	}

	private void Play(){
		Application.LoadLevel("level1");

		if(GUI.Button(new Rect(Screen.width/2 - 80, Screen.height + 10 - Offset, 250, 70), "Back", skin)){
			//Application.loadedLevelName("level1");
			ToMenu("Main");
		}
	}

	private void Options(){
		
		Box = new Rect(225, 110, 175, 50);
		/*
        GUI.Label(new Rect(50, 120, 180, 50), "Resolutions:");
		if (GUI.Button(Box, slectedResolutions)){
            editing = true;
        }
        GUI.Label(new Rect(405, 110, 260, 180), "This game currently works best with a 1280x800 resolution.");
        if (editing){
            for (int x = 0; x < items.Length; x++){
                if (GUI.Button(new Rect(Box.x, (Box.height * x) + Box.y + Box.height, Box.width, Box.height), items[x])){
                    slectedResolutions = items[x];
                    editing = false;

                }
            }
        }
        */
        GUI.Label(new Rect(50, 300, 180, 50), "Window:");
        iswindowed = GUI.Toggle(new Rect(150, 290, 50, 50), iswindowed, "");

		if(GUI.Button(new Rect(50, Screen.height + 10- Offset, 250, 70), "Cancel", skin)){
			
			ToMenu("Main");
		} 
		if(GUI.Button(new Rect(Screen.width/2 +80, Screen.height + 10- Offset, 250, 70), "Apply", skin)){
			changeResolutions();
			SetBool("iswindow", iswindowed);
			ToMenu("Main");
		}

   
	}

	private void changeResolutions(){
        if (!iswindowed){
            switch (slectedResolutions)
            {
                case "720x480":
                    Screen.SetResolution(720, 480, iswindowed);
                    break;
                case "800x600":
                    Screen.SetResolution(800, 680, iswindowed);
                    break;
                case "1280x800":
                    Screen.SetResolution(1280, 800, iswindowed);
                    break;
                case "1280x1024":
                    Screen.SetResolution(1280, 1024, iswindowed);
                    break;
                case "1920x1080":
                    Screen.SetResolution(1920, 1080, iswindowed);
                    break;
            }
        }
		PlayerPrefs.SetString("Resolution", slectedResolutions);
	}

	private void Credit(){

        GUI.Label(new Rect(Screen.width / 2 - 50, 10, 250, 50), "  Game By\nMfgpker");

        GUI.Label(new Rect(Screen.width / 2 - 225, 100, 500, 500), "Thanks to Lorc, Delaaouite, John Colburn, Felbrigg, John Redman, Carl Olsen and sbed at http://game-icons.net/ for their many icons. CC BY 3.0.");

        GUI.Label(new Rect(Screen.width / 2 - 225, 300, 500, 500), "Thanks to Hawkadium at http://opengameart.org/content/simple-buttons for amazing buttons. CC BY 3.0.");

        if(GUI.Button(new Rect(Screen.width/2 - 125, Screen.height + 10 - Offset, 250, 70), "Back", skin)){
			//Application.loadedLevelName("level1");
			ToMenu("Main");
		}
	}
	


	static void SetBool(string name, bool value){
		int v;
		if(value) v = 1; else v = 0;
		PlayerPrefs.SetInt(name, v);		
	}

	static bool GetBool(string name){
		return PlayerPrefs.GetInt(name)==1?true:false;
	}


	static bool GetBool (string name, bool defaultValue) {

	    if (PlayerPrefs.HasKey(name)) {

	        return GetBool(name);

	    }

    	return defaultValue;
	}


}

