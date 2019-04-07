using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pizza;

namespace PizzaList {
public class CPizzaList
{
    public CPizzaList() {
        pizzas = new CPizza[10];
        numPizzas = 0;
        numPizzasHut = 0;
        pizzahut = new CPizza[20];
    }
    public void Add(char orderAddress) {
        CPizza nPizza = new CPizza(orderAddress);
        if(!isFull())
        {
            pizzahut[numPizzasHut] = nPizza;
            numPizzasHut++;
        }
        else
        {
            return;
        }
    }
    public int Remove(char tAddress) {
        int score = 0;
        for(int i = 0; i < numPizzas; i++)
        {
            if(pizzas[i].address == tAddress)
            {
                int nScore = (int)(Time.time - pizzas[i].GetTime());
                nScore = 60 - nScore > 0 ? (60 - nScore) * 10 : 0;
                score += nScore;

                pizzas[i] = null;
                shiftForward(i);
                i--;
                numPizzas--;

            }
        }
        return score;
    }

    public void PickUp() {
        if (numPizzasHut + numPizzas <= 10) {
            for (int i = 0; i < numPizzasHut && numPizzas < 10; i++) {
                pizzas[numPizzas] = pizzahut[i];
                numPizzas++;
            }
            numPizzasHut = 0;
        }
        else if (numPizzas < 10) {
            while (numPizzas < 10) {
                pizzas[numPizzas] = pizzahut[0];
                shiftForwardHut(0);
                numPizzas++;
                numPizzasHut--;
            }
        }
        else {
            return;
        }
        
    }

    public int GetCount() { return numPizzas; }
    public int GetHutCount() { return numPizzasHut; }
    public int numOrdersFor(char tAddress) {
        int count = 0;
        for(int i = 0; i < numPizzas; i++)
        {
            if(pizzas[i].address == tAddress)
            {
                count++;
            }
        }
        return count;
    }
    public bool isFull() { return numPizzas == 10; }

    protected CPizza []pizzas;
    protected CPizza []pizzahut;
    protected void shiftForward(int index) {
        for(int i = index; i < numPizzas - 1; i++)
        {
            pizzas[i] = pizzas[i + 1];
        }
    }

    protected void shiftForwardHut(int index) {
        for(int i = index; i < numPizzasHut - 1; i++)
        {
            pizzahut[i] = pizzahut[i + 1];
        }
    }
    protected int numPizzas;
    protected int numPizzasHut;

}
}
