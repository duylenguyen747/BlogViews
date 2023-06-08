namespace BlogViews.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string Thumb { get; set; }
        public bool Published { get; set; }
        public string Metatitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKey { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedDate { get; set; }
        public Account Account { get; set; }
        public string ShortContent { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public Category Categories { get; set; }
        public bool isHot { get; set; }
        public bool isNewFeed { get; set; }
    }
}