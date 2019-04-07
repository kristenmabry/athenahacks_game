using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using HandlePizzas;

public class MainGame : MonoBehaviour {
    public float yaw;
    public float rad;
	public Camera MainCamera;
	public Player Player;
	public Text pizzaLabel;
	public Text ALabel;
	public Text BLabel;
	public Text CLabel;
	public Text DLabel;
	public Text scoreLabel;
	public Text pizzaCarLabel;
	public Text strikeLabel;
    public Text timerLabel;
	public Image star;


	protected Vector3 cameraOffset;
	protected HandlePizzaList pizzaHandler;
	protected int score;

	 //Use this for initialization
	 protected void Start () {
		if (Player == null) {
			Debug.LogError("Player was not set!  Attach a Player in the Main.scene!");
		}
		if (MainCamera == null) {
			Debug.LogError("Main Camera is not set.  Attach a Camera in the Main.scene!");
		}
		cameraOffset = Player.transform.position;
		pizzaHandler = new HandlePizzaList();
		score = 0;

		float newZ = ((Player.transform.position.z + 50) * 1/5) + 85;
			star.rectTransform.localPosition = new Vector3(
				(Player.transform.position.x * 6/16) - 2,
				newZ - 4,
				(float)134.2
			);
			pizzaCarLabel.rectTransform.localPosition = new Vector3(
				(Player.transform.position.x * 6/16),
				newZ,
				(float)134.2
			);
		
	}

    //protected void FixedUpdate()
    //{
    //    HandleInputAxes();
    //}

    //Update is called once per frame; good for input
    protected void Update() {
		ResolveInput();
		NumberMap();
		pizzaHandler.Update(Time.frameCount);

	}
	 
	 //LateUpdate is called once per frame after Update(); good for cameras following characters
	protected void LateUpdate() {
		RepositionCamera();
	}

	//Helper methods
	protected void ResolveInput() {
		OnKeyDown();
		HandleInputAxes();
	}

	protected void OnKeyDown() {
		//Input.GetKeyDown returns true on the frame the Key was pressed down
		if (Input.GetKeyDown(KeyCode.Space)) {
			score += pizzaHandler.CheckHouse(Player.transform.position);
		}
		
	}

	protected void HandleInputAxes() {
		//Input.GetAxisRaw returns a value -1, 0, or 1
		//float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime; //multiply by Time.deltaTime to normalize movement
		//float z = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        //If we're moving, let's tell the player to move
        if(Input.GetKey(KeyCode.UpArrow)) {
            yaw = InputTracking.GetLocalRotation(XRNode.Head).eulerAngles.y;
            rad = yaw * Mathf.Deg2Rad;
            float z = Mathf.Cos(rad) *Time.deltaTime;
            float x = Mathf.Sin(rad) * Time.deltaTime;
			Player.Move(x*10, z*10);
			float newZ = ((Player.transform.position.z + 50) * 1/5) + 85;
			star.rectTransform.localPosition = new Vector3(
				(Player.transform.position.x * 6/16) - 2,
				newZ - 4,
				(float)134.2
			);
			pizzaCarLabel.rectTransform.localPosition = new Vector3(
				(Player.transform.position.x * 6/16),
				newZ,
				(float)134.2
			);
		}
	}

	protected void RepositionCamera() {
		MainCamera.transform.position = Player.transform.position;
		MainCamera.transform.rotation = Player.transform.rotation;
	}

	protected void NumberMap() {
		pizzaLabel.text = pizzaHandler.GetList().GetHutCount().ToString();
		ALabel.text = pizzaHandler.GetList().numOrdersFor('A').ToString();
		BLabel.text = pizzaHandler.GetList().numOrdersFor('B').ToString();
		CLabel.text = pizzaHandler.GetList().numOrdersFor('C').ToString();
		DLabel.text = pizzaHandler.GetList().numOrdersFor('D').ToString();
		scoreLabel.text = "Score: " + score.ToString();
		pizzaCarLabel.text = pizzaHandler.GetList().GetCount().ToString();
        timerLabel.text = "Timer: " + (Time.time).ToString("F2");
		//strikeLabel.text = "Strikes: " + "0" + "/3";
	}
}
