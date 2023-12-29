using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class WordsFormatting
{
    
    public WordsFormatting(){

    }

    public async Task<List<Word>> GetWordList(string Category)
    {
        JArray FileContent = await GetFileContent(Category);

        List<Word> Words = new List<Word>();
        Words = FileContent.ToObject<List<Word>>();
        Shuffle(Words);

        return Words;
    }

    private void Shuffle(List<Word> WordList){
        Random _random = new Random();

        int n = WordList.Count;

        for(int i = 0; i < n-1; i++)
        {
            int r = i + _random.Next(n - i);
            Word word = WordList[r];
            WordList[r] = WordList[i];
            WordList[i] = word;
        }
    }

    private async Task<JArray> GetFileContent(string Category)
    {
        string DebugDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDirectory = Directory.GetParent(DebugDir).Parent.Parent.Parent.FullName;
        string Path = $"{projectDirectory}/Data/{Category}/{Category}.json";


        string FileContent = "";

        using(StreamReader r = new StreamReader(Path)){
            FileContent = r.ReadToEnd();
        }

        JArray JAFileContent = JArray.Parse(FileContent);

        return JAFileContent;
    }
}