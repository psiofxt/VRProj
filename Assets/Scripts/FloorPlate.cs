using UnityEngine;
using System.Collections;

public class FloorPlate : MonoBehaviour {
  private ManageTest m_1;
	private Room current;
	private Hashtable theRooms;

  void Start(){
    m_1 = GameObject.FindObjectOfType(typeof(ManageTest)) as ManageTest;
  }

  void OnTriggerEnter (Collider other){
    if (other.tag == "Player"){
	    var randomInt = 1;
	    var r = "";

			theRooms = m_1.getTheRooms();
			current = (Room)theRooms[m_1.lastRoom];
			r = current.generateSuccessor();
			Debug.Log(r);
			
	    m_1.destroyAllObjects();
	    m_1.createRoom(""+r);
    }
  }
}
