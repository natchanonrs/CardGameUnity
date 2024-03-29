using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public int playerNumber;
    public GameObject[] unityCard;
	public List<GameObject> myCard;
	public List<GameObject> backCard;

    // Use this for initialization
    void Start () {
        this.unityCard = new GameObject[2];
		myCard = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addCard(GameObject c)
	{
		if (this.playerNumber == 0) {
			c.transform.SetParent(this.transform);
			myCard.Add (c);
		} 
		else if (this.playerNumber == 2) {
			GameObject reverse = (GameObject)Instantiate(Resources.Load("Back"), c.transform.position, Quaternion.identity);
			reverse.transform.SetParent (this.transform);
			//c.transform.SetParent (this.transform);
			backCard.Add(reverse);
			myCard.Add (c);
		}       
		else if (this.playerNumber == 3){
			GameObject reverse = (GameObject)Instantiate(Resources.Load("Back"), c.transform.position, new Quaternion(0,0,1.0f,1.0f));
			reverse.transform.SetParent (this.transform);
			//c.transform.SetParent (this.transform);
			backCard.Add(reverse);
			myCard.Add (c);
		}
		else if (this.playerNumber == 1){
			GameObject reverse = (GameObject)Instantiate(Resources.Load("Back"), c.transform.position, new Quaternion(0,0,-1.0f,1.0f));
			reverse.transform.SetParent (this.transform);
			//c.transform.SetParent (this.transform);
			backCard.Add(reverse);
			myCard.Add (c);
		}
	}

    public void showHand()
    {
        /*int i = 1;

        foreach (GameObject card in myCard)
        {
            card.transform.eulerAngles = rotation;
            card.transform.position = handLocation;
            card.transform.position += offset * (i++);

            //card.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }*/
    }

    public void resetHand()
    {     
        //this.hand = new PokerHand();
        this.unityCard = new GameObject[2];
    }
	/*
    public void removeCard()
    {
        foreach (GameObject c in unityCard)
        {
        	unityCard[i] = null;
        }
    }*/


    public void sortHand()
    {
        Card[] cardList = new Card[5];
		List<GameObject> tempList = new List<GameObject>();

        int i = 0;
        foreach (GameObject card in myCard)
        {
            cardList[i++] = card.GetComponent<CardScript>().card;
        }
        System.Array.Sort(cardList);

        for (i = 0; i < 5; i++)
        {
            foreach (GameObject card in myCard)
            {
                if (card.GetComponent<CardScript>().card.Equals(cardList[i]))
                {
					tempList.Add(card);
                }
            }
        }
        
        if (tempList[4] != null)
        {
            myCard = tempList;
        } else
        {
            Debug.Log("Error sorting player Hand.");
        }

        /*if (playerNumber == 1)
        {
            resetLocation();
        }*/      
    }

	public Card[] getCards()
    {
        Card[] cards = new Card[5];
        int i = 0;
        //foreach (GameObject c in unityCard)
		foreach (GameObject c in myCard)
        {
            cards[i++] = c.GetComponent<CardScript>().card;
        }
        return cards;
    }

    public GameObject getCardAtIndex(int index)
    {
        return myCard[index];
    }

	public int getCardIndex(GameObject card)
	{
		int i = 0;
		foreach (GameObject cards in myCard)
		//for (int i = 0; myCard.; i++)
		{
			
			if (cards.Equals(card))
			{
				return i;
			}
			i++;
		}
		return -1;
	}

	/*public int getCardIndex(Card card)
	{
		int i = 0;
		foreach (GameObject c in unityCard)
		{
			if (c.GetComponent<CardScript>().card.Equals(card))
			{
				return i;
			}
			i++;
		}
		return -1;
	}*/

}
