using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

public class Engine {

    InputValidation Validator = new();

    public Engine(){

        //First, prompt user for desired category and direction
        string UserChoice = Introduction();
        string Direction = GetDirection();

        //Generate list to prompt according to 2 previous elements
        List<Word> WordList = GenerateWordList(UserChoice, Direction);

        Console.ReadLine();
    }

    private List<Word> GenerateWordList(string UserChoice, string Direction)
    {
        return new List<Word>();
    }

    private string GetDirection()
    {
        string Direction = Validator.ValidateDirectionChoice();

        Console.Clear();
        string SelectConfirmation = $"You have chosen the {Direction} direction.";

        Console.WriteLine(SelectConfirmation);
        Thread.Sleep(2000);
        Console.Clear();

        return Direction;
    }

    private string Introduction()
    {
        int UserChoice = Validator.ValidateCategoryChoice();

        Console.Clear();
        string ChosenCategory = Enum.GetName(typeof(SupportedWordCategories), UserChoice);
        string SelectConfirmation = $"You have chosen {ChosenCategory}.";

        Console.WriteLine(SelectConfirmation);
        Thread.Sleep(2000);
        Console.Clear();

        return ChosenCategory;
    }

    public static void WriteIntroduction()
    {
        Console.WriteLine(IntroductionChatPrompts.WELCOME);
        Console.WriteLine(IntroductionChatPrompts.WORD_CATEGORIES);
    }
}