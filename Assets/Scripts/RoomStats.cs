using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStats : MonoBehaviour
{
	private bool trap1, trap2;
	private string type;
	public string trap1Name, trap2Name;
	public int startX, startY, endX, endY;
	private bool isPlayerHere;

	public GameObject trap1Object, trap2Object, monsterSpawn;
	public Animator animtrap1, animtrap2;
	private GameObject[] monsters;
	private bool shouldSpawnMonster = false;
	
	// Use this for initialization
	void Start ()
	{
		monsters = Resources.LoadAll<GameObject>("Prefab/Monsters");
		if (this.trap1Object != null && !this.trap1Object.CompareTag("Multi"))
		{
			this.animtrap1 = trap1Object.GetComponent<Animator>();
		}
		if (this.trap2Object != null && !this.trap2Object.CompareTag("Multi"))
		{
			this.animtrap2 = trap2Object.GetComponent<Animator>();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
//		SpawnMonster();
		if (trap1)
		{
			trap1Object.GetComponent<OverTrapHandler>().trapActive = true;
			animtrap1.SetTrigger("Open");
		}

		if (trap2)
		{
			if (trap2Object.CompareTag("Multi"))
			{
				for (int i = 0; i < trap2Object.transform.childCount; i++)
				{
					trap2Object.transform.GetChild(i).GetComponent<Animator>().SetTrigger("Open");
				}
			}
		}

		if (shouldSpawnMonster)
		{
			GameObject monster = Instantiate(monsters[Random.RandomRange(0, monsters.Length)]);
			monster.transform.position =
				monsterSpawn.transform.GetChild(Random.RandomRange(0, monsterSpawn.transform.childCount)).transform.position;
			shouldSpawnMonster = false;
		}
	}

	public void Init()
	{
		trap1 = false;
		trap2 = false;
		this.type = this.gameObject.name;
	}

	public void SpawnMonster()
	{
		shouldSpawnMonster = true;
	}
	
	public void TriggerTrap1()
	{
		trap1 = true;
	}

	public void TriggerTrap2()
	{
		trap2 = true;
	}

	public bool HasTrap1BeenUsed()
	{
		return trap1;
	}
	
	public bool HasTrap2BeenUsed()
	{
		return trap2;
	}

	public string GetTrap1Name()
	{
		return this.trap1Name;
	}
	
	public string GetTrap2Name()
	{
		return this.trap2Name;
	}

	public string GetRoomName()
	{
		return type;
	}

	public void SetIsPlayerHere(bool isPlayerHere)
	{
		this.isPlayerHere = isPlayerHere;
	}

	public bool IsPlayerHere()
	{
		return this.isPlayerHere;
	}
	
}
