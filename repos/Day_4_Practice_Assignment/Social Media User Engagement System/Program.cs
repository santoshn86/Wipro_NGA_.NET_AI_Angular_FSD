namespace Social_Media_User_Engagement_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SocialMediaSystem system = new SocialMediaSystem();

            // User 1 added.
            system.AddUser(1);
            // User 2 added.
            system.AddUser(2);
            // User 1 already exists.
            system.AddUser(1);

            // Post added: Hello World!
            system.AddPost("Hello World!");
            // Post added: AI is amazing
            system.AddPost("AI is amazing");

            // Post liked: Hello World! (Total Likes: 1)
            system.LikePost("Hello World!");
            // Post liked: Hello World! (Total Likes: 2)
            system.LikePost("Hello World!");

            // Posts and Likes:
            system.ShowPosts();

            // Undo: Removed like from Hello World!
            system.Undo();

            // Posts and Likes:
            system.ShowPosts();

            // Processing Notifications:
            system.ProcessNotifications();
        }
    }
}
