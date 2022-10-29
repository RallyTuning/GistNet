namespace GistNet
{
    public class Gist
    {
        public string URL { get; set; } = String.Empty;
        public string Forks_URL { get; set; } = String.Empty;
        public string Commits_URL { get; set; } = String.Empty;
        public string ID { get; set; } = String.Empty;
        public string Node_ID { get; set; } = String.Empty;
        public string Git_Pull_URL { get; set; } = String.Empty;
        public string Git_Push_URL { get; set; } = String.Empty;
        public string HTML_URL { get; set; } = String.Empty;
        public Files Files { get; set; } = new();
        public bool Public { get; set; } = false;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime Updated_at { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = String.Empty;
        public int Comments { get; set; } = 0;
        public string User { get; set; } = String.Empty;
        public string Comments_URL { get; set; } = String.Empty;
        public Owner Owner { get; set; } = new();
        public bool Truncated { get; set; } = false;
    }

    public class Files
    {
        public string Filename { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string Language { get; set; } = String.Empty;
        public string Raw_URL { get; set; } = String.Empty;
        public string Size { get; set; } = String.Empty;
    }

    public class Owner 
    {
        public string Login { get; set; } = String.Empty;
        public int ID { get; set; } = 0;
        public string Node_ID { get; set; } = String.Empty;
        public string Avatar_URL { get; set; } = String.Empty;
        public string Gravatar_ID { get; set; } = String.Empty;
        public string URL { get; set; } = String.Empty;
        public string HTML_URL { get; set; } = String.Empty;
        public string Followers_URL { get; set; } = String.Empty;
        public string Following_URL { get; set; } = String.Empty;
        public string Gists_URL { get; set; } = String.Empty;
        public string Starred_URL { get; set; } = String.Empty;
        public string Subscriptions_URL { get; set; } = String.Empty;
        public string Organizations_URL { get; set; } = String.Empty;
        public string Repos_URL { get; set; } = String.Empty;
        public string Events_URL { get; set; } = String.Empty;
        public string Received_Events_URL { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public bool Site_Admin { get; set; } = false;
    }
}
