using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int health = 100;
    private int maxHealth = 100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public void UpdateHealth(int hp)
    {
        if(hp >= 0 && hp <= maxHealth)
            health = hp;
        Debug.Log("Now " + gameObject.name + "'s HP is " + health);

    }

    public bool isDeath()
    {
        if (health <= 0) return true;
        return false;
    }
}
