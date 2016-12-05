using UnityEngine;
using System.Collections;

public class FloorPlate : MonoBehaviour {
	private ManageTest m_1;
	private int lastRoom = 1;
    private int transitTotal = 0;
 
    private static ArrayList room1 =  new ArrayList {5,9};
    private static ArrayList room2 = new ArrayList { 6, 7, 8, 9 }; //this can be used for 2 and 5
    private static ArrayList room3 = new ArrayList {};
    private static ArrayList room4 = new ArrayList { 6 };
    private static ArrayList room6 = new ArrayList {9, 10};
    private static ArrayList room8 = new ArrayList {1, 5};
    private static ArrayList room9 = new ArrayList {3, 5, 10};

    void Start(){
		m_1 = GameObject.FindObjectOfType(typeof(ManageTest)) as ManageTest;
	}

	void OnTriggerEnter (Collider other){
	  if (other.tag == "Player"){
      var randomInt = 0;
      var r = 0;

        if (m_1.lastRoom == 1){
                r = Random.Range(0, room1.Count);
                randomInt = (int)room1[r];
            }

        else if (m_1.lastRoom == 2 || m_1.lastRoom == 5) {
                r = Random.Range(0, room2.Count);
                randomInt = (int)room2[r];
            }

        else if (m_1.lastRoom == 3 || m_1.lastRoom == 7)
            {
                randomInt = 11;
            }

            else if (m_1.lastRoom == 4)
            {
                r = Random.Range(0, room4.Count);
                randomInt = (int)room4[r];
            }

        else if (m_1.lastRoom == 6) {
                r = Random.Range(0, room6.Count);
                randomInt = (int)room6[r];
            }

        else if (m_1.lastRoom == 8)
            {
                r = Random.Range(0, room8.Count);
                randomInt = (int)room8[r];
            }

        else if(m_1.lastRoom  == 9){
                r = Random.Range(0, room9.Count);
                randomInt = (int)room9[r];
            }

      else{
        randomInt = Random.Range(1, 10);
      }

      m_1.lastRoom = randomInt;
			Debug.Log(randomInt);
			m_1.destroyAllObjects();
			m_1.createRoom(""+randomInt);
		}
	}
}
