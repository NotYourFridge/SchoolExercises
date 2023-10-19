using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace verhuur
{

   public class Gebruiker
   {
      [Key]
      public int gebruiker_id { get; set; }

      [Required]
      public string gebruiker_naam { get; set; }

      [Required]
      public int gebruiker_telefoonnummer { get; set; }

      [Required]
      public string gebruiker_email { get; set; }


   }

   public class Reservering
   {
      [Key]
      public int reservering_id { get; set; }

      [Required]
      [ForeignKey("auto")]
      public int auto_id { get; set; }
      public Auto auto { get; set; }


      [Required]
      [ForeignKey("gebruiker")]
      public int gebruiker_id { get; set; }
      public Gebruiker gebruiker { get; set; }


      [Required]
      public DateTime begin_tijd { get; set; }

      [Required]
      public int aangegeven_uren { get; set; }

      [NotMapped]
      public DateTime eind_tijd => begin_tijd.AddHours(aangegeven_uren);

   }


   public class Auto
   {
      [Key]
      public int auto_id { get; set; }

      [Required]
      public string auto_merk { get; set; }
   }



   public class Verhuurder : Gebruiker
   {

      [Key]
      public int verhuurder_id { get; set; }

      [Required]
      [ForeignKey("gebruiker")]
      public int user_id { get; set; }
      public Gebruiker gebruiker { get; set; }

      [Required]
      public string adres { get; set; }

   }




   public class Huurder : Gebruiker
   {

      [Key]
      public int huurder_id { get; set; }

      [Required]
      [ForeignKey("gebruiker")]
      public int user_id { get; set; }
      public Gebruiker gebruiker { get; set; }

      public string adres { get; set; }

   }




   public class VerhuurContext : DbContext
   {

      public DbSet<Gebruiker> gebruikers { get; set; }
      public DbSet<Verhuurder> verhuurders { get; set; }
      public DbSet<Huurder> huurders { get; set; }
      public DbSet<Auto> autos { get; set; }
      public DbSet<Reservering> reserveringen { get; set; }


      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         // Configure the primary key for Gebruiker
         modelBuilder.Entity<Gebruiker>().HasKey(g => g.gebruiker_id);

         // Configure the primary key for Verhuurder and its relationship with Gebruiker
         modelBuilder.Entity<Verhuurder>()
             .HasKey(v => v.verhuurder_id);
         modelBuilder.Entity<Verhuurder>()
             .HasOne(v => v.gebruiker)
             .WithOne()
             .HasForeignKey<Verhuurder>(v => v.user_id);

         // Configure the primary key for Huurder and its relationship with Gebruiker
         modelBuilder.Entity<Huurder>()
             .HasKey(h => h.huurder_id);
         modelBuilder.Entity<Huurder>()
             .HasOne(h => h.gebruiker)
             .WithOne()
             .HasForeignKey<Huurder>(h => h.user_id);

         // Configure the primary key for Auto
         modelBuilder.Entity<Auto>().HasKey(a => a.auto_id);

         // Configure the primary key for Reservering and its relationships with Auto and Gebruiker
         modelBuilder.Entity<Reservering>().HasKey(r => r.reservering_id);
         modelBuilder.Entity<Reservering>()
             .HasOne(r => r.auto)
             .WithMany()
             .HasForeignKey(r => r.auto_id);
         modelBuilder.Entity<Reservering>()
             .HasOne(r => r.gebruiker)
             .WithMany()
             .HasForeignKey(r => r.gebruiker_id);

   }



}
public class MainClass
{

   public static void Main(string[] args)
   {

      using (var context = new VerhuurContext())
      {
         // Controleer of de database al is aangemaakt
         if (!context.Database.EnsureCreated())
         {
            Console.WriteLine("De database bestaat al.");
         }
         else
         {
            Console.WriteLine("De database is aangemaakt.");

            // Voeg hier code toe om huurders en verhuurders aan te maken
            var huurder1 = new Huurder
            {
               gebruiker_naam = "Huurder1",
               gebruiker_telefoonnummer = 123456789,
               gebruiker_email = "huurder1@example.com",
               adres = "Adres van Huurder1"
            };

            var huurder2 = new Huurder
            {
               gebruiker_naam = "Huurder2",
               gebruiker_telefoonnummer = 123456710,
               gebruiker_email = "huurder2@example.com",
               adres = "Adres van Huurder2"
            };

            var verhuurder1 = new Verhuurder
            {
               gebruiker_naam = "Verhuurder1",
               gebruiker_telefoonnummer = 123455789,
               gebruiker_email = "verhuurder1@example.com",
               adres = "Adres van Verhuurder1"
            };

            var verhuurder2 = new Verhuurder
            {
               gebruiker_naam = "Verhuurder1",
               gebruiker_telefoonnummer = 123455799,
               gebruiker_email = "verhuurder2@example.com",
               adres = "Adres van Verhuurder2"
            };

            // Voeg meer huurders en verhuurders toe indien nodig...

            // Voeg de huurders en verhuurders toe aan de database
            context.gebruikers.AddRange(huurder1 /*, voeg hier de andere gebruikers toe */);
            context.SaveChanges();
         }
      }

      using (var context = new VerhuurContext())
      {
         // Controleer of de lijst van gebruikers niet null is
         if (context.gebruikers != null)
         {
            // De lijst van gebruikers is niet null, voer hier je logica uit
            foreach (var gebruiker in context.gebruikers)
            {
               Console.WriteLine("Gebruiker: " + gebruiker.gebruiker_naam);
            }
         }
         else
         {
            // De lijst van gebruikers is null, voer hier eventuele foutafhandeling uit
            Console.WriteLine("De lijst van gebruikers is null.");
         }
      }


   }

}

}