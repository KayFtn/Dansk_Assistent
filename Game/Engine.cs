using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO.Pipes;

public class Engine {

    InputValidation Validator = new();

    public Engine(){

    }

    public async Task Run()
    {
        //First, prompt user for desired category and direction
        string UserChoice = GetCategory();
        SupportedDirections Direction = GetDirection();

        //Generate list to prompt according to 2 previous elements
        List<Word> WordList = await GenerateWordList(UserChoice);

        Questions Game = new(WordList, Direction);
        Game.StartGame();

        Console.ReadLine();
    }

    private async Task<List<Word>> GenerateWordList(string UserChoice)
    {
        WordsFormatting WordFormat = new();

        List<Word> WordList = await WordFormat.GetWordList(UserChoice);
        return WordList;
    }

    private SupportedDirections GetDirection()
    {
        string Direction = Validator.ValidateDirectionChoice();

        Console.Clear();
        string SelectConfirmation = $"You have chosen the {Direction} direction.";

        Console.WriteLine(SelectConfirmation);
        Thread.Sleep(2000);
        Console.Clear();

        Enum.TryParse(Direction, out SupportedDirections EnumDirection);

        return EnumDirection;
    }

    private string GetCategory()
    {
        string UserChoice = Validator.ValidateCategoryChoice();

        Console.Clear();
        string SelectConfirmation = $"You have chosen {UserChoice}.";

        Console.WriteLine(SelectConfirmation);
        Thread.Sleep(2000);
        Console.Clear();

        return UserChoice;
    }

    public static void WriteIntroduction()
    {
        Console.WriteLine(IntroductionChatPrompts.WELCOME);
        Console.WriteLine(IntroductionChatPrompts.WORD_CATEGORIES);
    }
}