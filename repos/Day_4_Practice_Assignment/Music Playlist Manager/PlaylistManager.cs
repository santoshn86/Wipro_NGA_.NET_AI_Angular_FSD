using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Playlist_Manager
{
    internal class PlaylistManager
    {
        // LinkedList for playlist
        private LinkedList<string> playlist = new LinkedList<string>();

        // SortedList for rating → song
        private SortedList<int, string> ratingMap = new SortedList<int, string>();

        // SortedDictionary for artist → song
        private SortedDictionary<string, string> artistMap = new SortedDictionary<string, string>();

        // Add song to playlist
        public void AddSong(string song)
        {
            playlist.AddLast(song);
            Console.WriteLine($"Song added to playlist: {song}");
        }

        // Remove song
        public void RemoveSong(string song)
        {
            if (playlist.Remove(song))
                Console.WriteLine($"Song removed: {song}");
            else
                Console.WriteLine($"Song not found: {song}");
        }

        // Insert song at beginning
        public void AddSongAtStart(string song)
        {
            playlist.AddFirst(song);
            Console.WriteLine($"Song added at beginning: {song}");
        }

        // Add rating
        public void AddSongRating(int rating, string song)
        {
            ratingMap[rating] = song; // auto-sorted
            Console.WriteLine($"Song '{song}' added with rating {rating}");
        }

        // Add artist mapping
        public void AddArtistSong(string artist, string song)
        {
            artistMap[artist] = song;
            Console.WriteLine($"Artist '{artist}' → Song '{song}' added");
        }

        // Display playlist
        public void ShowPlaylist()
        {
            Console.WriteLine("\nPlaylist:");
            foreach (var song in playlist)
            {
                Console.WriteLine(song);
            }
        }

        // Show songs sorted by rating
        public void ShowSongsByRating()
        {
            Console.WriteLine("\nSongs Sorted by Rating:");
            foreach (var item in ratingMap)
            {
                Console.WriteLine($"Rating {item.Key} → {item.Value}");
            }
        }

        // Show songs sorted by artist
        public void ShowSongsByArtist()
        {
            Console.WriteLine("\nSongs Sorted by Artist:");
            foreach (var item in artistMap)
            {
                Console.WriteLine($"{item.Key} → {item.Value}");
            }
        }
    }
}
