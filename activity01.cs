using System;

namespace c__projects_dir {
  namespace activity_1 {
    class Game {

      //Core var
      static Random rnd = new Random();
      const string gameEndMessage = "Thank you for visiting the Arkos dungeon!";
      static string gameEndReason;

      //Gameplay var
      static string boss;
      static int bossHealth;
      static int userHealth = 100;
      static int turn;


      static void Main(string[] args) {
        //On game start
        Console.WriteLine("Welcome voyager to the Arkos dungeon");
        Console.WriteLine("Choose which level you're willing to fight! \n type the number and enter to start!\n - Type 1 for beginner\n - Type 2 for intermediate\n - Type 3 for hard\nInput your desired level:");

        string level = Console.ReadLine();

        //level switch
        switch (level)
        {
            case "1":
            //easy
              boss = "akuma";
              bossHealth = 20;
              turn = 1;
              Console.WriteLine("easy level chosen boss: " + boss + " HP: " + bossHealth);
            break;
            case "2":
            //intermediate
              boss = "gladiator";
              bossHealth = 30;
              turn = 1;
              Console.WriteLine("intermediate level chosen boss: " + boss + " HP: " + bossHealth);
            break;
            case "3":
            //hard
              boss = "hades";
              bossHealth = 40;
              turn = 1;
              Console.WriteLine("hard level chosen boss: " + boss + " HP: " + bossHealth);
            break;
            default:
              Console.WriteLine("Level chosen is not valid!");
            break;
        }
        Console.WriteLine("Press enter to start!");
        Console.ReadLine();
        bossLines();
        battle();
      }

      //Boss battle start
      static void battle() {
        if (bossHealth <= 0) {
          gameEndReason = "bossDead";
          battleEnd();
          return;
        } else if (userHealth <= 0) {
          gameEndReason = "userDead";
          battleEnd();
          return;
        } else if (turn == 11) {
          gameEndReason = "outOfRounds";
          battleEnd();
          return;
        }
        Console.WriteLine("Press enter to start the round");
        Console.ReadLine();
        Console.WriteLine("-----[Round " + turn + "/10]-----");
        userTurn();
      }

      //user attacks
      static void userTurn() {
        Console.WriteLine(" - type 1 [damage]Sword slash: deal 5 damage\n - type 2 [heal]Potion: +10 HP\nInput your attack:");
        string attack = Console.ReadLine();
        switch (attack) {
          case "1":
            Console.WriteLine("\nYou attacked " + boss);
            int critChance = rnd.Next(1, 2);
            if (critChance == 1)
            {
              bossHealth -= 5;
              Console.WriteLine("Dealth 5 damage to " + boss + "\n\nCurrent boss HP: " + bossHealth + "\n-----------------");
            } else if (critChance == 2)
            {
              bossHealth -= 10; 
              Console.WriteLine("\nYou landed a critical!"); 
              Console.WriteLine("Dealth 10 damage to " + boss + "\n\nCurrent boss HP: " + bossHealth + "\n-----------------"); 
            }
            bossTurn();
          break;

          case "2":
            int currentHP = userHealth + 10; 
            if (currentHP <= 90) {
              userHealth += 10;
              Console.WriteLine("You healed yourself. Current HP: " + userHealth);
            } else {
              Console.WriteLine("Current HP is still high. Potion is ineffective");
            }
            bossTurn();
          break;

          default:
            Console.WriteLine("Turn skipped");
            bossTurn();
          break;
        }
      }

      //boss attacks
      static void bossTurn() {
        Console.WriteLine("Press enter to end your round");
        Console.ReadLine();
        Console.WriteLine("-----[Boss turn]-----\nNow it's my turn!");
        switch (boss) {
          case "akuma":
          int akumaAttack = rnd.Next(1, 7);
          if (akumaAttack != 2)
            {
              userHealth -= 5;
              Console.WriteLine(boss + " attacked with 5 damage\n\nCurrent HP: " + userHealth);
            } else
            {
              userHealth -= 10; 
              Console.WriteLine(boss + " landed a critical!"); 
              Console.WriteLine(boss + " attacked with 10 damage\n\nCurrent HP: " + userHealth); 
            }
            turn++;
            battle();
          break;
          case "gladiator":
          int gladiatorAttack = rnd.Next(1, 5);
          if (gladiatorAttack != 2)
            {
              userHealth -= 10;
              Console.WriteLine(boss + " attacked with 10 damage\n\nCurrent HP: " + userHealth);
            } else
            {
              userHealth -= 15; 
              Console.WriteLine(boss + " landed a critical!"); 
              Console.WriteLine(boss + " attacked with 15 damage\n\nCurrent HP: " + userHealth); 
            }
            turn++;
            battle();
          break;
          case "hades":
          int hadesAttack = rnd.Next(1, 2);
          if (hadesAttack != 2)
            {
              userHealth -= 15;
              Console.WriteLine(boss + " attacked with 15 damage\n\nCurrent HP: " + userHealth);
            } else
            {
              userHealth -= 20; 
              Console.WriteLine(boss + " landed a critical!"); 
              Console.WriteLine(boss + " attacked with 20 damage\n\nCurrent HP: " + userHealth); 
            }
            turn++;
            battle();
          break;
        }
        
      }

      //battle has ended
      static void battleEnd() {
        switch (gameEndReason) {
          case "bossDead":
            Console.WriteLine("You defeated " + boss + "!");
            Console.WriteLine(gameEndMessage);
            Environment.Exit(0);
          break;
          case "userDead":
            Console.WriteLine("You were defeated by " + boss + "!");
            Console.WriteLine(gameEndMessage);
            Environment.Exit(0);
          break;
          case "outOfRounds":
            if (bossHealth <= 0) {
              gameEndReason = "bossDead";
              battleEnd();
            } else if (userHealth <= 0) {
              gameEndReason = "userDead";
              battleEnd();
            } else if (turn == 11) {
              Console.WriteLine("You ran out of turns and procedeed to run out of the dungeon!");
              Console.WriteLine(gameEndMessage);
              Environment.Exit(0);
            }
          break;

        }
      }


      //bosslines
      static void bossLines() {
        switch (boss) {
          case "akuma":
            Console.WriteLine("[Akuma] I will haunt you until the ends of time!");
          break;
          case "gladiator":
            Console.WriteLine("[Gladiator] Let's battle forever!");
          break;
          case "hades":
            Console.WriteLine("[Hades] Care to join me in the underworld?");
          break;

        }
      }
    } 
  }
}