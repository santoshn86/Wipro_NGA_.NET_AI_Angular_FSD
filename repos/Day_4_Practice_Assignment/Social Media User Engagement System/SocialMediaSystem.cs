using System;
using System.Collections.Generic;
using System.Text;

namespace Social_Media_User_Engagement_System
{
    internal class SocialMediaSystem
    {
        // List to store posts
        private List<string> posts = new List<string>();

        // Dictionary to store likes per post
        private Dictionary<string, int> likes = new Dictionary<string, int>();

        // HashSet for unique users
        private HashSet<int> users = new HashSet<int>();

        // Stack for undo functionality
        private Stack<string> actions = new Stack<string>();

        // Queue for notifications
        private Queue<string> notifications = new Queue<string>();

        // Add User
        public void AddUser(int userId)
        {
            if (users.Add(userId))
                Console.WriteLine($"User {userId} added.");
            else
                Console.WriteLine($"User {userId} already exists.");
        }

        // Add Post
        public void AddPost(string post)
        {
            posts.Add(post);
            likes[post] = 0;
            actions.Push($"PostAdded:{post}");
            notifications.Enqueue($"New post added: {post}");

            Console.WriteLine($"Post added: {post}");
        }

        // Like Post
        public void LikePost(string post)
        {
            if (likes.ContainsKey(post))
            {
                likes[post]++;
                actions.Push($"PostLiked:{post}");
                notifications.Enqueue($"Post liked: {post}");

                Console.WriteLine($"Post liked: {post} (Total Likes: {likes[post]})");
            }
        }

        // Undo last action
        public void Undo()
        {
            if (actions.Count == 0)
            {
                Console.WriteLine("No actions to undo.");
                return;
            }

            string lastAction = actions.Pop();
            string[] parts = lastAction.Split(':');

            if (parts[0] == "PostAdded")
            {
                posts.Remove(parts[1]);
                likes.Remove(parts[1]);
                Console.WriteLine($"Undo: Removed post {parts[1]}");
            }
            else if (parts[0] == "PostLiked")
            {
                likes[parts[1]]--;
                Console.WriteLine($"Undo: Removed like from {parts[1]}");
            }
        }

        // Process Notifications (FIFO)
        public void ProcessNotifications()
        {
            Console.WriteLine("\nProcessing Notifications:");
            while (notifications.Count > 0)
            {
                Console.WriteLine(notifications.Dequeue());
            }
        }

        // Display Posts & Likes
        public void ShowPosts()
        {
            Console.WriteLine("\nPosts and Likes:");
            foreach (var post in posts)
            {
                Console.WriteLine($"{post} → Likes: {likes[post]}");
            }
        }
    }
}
