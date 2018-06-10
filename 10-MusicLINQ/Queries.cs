using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace MusicLINQ {

  public class Queries {

    public static void SearchArtists() {
      List<Artist> artists = JsonToFile<Artist>.ReadJson();
      List<Group> groups = JsonToFile<Group>.ReadJson();
      ArtistFromMtVernon(artists);
      YoungestArtists(artists);
      AllWilliams(artists);
      OldestFromATL(artists);
      GroupsNotFromNY(artists, groups);
      WuTangClan(artists, groups);
    }

    // Display the name and age of the artist from Mount Vernon
    static void ArtistFromMtVernon(List<Artist> artists) {
      var artist = artists.Where(a => a.Hometown == "Mount Vernon").First();
      Console.WriteLine($"{artist.ArtistName}: {artist.RealName}, age {artist.Age}");
    }

    // Display the 3 youngest artists
    static void YoungestArtists(List<Artist> artists) {
      var sorted = artists.OrderBy(a => a.Age).ToList();
      Console.WriteLine($"{sorted[0].ArtistName}, age {sorted[0].Age}");
      Console.WriteLine($"{sorted[1].ArtistName}, age {sorted[1].Age}");
      Console.WriteLine($"{sorted[2].ArtistName}, age {sorted[2].Age}");
    }

    // Display all artists with 'William' in their real name
    static void AllWilliams(List<Artist> artists) {
      var williamses = artists.Where(a => a.RealName.Contains("William")).ToList();
      foreach (var artist in williamses) Console.WriteLine($"{artist.RealName}");
    }

    // Display the 3 oldest artists from Atlanta
    static void OldestFromATL(List<Artist> artists) {
      var elders = artists
        .Where(a => a.Hometown == "Atlanta")
        .OrderByDescending(a => a.Age)
        .ToList();
      Console.WriteLine($"{elders[0].ArtistName}, from {elders[0].Hometown}, age {elders[0].Age}");
      Console.WriteLine($"{elders[1].ArtistName}, from {elders[1].Hometown}, age {elders[1].Age}");
      Console.WriteLine($"{elders[2].ArtistName}, from {elders[2].Hometown}, age {elders[2].Age}");
    }

    // Display all groups with members not from New York City
    static void GroupsNotFromNY(List<Artist> artists, List<Group> groups) {
      var groupIds = artists
        .Where(a => a.Hometown != "New York City")
        .GroupBy(a => a.GroupId)
        .ToList();
      var notFromNY = groupIds.Join(groups,
        g1 => g1.Key,
        g2 => g2.Id,
        (g1, g2) => g2.GroupName
      );
      foreach (var group in notFromNY)
        Console.WriteLine(group);
    }

    // Display all members of the Wu-Tang Clan
    static void WuTangClan(List<Artist> artists, List<Group> groups) {
      var wuTangId = groups.Where(g => g.GroupName == "Wu-Tang Clan").First().Id;
      var members = artists.Where(a => a.GroupId == wuTangId);
      foreach (var member in members) Console.WriteLine(member.ArtistName);
    }

  }

}