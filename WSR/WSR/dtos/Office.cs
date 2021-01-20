namespace WSR.dtos
{
    public class Office
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }

        public Office()
        {
        }

        public Office(int id, int countryId, string title, string phone, string contact)
        {
            Id = id;
            CountryId = countryId;
            Title = title;
            Phone = phone;
            Contact = contact;
        }
    }
}