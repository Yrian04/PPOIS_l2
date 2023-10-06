using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PPOIS_l2.Tests")]
namespace PPOIS_l2
{
    internal class Mailbox
    {
        private List<Letter> letters;

        public Mailbox() => letters = new List<Letter>();

        public Mailbox(params Letter[] letters) => this.letters = new(letters);

        public Letter? GetLetter(int index)
        {
            if (IsEmpty())
            {
                return null;
            }
            if (index >= letters.Count)
                throw new ArgumentOutOfRangeException();

            return letters[index];
        }
        public Letter[] GetLetter(int s, int e)
        {
            if (s > e)
                throw new Exception("End index less than start index");
            if (s < 0 || s > Count() || e < 0 || e > Count())
                throw new IndexOutOfRangeException();

            return letters.GetRange(s, e - s + 1).ToArray();
        }
        public Letter[] GetAllLetters()
        {
            return GetLetter(0, Count());
        }

        public bool IsEmpty() => letters.Count == 0;
        public int Count() => letters.Count;

        public void AddLetter(Letter letter) => letters.Add(letter);
        public void AddLetter(IEnumerable<Letter> letters) => this.letters.AddRange(letters);
        public void RemoveLetter(int index) => letters.RemoveAt(index);
        public void RemoveLetters(int start, int end) => letters.RemoveRange(start, end - start);
    }
}
