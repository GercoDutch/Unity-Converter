using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConvertionCalculator : MonoBehaviour
{
    //Here Im defining all the elements Ill be using in the script
    //Input will be the intiger Im converting to hex/Binary/Octal/Decimal
    //I have to add that to use input fields (or to display text overall) Unity can only use strings
    //This means I have to convert string to int and back into strings when I want to display them in the output field
    //Outside of this unity-related exception, the entire transition is done without built in functions

    [SerializeField] private int input;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_InputField outputField;

    //creating the Convert to Binary function
    public void ConvertBinary()
    {
        
        //I have to turn the inputfield into a int to start manually converting to binary from int, the inputfield text gives a string by default.
        input = int.Parse(inputField.text);

        //I make a list to save every individual digit of the binary translation
        List<int> binaryList = new();

        //To calculate binary, you modulo your intiger by 2, the remaining 0 or 1 will be ur digit of pie
        //After this, you cut the number in half
        //this acts as the reverse to the fact that every digit of a binary code is double the value the further you move to the left
        //an intiger will always be rounded downwards, which is necessarry after dividing by 2, because if  the result ends in .5, the math doesn't work correctly
        //after this 2 step process it will restart, until the remainder is 0, which happens once 1 gets divided by 2.
        while (input > 0)
        {
            binaryList.Add(input%2);
            input = input/2;
        }
        //creating an empty string, because its the only way to put it back into the output.
        string output = "";

        //Placing all the 1s and 0s back to back. Putting the new one on the left side, otherwise it will be written the wrong way around
        for (int i = 0; i < binaryList.Count; i++)
        {
            output = binaryList[i] + output;
        }
        //Debugging the output and placing into the output field
        Debug.Log(output);
        outputField.text = output;
    }

    public void ConvertOctal()
    {
        //Octal conversion works identical to binary with the exception of modulo and division by 8 instead
        //This is because binary only has 2 values (0 and 1) while Octal has 8 unique values (0-7)

        input = int.Parse(inputField.text);
        List<int> binaryList = new();
        while (input > 0)
        {
            binaryList.Add(input % 8);
            input = input / 8;
        }

        string output = "";

        for (int i = 0; i < binaryList.Count; i++)
        {
            output = binaryList[i] + output;
        }
        Debug.Log(output);
        outputField.text = output;
    }

    public void ConvertHex()
    {
        //Hex is again identical to the previous 2, with the exception that modulo and divison is by 16
        //However, hex expressed number 10-15 as A/B/C/D/E/F, Ill get to that below
        input = int.Parse(inputField.text);
        List<int> binaryList = new();
        while (input > 0)
        {
            binaryList.Add(input % 16);
            input = input / 16;
        }
        string output = "";

        for (int i = 0; i < binaryList.Count; i++)
        {
            //Here, we check if the digit is above 10, because digits above 10 are written with the letters instead
            //For every digit it will place its corresponding letter into the output
            if (binaryList[i] >= 10)
            {
                if(binaryList[i] == 10) output = "A" + output;
                if (binaryList[i] == 11) output = "B" + output;
                if (binaryList[i] == 12) output = "C" + output;
                if (binaryList[i] == 13) output = "D" + output;
                if (binaryList[i] == 14) output = "E" + output;
                if (binaryList[i] == 15) output = "F" + output;
            }
            //if the digit isnt above 10, it can place it the way it usually does.
            else output = binaryList[i] + output;
        }
        Debug.Log(output);
        outputField.text = output;
    }

    public void ConvertDecimal()
    {
        //I didnt quite figure out what to do by turning an int into a decimal, Im not quite sure if this is something thats supposed to only apply to c++
        //if my assumption is correct and this is a c++ thing Ill be sure to ask about that if I make the internship

        //getting the inputfield as an int
        input = int.Parse(inputField.text);

        //turning the int into a decimal
        decimal d = input;

        //turning the decimal back into a string, printing .00 like a decimal numbers.
        outputField.text = d.ToString() +".00";
    }
}
