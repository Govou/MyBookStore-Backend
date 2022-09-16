namespace MyBookStore.Domain.Entities.Validators.Entities.ValueObjects
{
    public class Publication
    {
        public int Edition { get;  set; }
        public int Year { get;  set; }

        public Publication(int edition, int year)
        {
            Edition = edition;
            Year = year;
        }
    }
}
