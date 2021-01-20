namespace WSR.dtos
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Role()
        {
        }
        public Role(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}