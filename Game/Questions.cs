public class Questions
{
    SupportedDirections Direction;
    List<Word> WordList;

    public Questions(List<Word> _WordList, SupportedDirections _Direction)
    {
        Direction = _Direction;
        WordList = _WordList;
    }

    public void StartGame()
    {
        Console.Clear();
        Console.WriteLine("The game will start in 2 Seconds.");  
        Thread.Sleep(2000);

        for(int i = 0; i < WordList.Count; i++)
        {
            Console.Clear();

            Word CurrentWord = WordList[i];

            PrepareConsole(i + 1);
            string CorrectAnswer = AskQuestion(CurrentWord);
            string Answer = Console.ReadLine();

            Answer = CheckForHint(CurrentWord, Answer);

            string PromptWord = (Direction == SupportedDirections.English_To_Danish) ? CurrentWord.Engelsk : CurrentWord.Dansk;

            if (Answer.ToLower() == CorrectAnswer.ToLower())
                RightAnswerResult(CorrectAnswer, PromptWord, Answer);
            else
                WrongAnswerResult(CorrectAnswer, PromptWord, Answer);
                
        }

        EndGame();
    } 

    private void EndGame(){
        Console.Clear();
        AddStarLine();
        Console.WriteLine("Our list of verbs is over! Good work, and don't give up :)");
        AddStarLine();
    }

    private string CheckForHint(Word CurrentWord, string Answer)
    {
        //If user asks for a hint, display it and catch the new answer
        if (Direction == SupportedDirections.Danish_To_English && Answer.ToLower() == "vink"){
            DisplayHint(CurrentWord, Direction);

            Answer = Console.ReadLine();
        }
        else if (Direction == SupportedDirections.English_To_Danish && Answer.ToLower() == "vink"){
            Console.WriteLine("You cannot ask for a Hint while getting English to Danish prompts. Enter your Answer below:");
            Answer = Console.ReadLine();
        }

        return Answer;
    }

    private string AskQuestion(Word CurrentWord)
    {
        string CorrectAnswer = "";
        switch(Direction){
            case SupportedDirections.English_To_Danish:
            Console.WriteLine($"Translate the following word to Danish:\n{CurrentWord.Engelsk}   {CurrentWord.Details}");
            CorrectAnswer = CurrentWord.Dansk;
            break;

            case SupportedDirections.Danish_To_English:
            Console.WriteLine($"Translate the following word to English:\n{CurrentWord.Dansk}");
            if (!string.IsNullOrEmpty(CurrentWord.Details)) Console.WriteLine($"Details: {CurrentWord.Details}");

            CorrectAnswer = CurrentWord.Engelsk;
            break;
        }

        AddStarLine();

        return CorrectAnswer;
    }

    private void DisplayHint(Word CurrentWord, SupportedDirections Direction){
        Console.Clear();
        AddStarLine();
        Console.WriteLine("HINT");
        AddStarLine();

        if (Direction == SupportedDirections.Danish_To_English)
            Console.WriteLine($"Current Word: {CurrentWord.Dansk}");
        else
            Console.WriteLine($"Current Word: {CurrentWord.Engelsk}");

        Console.WriteLine($"Hint:{CurrentWord.Vink}");
        AddStarLine();
    }

    private void RightAnswerResult(string CorrectAnswer, string QuestionWord, string Answer)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Correct!"); 
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine($"You answered: '{Answer}'\nThe answer for '{QuestionWord}' was indeed: '{CorrectAnswer}'");
        Console.WriteLine("Hit enter for the next prompt.");
        Console.ReadLine();
    }

       private void WrongAnswerResult(string CorrectAnswer, string QuestionWord, string Answer)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Wrong!"); 
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine($"You answered: '{Answer}'\nThe correct answer for '{QuestionWord}' was: '{CorrectAnswer}'");
        Console.WriteLine("Hit enter for the next prompt.");
        Console.ReadLine();
    }

    private void PrepareConsole(int Turn)
    {
        Console.Clear();
        AddStarLine();
        Console.WriteLine($"Turn {Turn}");
        Console.WriteLine($"Here are Danish characters for you to copy paste:    å    ø    æ");
        AddStarLine();
    }

    private void AddStarLine()
    {
        Console.WriteLine("********************************************************************************");
    }

}