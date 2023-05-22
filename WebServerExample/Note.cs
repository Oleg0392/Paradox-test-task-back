namespace WebServerExample
{
    public class Note
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Raw { get; set; } 
        
        public Note(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
