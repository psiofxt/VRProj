using UnityEngine;
using System.Collections;
using Valve.VR;

public class ManageTest : MonoBehaviour {
	public GameObject floor;
	public GameObject wall;
	private GameObject theFloor;
	private GameObject[] destroying;
	private int posX, posZ = 0;
	private int count = 0;
	public float scaleX, scaleZ;
	public Vector3 corner1, corner2, corner3, corner4;

	void Start () {
		var rect = new HmdQuad_t();
		//Debug.Log(SteamVR_PlayArea.GetBounds());
		createRoom();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			restartGame();
		}

		if (Input.GetMouseButtonDown(0)){
			createRoom();
		}
	}

	public void restartGame(){
		destroyAllObjects();
	}

	public void createRoom(){
		Instantiate(floor, new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0)); // floor
        Instantiate(floor, new Vector3(0, 1, 0), Quaternion.Euler(90, 0, 0));  //ceiling
        Instantiate(wall, new Vector3(5, 0.5f, 0), Quaternion.Euler(90, 0, 0)); //wall 1
        Instantiate(wall, new Vector3(-5, 0.5f, 0), Quaternion.Euler(90, 0, 0)); // wall 3
        Instantiate(wall, new Vector3(0, 0.5f, 5), Quaternion.Euler(0, 90, 0)); // wall 2
        Instantiate(wall, new Vector3(0, 0.5f, -5), Quaternion.Euler(0, 90, 0)); // wall 4




        /*
		for (int z = 0; z < 10; z++){
			for (int x = 0; x < 10; x++){
				Instantiate(floor, new Vector3(x, 0, z), Quaternion.Euler(90, 0, 0));
			}
		}
		*/
    }

	void destroyAllObjects(){
		posX = 0;
		count = 0;
		destroying = GameObject.FindGameObjectsWithTag ("Floor");
		for(int i = 0; i < destroying.Length; i++){
				Destroy(destroying[i]);
		}
	}

}