using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace Amazon
{
  public class NonBinaryTreeNode<T> where T:class
  {
    public NonBinaryTreeNode(T value)
    {
      Value = value;
      this.Children = new List<NonBinaryTreeNode<T>>();
    }
    public T Value { get; }
    public List<NonBinaryTreeNode<T>> Children{ get; private set; }
    public void AddChild (NonBinaryTreeNode<T> value)
    {
      this.Children.Add(value);
    }
    public int NoOfPeopleReportingToPerson(T value)
    {
      if(this.Value==value)
      {
        var count=this.Children.Count();
        foreach (var counter in this.Children)
        {
          count = count+NumberOfChildren(counter);
        }
        return count;
      }
      var child = this.Children.Where(x => x.Value == value).FirstOrDefault();
      return child==null?-1:child.Children.SelectMany(x => x.Children).Count();
    }
    public int NumberOfChildren(NonBinaryTreeNode<T> child)
    {
      if(child.Children==default)
      {
        return 0;
      }
      var count = 0;
      foreach (var counter in child.Children)
      {
        count = count + NumberOfChildren(counter);
      }
      return count;
    }
  }
  
  public class NoOfPeopleReportingToPerson_Test
  {
    /*
                      Alice
                  Bob       Erin
          Chuck
    David       Faith
    */
    [Fact]
    public void Test1()
    {
      var alice = new NonBinaryTreeNode<string>("Alice");
      var bob = new NonBinaryTreeNode<string>("Bob");
      var erin = new NonBinaryTreeNode<string>("Erin");
      var chuck= new NonBinaryTreeNode<string>("Chuck");
      var david= new NonBinaryTreeNode<string>("David");
      var faith= new NonBinaryTreeNode<string>("Faith");
      
      alice.AddChild(bob);
      alice.AddChild(erin);
      bob.AddChild(chuck);
      chuck.AddChild(david);
      chuck.AddChild(faith);

      alice.NoOfPeopleReportingToPerson("Alice").Should().Be(5);
      alice.NoOfPeopleReportingToPerson("Bob").Should().Be(3);
      alice.NoOfPeopleReportingToPerson("David").Should().Be(0);
      alice.NoOfPeopleReportingToPerson("Champa").Should().Be(-1);
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
