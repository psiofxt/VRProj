using UnityEngine;
using System.Collections;

public class FloorPlate : MonoBehaviour {
	private ManageTest m_1;
	private int lastRoom = 1;
    private int transitTotal = 0;

	void Start(){
		m_1 = GameObject.FindObjectOfType(typeof(ManageTest)) as ManageTest;
	}

	void OnTriggerEnter (Collider other){
	  if (other.tag == "Player"){
      var randomInt = 0;
      if (lastRoom == 1)
      {
        randomInt = 5;
      }
      else if (lastRoom == 5) {
            
                randomInt = Random.Range(6, 9);
            }
      else
      {
        randomInt = Random.Range(1, 6);
      }

      lastRoom = randomInt;
			Debug.Log(randomInt);
			m_1.destroyAllObjects();
			m_1.createRoom(""+randomInt);
		}
	}
}
