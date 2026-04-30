namespace Music_Playlist_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlaylistManager manager = new PlaylistManager();

            // Playlist operations
            manager.AddSong("Song A");
            manager.AddSong("Song B");
            manager.AddSongAtStart("Song Start");
            manager.RemoveSong("Song B");

            // Rating operations
            manager.AddSongRating(5, "Song A");
            manager.AddSongRating(3, "Song C");
            manager.AddSongRating(4, "Song D");

            // Artist mapping
            manager.AddArtistSong("Arijit Singh", "Tum Hi Ho");
            manager.AddArtistSong("Shreya Ghoshal", "Sun Raha Hai");
            manager.AddArtistSong("Atif Aslam", "Jeene Laga Hoon");

            // Display
            manager.ShowPlaylist();
            manager.ShowSongsByRating();
            manager.ShowSongsByArtist();
        }
    }
}
