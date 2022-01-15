using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System;

public class SingleCharacterScript : MonoBehaviour
{
    public Animator animator;
    // ------- EASY -------
    private int easyMinHP = 70;
    private int easyMaxHP = 101;

    private int easyMinSta = 50;
    private int easyMaxSta = 76;

    private int easyMinAtt = 5;
    private int easyMaxAtt = 11;

    private int easyMinArm = 5;
    private int easyMaxArm = 16;

    // ------- MEDIUM -------
    private int mediumMinHP = 125;
    private int mediumMaxHP = 176;

    private int mediumMinSta = 100;
    private int mediumMaxSta = 151;

    private int mediumMinAtt = 20;
    private int mediumMaxAtt = 36;

    private int mediumMinArm = 20;
    private int mediumMaxArm = 31;

    // ------- HARD -------
    private int hardMinHP = 200;
    private int hardMaxHP = 301;

    private int hardMinSta = 175;
    private int hardMaxSta = 251;

    private int hardMinAtt = 45;
    private int hardMaxAtt = 61;

    private int hardMinArm = 40;
    private int hardMaxArm = 56;

    public class Entity
    {
        public string name = "Unnamed Gladiator"; // the name that appears on screen
        public string iconPath = "missing.png"; // where the icon that appears on screen is found in the project files

        public int health;
        public int stamina;
        public int attack;
        public int armor;
        public bool isPlayer;

        public Entity(string name_, string icon, int hp, int sta, int att, int arm, bool isPl)
        {
            name = name_;
            iconPath = icon;

            health = hp;
            stamina = sta;
            attack = att;
            armor = arm;
            isPlayer = isPl;
            Debug.Log("intrat" + name);
        }
    }


    // generates an enemy by randomizing his stats based on the difficulty provided and returns an Entity object
    static Entity generateEnemy(string name, string iconPath, string diff)
    {
        Random rnd = new Random();
        int hp = 100;
        int sta = 50;
        int att = 10;
        int arm = 10;

        if (diff.Equals("easy"))
        {
            hp = rnd.Next(70, 101);
            sta = rnd.Next(50, 76);
            att = rnd.Next(5, 11);
            arm = rnd.Next(5, 16);
        }
        else if (diff.Equals("medium"))
        {
            hp = rnd.Next(125, 176);
            sta = rnd.Next(100, 151);
            att = rnd.Next(20, 36);
            arm = rnd.Next(20, 31);
        }
        else if (diff.Equals("hard"))
        {
            hp = rnd.Next(200, 301);
            sta = rnd.Next(175, 251);
            att = rnd.Next(45, 61);
            arm = rnd.Next(40, 56);
        }

        Entity enemy = new Entity(name, iconPath, hp, sta, att, arm, false);
        return enemy;
    }
    public int turn;
    public Entity Player;
    public Entity Enemy;
    void Awake()
    {

        turn = 1;
        Player = new Entity("ioana", "xyz.jpg", 300, 200, 100, 400, true);
        Enemy = generateEnemy("inamic", "abc.jpeg", "easy");

    }
    private static int numberOfActions = 3;
    string[] possibleActions = { "lightAttack", "mediumAttack", "heavyAttack" };
    string getNextAction()
    {
        Random rnd = new Random();
        return possibleActions[rnd.Next(0, numberOfActions)];
    }

    private void Update()
    { if (turn == -1)
            return;
        if (turn == 1)
        {
            if (Enemy.health <= 0)
            { Debug.Log("you won");
                turn = -1; }
            return;
        }
        else if (Player.health <= 0)
        {
            Debug.Log("you lost");
            turn = -1;
        }
    
        else
        {
            string move = getNextAction();
            switch (move)

            {
                case "lightAttack":
                    Enemy.stamina -= 50;
                    Player.health -= 30 / ((int)(Math.Log(Player.armor)));
                    break;
                case "mediumAttack":
                    Enemy.stamina -= 100;
                    Player.health -= 50 / ((int)(Math.Log(Player.armor)));
                    break;
                case "heavyAttack":
                    Enemy.stamina -= 150;
                    Player.health -= 70 / ((int)(Math.Log(Player.armor)));
                    break;
                    /*case "block":
                         Enemy.stamina -= 50;
                         Player.health -= 30 / ((int)(Math.Log10(Player.armor)));
                         break;
                    */


            }
            turn = 1;
            Player.stamina += 15;
            Debug.Log(Enemy.stamina);
            Debug.Log(Enemy.health);

        }
    }
    public void buttonLightAttack()
    {
        if (turn != 1) return;
        
            Player.stamina -= 50;
            Enemy.health -= 30 / ((int)(Math.Log(Enemy.armor)));
            turn = 0;
        Enemy.stamina += 15;

        Debug.Log("stamina: " + Player.stamina);
        Debug.Log("health: " + Enemy.health);
    }
    public void buttonMediumAttack()
    {
        if (turn != 1) return; 
            Player.stamina -= 100;
        Enemy.health -= 50 / ((int)(Math.Log(Enemy.armor)));
        turn = 0;
        Enemy.stamina += 15;

        Debug.Log("stamina: " + Player.stamina);
        Debug.Log("health: " + Enemy.health);
    }
    public void buttonHeavyAttack()
    {
        if (turn != 1) return;
        Player.stamina -= 150;
        Enemy.health -= 70 / ((int)(Math.Log(Enemy.armor)));
        turn = 0;
        Enemy.stamina += 15;


        Debug.Log("stamina: " + Player.stamina);
        Debug.Log("health: " + Enemy.health);
    }



}


