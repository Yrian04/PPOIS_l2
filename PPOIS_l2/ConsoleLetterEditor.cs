namespace PPOIS_l2
{
    public class ConsoleLetterEditor : ILetterEditor
    {
        public virtual Letter Create(Client sender ,Client receiver)
        {
            Console.WriteLine("Type letter header: ");
            string header = Console.ReadLine() ?? "Header";

            string? body;
            do
            {
                Console.WriteLine("Type letter body: ");
                body = Console.ReadLine();
            } while (body is null);

            return new Letter(sender, receiver, header, body);
        }

        public void Edit(ref Letter letter)
        {
            Console.WriteLine($"Old header: {letter.Header}\r\nType new: ");
            string? header = Console.ReadLine();
            while(header is null)
            {
                Console.WriteLine("Type new: ");
                header = Console.ReadLine();
            }
            letter.Header = header;


            Console.WriteLine($"Old body: {letter.Body}\r\nType new: ");
            string? body = Console.ReadLine();
            while (body is null)
            {
                Console.WriteLine("Type new: ");
                body = Console.ReadLine();
            }
            letter.Body = body;

            Logger.Instance?.LogLetterEdited(letter);
        }
    }
}
