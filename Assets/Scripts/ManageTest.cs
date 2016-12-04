using UnityEngine;
using System.Collections;
using Valve.VR;


//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//----------------------------Defines a Room and its Walls---------------------
//-----------------------------------------------------------------------------
public class Room {

	public class Wall{
		public Vector3 position;
		public Quaternion rotation;
		public float scale;
		public GameObject prefab;

		public Wall(Vector3 p, Quaternion r, GameObject o){
			position = p;
			rotation = r;
			prefab = o;
		}

		public Wall(Vector3 p, Quaternion r, GameObject o, float s){
			position = p;
			rotation = r;
			scale = s;
			prefab = o;
		}

	}

	public ArrayList walls = new ArrayList();
	public ArrayList hallway = new ArrayList();
	public ArrayList floor = new ArrayList();
	public ArrayList ladder = new ArrayList();
	public ArrayList vista = new ArrayList();
	public string ID;

	public Room(string n){
		ID = n;
	}

	public void createWall(Vector3 pos, Quaternion rot, GameObject obj){
		Wall temp = new Wall(pos, rot, obj);
		walls.Add(temp);
	}

	public void createHallway(Vector3 pos, Quaternion rot, GameObject obj){
		Wall temp = new Wall(pos, rot, obj);
		hallway.Add(temp);
	}

	public void createFloor(Vector3 pos, Quaternion rot, GameObject obj){
		Wall temp = new Wall(pos, rot, obj);
		floor.Add(temp);
	}

}

//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------

public class ManageTest : MonoBehaviour {
	public GameObject floor;
	public GameObject wall;
  public GameObject hallway1;
  public GameObject hallway2;
	//private GameObject theFloor;
	private GameObject[] destroying;
	private int posX, posZ = 0;
	private int count = 0;
	public float scaleX, scaleZ;
	public Vector3 corner1, corner2, corner3, corner4;
	private Hashtable theRooms = new Hashtable();

	private bool flipper = true;

	void Start () {
		var rect = new HmdQuad_t();
		//Debug.Log(SteamVR_PlayArea.GetBounds());
		roomInitialization();

		//creates the first room, namely the starter room
		createRoom("1");
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			restartGame();
		}

		if (Input.GetMouseButtonDown(0)){
			var randomInt = Random.Range(1 , 5);
			Debug.Log(randomInt);
			destroyAllObjects();
			createRoom(""+randomInt);
		}
	}

	public void restartGame(){
		destroyAllObjects();
	}


	/*
	roomInitialization initializes all of our Rooms which are added to a Hashtable
	with their Room ID as a key. roomInitialization is essentially our "load screen"
	at the beginning of the game -- it is only called once
	*/
	public void roomInitialization(){

		//Room 1 setup begin
		Room starterRoom = new Room("1");
		starterRoom.createFloor(new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0), floor); // floor
		starterRoom.createWall(new Vector3(5, 0.5f, 0), Quaternion.Euler(90, 0, 0), wall); // wall 1
		starterRoom.createWall(new Vector3(0, 0.5f, 5), Quaternion.Euler(90, 90, 0), wall); // wall 2
		starterRoom.createWall(new Vector3(-5, 0.5f, 0), Quaternion.Euler(90, 0, 0), wall); // wall 3
		starterRoom.createWall(new Vector3(0, 0.5f, -5), Quaternion.Euler(90, 90, 0), wall); // wall 4
		starterRoom.createHallway(new Vector3(3, 0.5f, 2), Quaternion.Euler(0, 0, 0), hallway1); // big hallway
		starterRoom.createHallway(new Vector3(3, 0.5f, -4), Quaternion.Euler(0, 0, 0), hallway2); // small hallway
		theRooms.Add("1", starterRoom);
		count++;
		//Room 1 setup end

		//Room 2 setup begin
		Room room_2 = new Room("2");
		room_2.createFloor(new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0), floor); // floor
		room_2.createWall(new Vector3(5, 0.5f, 0), Quaternion.Euler(90, 0, 0), wall); // wall 1
		room_2.createWall(new Vector3(0, 0.5f, 5), Quaternion.Euler(90, 90, 0), wall); // wall 2
		room_2.createWall(new Vector3(-5, 0.5f, 0), Quaternion.Euler(90, 0, 0), wall); // wall 3
		room_2.createWall(new Vector3(0, 0.5f, -5), Quaternion.Euler(90, 90, 0), wall); // wall 4
		room_2.createHallway(new Vector3(-3, 0.5f, 2), Quaternion.Euler(0, 0, 0), hallway1); // big hallway
		room_2.createHallway(new Vector3(-3, 0.5f, -4), Quaternion.Euler(0, 0, 0), hallway2); // small hallway
		theRooms.Add("2", room_2);
		count++;
		//Room 2 setup end

		//Room 3 setup begin
		Room room_3 = new Room("3");
		room_3.createFloor(new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0), floor); // floor
		room_3.createWall(new Vector3(5, 0.5f, 0), Quaternion.Euler(90, 0, 0), wall); // wall 1
		room_3.createWall(new Vector3(0, 0.5f, 5), Quaternion.Euler(90, 90, 0), wall); // wall 2
		room_3.createWall(new Vector3(-5, 0.5f, 0), Quaternion.Euler(90, 0, 0), wall); // wall 3
		room_3.createWall(new Vector3(0, 0.5f, -5), Quaternion.Euler(90, 90, 0), wall); // wall 4
		room_3.createHallway(new Vector3(-2, 0.5f, 3), Quaternion.Euler(0, 90, 0), hallway1); // big hallway
		room_3.createHallway(new Vector3(4, 0.5f, 3), Quaternion.Euler(0, 90, 0), hallway2); // small hallway
		theRooms.Add("3", room_3);
		count++;
		//Room 3 setup end

		//Room 4 setup begin
		Room room_4 = new Room("4");
		room_4.createFloor(new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0), floor); // floor
		room_4.createWall(new Vector3(5, 0.5f, 0), Quaternion.Euler(90, 0, 0), wall); // wall 1
		room_4.createWall(new Vector3(0, 0.5f, 5), Quaternion.Euler(90, 90, 0), wall); // wall 2
		room_4.createWall(new Vector3(-5, 0.5f, 0), Quaternion.Euler(90, 0, 0), wall); // wall 3
		room_4.createWall(new Vector3(0, 0.5f, -5), Quaternion.Euler(90, 90, 0), wall); // wall 4
		room_4.createHallway(new Vector3(2, 0.5f, -3), Quaternion.Euler(0, 90, 0), hallway1); // big hallway
		room_4.createHallway(new Vector3(-4, 0.5f, -3), Quaternion.Euler(0, 90, 0), hallway2); // small hallway
		theRooms.Add("4", room_4);
		count++;
		//Room 4 setup end

	}

	public void makeRoom(Room r){
		foreach (Room.Wall o in r.floor){
			var temp = Instantiate(o.prefab, o.position, o.rotation) as GameObject;
			temp.tag = "Room "+r.ID+"";
		}
		foreach (Room.Wall o in r.walls){
			var temp = Instantiate(o.prefab, o.position, o.rotation) as GameObject;
			temp.tag = "Room "+r.ID+"";
		}
		foreach (Room.Wall o in r.hallway){
			var temp = Instantiate(o.prefab, o.position, o.rotation) as GameObject;
			temp.tag = "Room "+r.ID+"";
		}
	}

	public void createRoom(string ID){
		Room current = (Room)theRooms[ID];
		makeRoom(current);
    }


	public void destroyPrevious(){
		//to do: make this function destroy the room that was generated two rooms ago
	}


	void destroyAllObjects(){
		for (int n = 1; n <= count; n++){
			destroying = GameObject.FindGameObjectsWithTag ("Room "+n+"");
			for(int i = 0; i < destroying.Length; i++){
					Destroy(destroying[i]);
			}
		}
	}
}
