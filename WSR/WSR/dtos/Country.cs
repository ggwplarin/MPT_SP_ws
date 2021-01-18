namespace WSR.dtos
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Country()
        {
        }

        public Country(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}