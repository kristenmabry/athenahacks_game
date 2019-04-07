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
		if (frame % 1500 == 0) {
			list.Add(GetRandDest());
		}
    }

    public int CheckHouse(Vector3 coords) {
        if (coords.z < -65 && coords.x < -65) {
            list.PickUp();
            return 0;
        }
        else if (coords.z > 65 && coords.x < -65) {
            return list.Remove('A');
        }
        else if (coords.z > 65 && coords.x > 65) {
            return list.Remove('B');
        }
        else if (coords.z < -65 && coords.x > 65) {
            return list.Remove('D');
        }
        else if (coords.z > -20 && coords.z < 10 && coords.x > -2 && coords.x < 18) {
            return list.Remove('C');
        }
        else {
            return 0;
        }
    }

    public CPizzaList GetList() {   return list;    }
}
}