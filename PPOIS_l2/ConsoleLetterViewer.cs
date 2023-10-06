namespace PPOIS_l2
{
    public class ConsoleLetterViewer : ILetterViewer
    {
        public void ViewLetters(params Letter[] letters)
        {
            if(letters.Length == 0)
            {
                Console.WriteLine("There are no letters(");
                return;
            }
            for (int i = 0; i < letters.Length; i++)
            {
                Console.WriteLine($"============== {i+1} ==============");
                ViewLetter(letters[i]);
            }
        }
        private void ViewLetter(Letter letter)
        {
            Console.WriteLine($"\t{letter.Header}");
            Console.WriteLine(letter.Body);
            Console.WriteLine($"\tFrom: {letter.Sender.Name}");
            Console.WriteLine($"\tTo: {letter.Receiver.Name}");
        }
    }
}
