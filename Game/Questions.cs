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
        Console.WriteLine("The game will start in 5 Seconds.\nTry to answer each prompt honestly without cheating!!");  
        Thread.Sleep(5000);

        for(int i = 0; i < WordList.Count; i++)
        {
            Console.Clear();

            Word CurrentWord = WordList[i];
            string CorrectAnswer = "";

            PrepareConsole(i + 1);

            switch(Direction){
                case SupportedDirections.English_To_Danish:
                Console.WriteLine($"Translate the following word to Danish:\n{CurrentWord.Engelsk}");
                CorrectAnswer = CurrentWord.Dansk;
                break;

                case SupportedDirections.Danish_To_English:
                Console.WriteLine($"Translate the following word to English:\n{CurrentWord.Dansk}");
                CorrectAnswer = CurrentWord.Engelsk;
                break;
            }
            AddStarLine();

            //now need to validate input and display result prompt
            string Answer = Console.ReadLine();
            string QuestionWord = (Direction == SupportedDirections.English_To_Danish) ? CurrentWord.Engelsk : CurrentWord.Dansk;

            if (Answer.ToLower() == CorrectAnswer.ToLower())
                RightAnswerResult(CorrectAnswer, QuestionWord, Answer);
            else
                WrongAnswerResult(CorrectAnswer, QuestionWord, Answer);
                

        }
            //Need to handle end of list behavior 
    } 

    private void RightAnswerResult(string CorrectAnswer, string QuestionWord, string Answer)
    {
        Console.Clear();
        Console.WriteLine($"Correct! You Answered: '{Answer}'\nThe answer for '{QuestionWord}' was indeed: '{CorrectAnswer}'");
        Console.WriteLine("Hit enter for the next prompt.");
        Console.ReadLine();
    }

       private void WrongAnswerResult(string CorrectAnswer, string QuestionWord, string Answer)
    {
        Console.Clear();
        Console.WriteLine($"Wrong! You Answered: '{Answer}'\nThe correct answer for '{QuestionWord}' was: '{CorrectAnswer}'");
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