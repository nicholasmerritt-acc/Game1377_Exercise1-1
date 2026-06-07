using System;
using UnityEngine;

/*
 * Assignment: Rock Paper Scissors Lizard Spock Game
 * 
 * Objective:
 * Implement a fully functional Rock Paper Scissors Lizard Spock game using Unity and C#. The player selects a choice via UI buttons, 
 * the computer randomly selects its choice, and the game determines the winner based on the game rules.
 * 
 * Requirements:
 * 1. The player can choose from five options: Rock, Paper, Scissors, Lizard, or Spock by pressing designated buttons in the scene.
 * 2. The computer randomly selects one of the five choices each turn.
 * 3. Game logic determines the winner based on the following rules:
 *    - Rock beats Scissors and Lizard  //0, 2, 3   //000, 010, 011
 *    - Paper beats Rock and Spock      //1, 0, 4   //001, 000, 100
 *    - Scissors beats Paper and Lizard //2, 1, 3   //010, 001, 011
 *    - Lizard beats Paper and Spock    //3, 1, 4   //011, 001, 100
 *    - Spock beats Scissors and Rock   //4, 2, 0   //100, 010, 000
 * 4. Ties occur when both the player and computer choose the same option.
 * 5. All game results (player choice, computer choice, and outcome) should be output using Debug.Log.
 * 6. Use an enum to represent the five choices instead of strings.
 * 7. Update the OnClick() method in the editor to use enums instead of strings.
 * 
 * Instructions:
 * - Attach the script to any active GameObject in your Unity scene.
 * - Change the OnClick method on the UI buttons in the scene to use enums instead of strings.
 * - Observe the game results in the Console after each button press.
 * 
 * Hint:
 * - Start by just fixing up the strings and doing Rock Paper Scissors. 
 * - Once you have that working, add in the Lizard and Spock options and update the game logic accordingly.
 * - Lastly, change the method to use enums instead of strings.
 *
 */

public class RockPaperScissorsGameBasic : MonoBehaviour
{

    string[] choices = { "rock", "paper", "scissors", "lizard", "spock" };

    public void RockPaperScissors(string playerChoice)
    {
        Debug.Log("You chose: " + playerChoice);

        string computerChoice = choices[UnityEngine.Random.Range(0, choices.Length)];
        Debug.Log("Computer chose: " + computerChoice);

        if (computerChoice == playerChoice)
        {
            Debug.Log("It's a tie! Both chose " + playerChoice);
        }
        else
        {
            switch (playerChoice)
            {
                //Rock beats Scissors and Lizard
                case "rock":
                    CheckWin(playerChoice, computerChoice, "scissors", "lizard");
                    break;
                //Paper beats Rock and Spock
                case "paper":
                    CheckWin(playerChoice, computerChoice, "rock", "spock");
                    break;
                //Scissors beats Paper and Lizard
                case "scissors":
                    CheckWin(playerChoice, computerChoice, "paper", "lizard");
                    break;
                //Lizard beats Paper and Spock
                case "lizard":
                    CheckWin(playerChoice, computerChoice, "paper", "spock");
                    break;
                //Spock beats Scissors and Rock
                case "spock":
                    CheckWin(playerChoice, computerChoice, "scissors", "rock");
                    break;
            }
        }
    }

    public void CheckWin(string playerChoice, string computerChoice, string beats1, string beats2)
    {
        if (computerChoice == beats1 || computerChoice == beats2)
        {
            Win(playerChoice, computerChoice);
        }
        else
        {
            Lose(playerChoice, computerChoice);
        }
    }

    public void Win(string playerChoice, string computerChoice)
    {
        Debug.Log("You win! " + playerChoice + " beats " + computerChoice);
    }

    public void Lose(string playerChoice, string computerChoice)
    {
        Debug.Log("You lose! " + computerChoice + " beats " + playerChoice);
    }
}
