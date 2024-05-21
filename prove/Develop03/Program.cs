public class Program
{
    static void Main(string[] args)
    {
        var reference = new ScriptureReference("Proverbs", 3, 5, 6);
        var text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        var scripture = new Scripture(reference, text);

        while (true)
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (input?.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine("All words are hidden. You have successfully memorized the scripture!");
                Console.WriteLine(reference);
                break;
            }
        }
    }
}