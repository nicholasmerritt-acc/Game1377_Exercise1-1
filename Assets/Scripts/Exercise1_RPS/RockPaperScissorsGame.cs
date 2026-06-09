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
 *    - Rock beats Scissors and Lizard
 *    - Paper beats Rock and Spock
 *    - Scissors beats Paper and Lizard
 *    - Lizard beats Paper and Spock
 *    - Spock beats Scissors and Rock
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
public enum RPSChoices
{
    Invalid,    //0
    Rock,       //1
    Paper,      //2
    Scissors,   //3
    Lizard,     //4
    Spock       //5
}

public class RockPaperScissorsGame : MonoBehaviour
{

    //get an array of all values in the choices enum
    private RPSChoices[] choices = (RPSChoices[])Enum.GetValues(typeof(RPSChoices));

    public void RockPaperScissors(int inputChoice)
    {
        if (inputChoice <= 0 || inputChoice > (choices.Length - 1))
        {
            Debug.LogError("Invalid enum choice. Somehow we got an int that is not in our enum");
        }

        //we need to cast from an int because Unity won't let us use a custom enum as a parameter and have it show up in the inspector :(
        RPSChoices playerChoice = (RPSChoices)inputChoice;

        Debug.Log("You chose: " + playerChoice);

        //choose a random choice from our enum
        RPSChoices computerChoice = choices[UnityEngine.Random.Range(1, choices.Length)];
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
                case RPSChoices.Rock:
                    CheckWin(playerChoice, computerChoice, RPSChoices.Scissors, RPSChoices.Lizard);
                    break;
                //Paper beats Rock and Spock
                case RPSChoices.Paper:
                    CheckWin(playerChoice, computerChoice, RPSChoices.Rock, RPSChoices.Spock);
                    break;
                //Scissors beats Paper and Lizard
                case RPSChoices.Scissors:
                    CheckWin(playerChoice, computerChoice, RPSChoices.Paper, RPSChoices.Lizard);
                    break;
                //Lizard beats Paper and Spock
                case RPSChoices.Lizard:
                    CheckWin(playerChoice, computerChoice, RPSChoices.Paper, RPSChoices.Spock);
                    break;
                //Spock beats Scissors and Rock
                case RPSChoices.Spock:
                    CheckWin(playerChoice, computerChoice, RPSChoices.Scissors, RPSChoices.Rock);
                    break;
            }
        }
    }

    //check if the player choice beats the computer choice
    //beats1 and beats2 are the choices that lose to the given player choice
    public void CheckWin(RPSChoices playerChoice, RPSChoices computerChoice, RPSChoices beats1, RPSChoices beats2)
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

    //display win message
    public void Win(RPSChoices playerChoice, RPSChoices computerChoice)
    {
        Debug.Log("You win! " + playerChoice + " beats " + computerChoice);
    }

    //display lose message
    public void Lose(RPSChoices playerChoice, RPSChoices computerChoice)
    {
        Debug.Log("You lose! " + computerChoice + " beats " + playerChoice);
    }
}
