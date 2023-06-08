namespace BlogViews.Models
{
    public class Category
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string title { get; set; }
        public string Alias { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKey { get; set; }
        public string Thumb { get; set; }
        public bool Published { get; set; }
        public int Ordering { get; set; }
        public int Parents { get; set; }
        public int Levels { get; set; }
        public string Cover { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}