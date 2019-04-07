using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PizzaList;

namespace HandlePizzas {
public class HandlePizzaList {

    protected CPizzaList list;
    public HandlePizzaList() {
        list = new CPizzaList();
        list.Add(GetRandDest());
        list.Add(GetRandDest());
        list.Add(GetRandDest());
    }
    

	protected char GetRandDest() {
		int randNum = (int)Random.Range(0F, 3F);
		if (randNum == 0) {
			return 'A';
		}
		else if (randNum == 1) {
			return 'B';
		}
		else if (randNum == 2) {
			return 'C';
		}
		else {
			return 'D';
		}
	}

    public void Update(int frame) {
		if (frame % 500 == 0) {
			list.Add(GetRandDest());
		}
    }

    public int CheckHouse(Vector3 coords) {
        if (coords.z < -70 && coords.x < -70) {
            list.PickUp();
            return 0;
        }
        else if (coords.z > 70 && coords.x < -70) {
            return list.Remove('A');
        }
        else if (coords.z > 70 && coords.x > 70) {
            return list.Remove('B');
        }
        else if (coords.z < -70 && coords.x > 70) {
            return list.Remove('D');
        }
        else if (coords.z > -18 && coords.z < 8 && coords.x > 0 && coords.x < 16) {
            return list.Remove('C');
        }
        else {
            return 0;
        }
    }

    public CPizzaList GetList() {   return list;    }
}
}