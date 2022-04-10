using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
  public class FavouriteGenres_Amazon
  {
    [Fact]
    public void Test1()
    {
      var userSongs = new Dictionary<string, List<string>>
      {
        {"David",new List<string>{"song1","song2","song3","song4","song8"}},
        {"Emma",new List<string>{"song5","song6","song7"}}
      };
      var genreSongs = new Dictionary<string, List<string>>
      {
        { "Rock",new List<string> {"song1", "song3" } },
        { "Dubstep", new List<string> {"song7" } },
        { "Techno", new List<string> {"song2", "song4" } },
        { "Pop", new List<string> {"song5", "song6" } },
        { "Jazz", new List<string> {"song8", "song9" } }
      };
      var output = new Dictionary<string, List<string>>
      {
        { "David", new List<string> { "Rock", "Techno" } },
        { "Emma", new List<string> { "Pop" } }
      };
      var result = Get(userSongs, genreSongs);
      Assert.True(output["David"].SequenceEqual(result["David"]));
      Assert.True(output["Emma"].SequenceEqual(result["Emma"]));
    }
    [Fact]
    public void Test2()
    {
      var userSongs = new Dictionary<string, List<string>>
      {
        { "David",new List<string> {"song1","song2"}},
        {"Emma",new List<string> {"song3","song4"}}
      };
      var songGenres = new Dictionary<string, List<string>>();
      var output = new Dictionary<string, List<string>>
      {
        { "David", new List<string> {} },
        { "Emma", new List<string> {} }
      };
      var result = Get(userSongs, songGenres);
      Assert.True(output["David"].SequenceEqual(result["David"]));
      Assert.True(output["Emma"].SequenceEqual(result["Emma"]));
    }

    /*Given a map Map<String, List<String>> userSongs with user names as keys and a list of all the songs that the user has listened to as values.
    Also given a map Map<String, List<String>> songGenres, with song genre as keys and a list of all the songs within that genre as values. 
    The song can only belong to only one genre.
    The task is to return a map Map<String, List<String>>, where the key is a user name and the value is a list of the user's favorite genre(s). 
    Favorite genre is the most listened to genre. A user can have more than one favorite genre if he/she has listened to the same number of songs per 
    each of the genres.*/
    public Dictionary<string, List<string>> Get(Dictionary<string, List<string>> userSongs, Dictionary<string, List<string>> genreSongs)
    {
      //create songGenre dictonary for song and song genre.
      //create GenreCount dictonary which has song genre, count-for each user
      var result = new Dictionary<string, List<string>>(); 
      if (userSongs?.Count == 0)
      {
        return result;
      }
      
      foreach (var userSong in userSongs)
      {
        result.Add(userSong.Key, new List<string>());
      }

      if (genreSongs?.Count==0)
      {
        return result;
      }

      var songGenres = new Dictionary<string, string>();
      foreach(var genreSong in genreSongs)
      {
        var genre = genreSong.Key;
        var songs=genreSong.Value;
        foreach (var song in songs)
        {
          if (songGenres.ContainsKey(song) == false)
          {
            songGenres.Add(song, genre);
          }
        }
      }

      foreach (var userSong in userSongs)
      {
        var user = userSong.Key;
        var userSongsTemp=userSong.Value;
        var userGenresCount = new Dictionary<string, int>();
        int maxCountForGenre = 0;
        foreach (var userSongTemp in userSongsTemp)
        {
          var genre = songGenres[userSongTemp];
          if (userGenresCount.ContainsKey(genre) == false)
          {
            userGenresCount.Add(genre, 1);
          }
          else
          {
            userGenresCount[genre]++;
            maxCountForGenre = Math.Max(maxCountForGenre, userGenresCount[genre]);
          }
        }

        foreach (var userGenreCount in userGenresCount)
        {
          if (userGenreCount.Value == maxCountForGenre)
          {
            result[user].Add(userGenreCount.Key);
          }
        }
      }
      return result;
    }
  }
}
