public static class IntroductionChatPrompts{
    public const string WELCOME = "Velkommen! Denne er en praksis software at lære dansk sprogen.";
    public const string WORD_CATEGORIES = "Here are the supported word categories:\n1. Verbs\n2. Nouns\n3. Adjectives\n4. Adverbs\nPlease make a selection by entering a number.";

    private static string FormatCategoriesString(){
        List<string> Categories = new List<string>{"Verbs", "Nouns", "Adjectives"};

        string CategoryString = "\n";

        for (int i = 1; i <= Categories.Count; i++){
            CategoryString += $"{i}. {Categories[i]}\n";
        }
        
        return CategoryString;
    }
}