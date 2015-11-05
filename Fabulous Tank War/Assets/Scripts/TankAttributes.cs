using UnityEngine;
using System.Collections;

public class TankAttributes : MonoBehaviour {

    //A tank's beauty level
    private int tnkBeauty;

    public int TnkBeauty
    {
        get
        {
            return tnkBeauty;
        }

        set
        {
            tnkBeauty = value;
        }
    }

    //A tank's Fire Power level
    private int tnkPower;

    public int TnkPower
    {
        get
        {
            return tnkPower;
        }

        set
        {
            tnkPower = value;
        }
    }

    //A tank's durability level
    private int tnkDurability;

    public int TnkDurability
    {
        get
        {
            return tnkDurability;
        }

        set
        {
            tnkDurability = value;
        }
    }

    //A tank's score from the judges
    private int tnkScore;

    public int TnkScore
    {
        get
        {
            return tnkScore;
        }
        set
        {
            tnkScore = value;
        }
    }


    void Start () {
        TankAttributes tankPlayer = new TankAttributes();
        tankPlayer.TnkBeauty = 18;
        tankPlayer.TnkDurability = 20;
        tankPlayer.TnkPower = 19;

	}
	
	void Update () {
	
	}
}
