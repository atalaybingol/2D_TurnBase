using UnityEngine;
using System;

public class Dice {
    private int m_sides;
    private System.Random m_random;

    public Dice(int sides = 20) {
        if (sides >= 4 && sides <= 20) {
            m_sides = sides;
        } else {
            m_sides = 20;
        }
        m_random = new System.Random();
    }

    public int Roll() {
        return m_random.Next(1, m_sides + 1);
    }

    public int RollM(int numDice) {
        int total = 0;
        for (int i = 0; i < numDice; i++) {
            total += Roll();
        }
        return total;
    }
}
