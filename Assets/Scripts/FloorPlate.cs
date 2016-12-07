using UnityEngine;
using System.Collections;

public class FloorPlate : MonoBehaviour {
  private ManageTest m_1;
	private Room current;
	private Hashtable theRooms;
	public GameObject box;

  void Start(){
    m_1 = GameObject.FindObjectOfType(typeof(ManageTest)) as ManageTest;
  }

  void OnTriggerEnter (Collider other){
    if (other.tag == "Player"){
	    var r = "";
			theRooms = m_1.getTheRooms();
			current = (Room)theRooms[m_1.lastRoom];
			r = current.generateSuccessor();
			Debug.Log(r);

	    m_1.destroyAllObjects();
			if (m_1.lastRoom == "9"){
        Debug.Log(m_1.yVal);
				var temp = Instantiate(box, new Vector3(1, m_1.yVal, -.8f), Quaternion.Euler(0, 0, 0)) as GameObject;
				temp.tag = "Room "+r+"";
        m_1.yVal -= 5;
			}
	    m_1.createRoom(""+r);
    }
  }
}
