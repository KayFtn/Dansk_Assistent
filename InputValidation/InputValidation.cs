public class InputValidation
{
    public InputValidation(){
    }

    public string ValidateCategoryChoice()
    {
        bool ValidInput = false;
        string UserChoice = "";

        do
        {
            Console.Clear();
            Engine.WriteIntroduction();
            ValidInput = ParseCategoryChoice(Console.ReadLine(), out int OutUserChoice);
            
            if (!ValidInput){
                Console.Clear();
            }
            else{
                UserChoice = Enum.GetName(typeof(SupportedWordCategories), OutUserChoice);
            }
        } while(!ValidInput);

        return UserChoice;
    }

    private bool ParseCategoryChoice(string Input, out int UserChoice)
    {
        UserChoice = 0;

        if (!int.TryParse(Input, out int intInput))
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please answer with the number corresponding to the desired word category.\nPress Enter to try again.");
            Console.ReadKey();
            return false;
        }
        else{
            UserChoice = intInput;
            return true;
        }
    }

    public string ValidateDirectionChoice()
    {

        bool ValidInput = false;
        string Direction = "";

        do
        {
            Console.Clear();
            Console.WriteLine("Do you wish to go from:\n1. English to Danish\nor\n2. Danish to English");
            ValidInput = ParseDirectionChoice(Console.ReadLine(), out string OutUserChoice);
            
            if (!ValidInput){
                Console.Clear();
            }
            else{
                Direction = OutUserChoice;
            }
        } while(!ValidInput);

        return Direction;
    }

    private bool ParseDirectionChoice(string Input, out string Direction)
    {
        Direction = "";

        if (!int.TryParse(Input, out int intDirection))
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please answer with the number corresponding to the desired direction.\nPress Enter to try again.");
            Console.ReadKey();
            return false;
        }
        else{
            Direction = Enum.GetName(typeof(SupportedDirections), Convert.ToInt32(Input));
            return true;
        }
    }
}