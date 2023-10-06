namespace PPOIS_l2
{
    public interface ILetterEditor
    {
        public Letter Create(Client sender, Client receiver);
        public void Edit(ref Letter letter);
    }
}
