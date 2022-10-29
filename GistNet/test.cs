using System.Text.Json.Serialization;

namespace GistNet
{
    public class Root
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("forks_url")]
        public string ForksUrl { get; set; } = string.Empty;

        [JsonPropertyName("commits_url")]
        public string CommitsUrl { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; } = string.Empty;

        [JsonPropertyName("git_pull_url")]
        public string GitPullUrl { get; set; } = string.Empty;

        [JsonPropertyName("git_push_url")]
        public string GitPushUrl { get; set; } = string.Empty;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = string.Empty;

        [JsonPropertyName("files")]
        public List<Files> Files { get; set; } = new();

        [JsonPropertyName("public")]
        public bool Public { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("comments")]
        public int Comments { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; } = new();

        [JsonPropertyName("comments_url")]
        public string CommentsUrl { get; set; } = string.Empty;

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; } = new();

        [JsonPropertyName("forks")]
        public List<Forks> Forks { get; set; } = new();

        [JsonPropertyName("history")]
        public List<History> History { get; set; } = new();

        [JsonPropertyName("truncated")]
        public bool Truncated { get; set; }
    }


    public class User
    {
        [JsonPropertyName("login")]
        public string Login { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; } = string.Empty;

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; } = string.Empty;

        [JsonPropertyName("gravatar_id")]
        public string GravatarId { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = string.Empty;

        [JsonPropertyName("followers_url")]
        public string FollowersUrl { get; set; } = string.Empty;

        [JsonPropertyName("following_url")]
        public string FollowingUrl { get; set; } = string.Empty;

        [JsonPropertyName("gists_url")]
        public string GistsUrl { get; set; } = string.Empty;

        [JsonPropertyName("starred_url")]
        public string StarredUrl { get; set; } = string.Empty;

        [JsonPropertyName("subscriptions_url")]
        public string SubscriptionsUrl { get; set; } = string.Empty;

        [JsonPropertyName("organizations_url")]
        public string OrganizationsUrl { get; set; } = string.Empty;

        [JsonPropertyName("repos_url")]
        public string ReposUrl { get; set; } = string.Empty;

        [JsonPropertyName("events_url")]
        public string EventsUrl { get; set; } = string.Empty;

        [JsonPropertyName("received_events_url")]
        public string ReceivedEventsUrl { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("site_admin")]
        public bool SiteAdmin { get; set; }
    }

    public class Owner
    {
        [JsonPropertyName("login")]
        public string Login { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; } = string.Empty;

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; } = string.Empty;

        [JsonPropertyName("gravatar_id")]
        public string GravatarId { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = string.Empty;

        [JsonPropertyName("followers_url")]
        public string FollowersUrl { get; set; } = string.Empty;

        [JsonPropertyName("following_url")]
        public string FollowingUrl { get; set; } = string.Empty;

        [JsonPropertyName("gists_url")]
        public string GistsUrl { get; set; } = string.Empty;

        [JsonPropertyName("starred_url")]
        public string StarredUrl { get; set; } = string.Empty;

        [JsonPropertyName("subscriptions_url")]
        public string SubscriptionsUrl { get; set; } = string.Empty;

        [JsonPropertyName("organizations_url")]
        public string OrganizationsUrl { get; set; } = string.Empty;

        [JsonPropertyName("repos_url")]
        public string ReposUrl { get; set; } = string.Empty;

        [JsonPropertyName("events_url")]
        public string EventsUrl { get; set; } = string.Empty;

        [JsonPropertyName("received_events_url")]
        public string ReceivedEventsUrl { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("site_admin")]
        public bool SiteAdmin { get; set; }
    }

    public class Files
    {
        [JsonPropertyName("filename")]
        public string Filename { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("language")]
        public string Language { get; set; } = string.Empty;

        [JsonPropertyName("raw_url")]
        public string RawUrl { get; set; } = string.Empty;

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("truncated")]
        public bool Truncated { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }

    public class History
    {
        [JsonPropertyName("user")]
        public User User { get; set; } = new();

        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;

        [JsonPropertyName("committed_at")]
        public DateTime CommittedAt { get; set; }

        [JsonPropertyName("change_status")]
        public ChangeStatus ChangeStatus { get; set; } = new();

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }

    public class ChangeStatus
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("additions")]
        public int Additions { get; set; }

        [JsonPropertyName("deletions")]
        public int Deletions { get; set; }
    }

    public class Forks
    {

    }

}
