﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour {

    public int damageToGive;
    public GameObject damageBurst;
    public Transform impactPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damageToGive);
            Instantiate(damageBurst, impactPoint.position, impactPoint.rotation);
        }
    }
}
