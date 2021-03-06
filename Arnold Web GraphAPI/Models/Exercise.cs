namespace Arnold_Web_GraphAPI.Models
{
    public class Exercise
    {
        public Exercise(string name, string category, bool? compound)
        {
            Name = name;
            Category = category;
            Compound = compound;
        }
        
        public string Name { get; set; }
        public string Category { get; }
        public bool? Compound { get; }
    }
}