using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using StarWars.Core.Models;

namespace StarWars.Data.EntityFramework
{
    public class StarWarsContext : DbContext
    {

        public StarWarsContext()
            : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StarWars;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Episode>().HasKey(c => c.Id);
            modelBuilder.Entity<Episode>().Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // planets
            modelBuilder.Entity<Planet>().HasKey(c => c.Id);
            modelBuilder.Entity<Planet>().Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // characters
            modelBuilder.Entity<Character>().HasKey(c => c.Id);
            modelBuilder.Entity<Character>().Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // characters-friends
            modelBuilder.Entity<CharacterFriend>().HasKey(t => new { t.CharacterId, t.FriendId });

            modelBuilder.Entity<CharacterFriend>()
                .HasRequired(cf => cf.Character)
                .WithMany(c => c.CharacterFriends)
                .HasForeignKey(cf => cf.CharacterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CharacterFriend>()
                .HasRequired(cf => cf.Friend)
                .WithMany(t => t.FriendCharacters)
                .HasForeignKey(cf => cf.FriendId)
                .WillCascadeOnDelete(false);

            // characters-episodes
            modelBuilder.Entity<CharacterEpisode>().HasKey(t => new { t.CharacterId, t.EpisodeId });

            modelBuilder.Entity<CharacterEpisode>()
                .HasRequired(cf => cf.Character)
                .WithMany(c => c.CharacterEpisodes)
                .HasForeignKey(cf => cf.CharacterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CharacterEpisode>()
                .HasRequired(cf => cf.Episode)
                .WithMany(t => t.CharacterEpisodes)
                .HasForeignKey(cf => cf.EpisodeId)
                .WillCascadeOnDelete(false);

            // humans
            modelBuilder.Entity<Human>().HasRequired(h => h.HomePlanet).WithMany(p => p.Humans);
        }

        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterFriend> CharacterFriends { get; set; }
        public virtual DbSet<CharacterEpisode> CharacterEpisodes { get; set; }
        public virtual DbSet<Droid> Droids { get; set; }
        public virtual DbSet<Human> Humans { get; set; }
    }
}