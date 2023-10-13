using System.ComponentModel.DataAnnotations;

namespace verhuur
{

    class Gebruiker
    {

        [Key]
        public int id { get; set; }

        [Required]
        public string naam { get; set; }

        [Required]
        public int telefoonnummer { get; set; }

        public virtual Adres adres { get; set; }

    }


    class Verhuuder : Gebruiker
    {

        [Required]
        public override Adres adres { get; set; }

        public List<Auto> te_verhuren_autos{get;set;}
    }

    class Huurder : Gebruiker
    {

    }

    class Adres
    {

        public string straat { get; set; }

        public string plaats { get; set; }

        public string postcode { get; set; }

    }

    class Auto
    {

        [Required]
        int id { get; set; }

        [Required]
        string merk { get; set; }

    }


    class Reservering{



        
    }





}