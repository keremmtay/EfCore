// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");

#region Default Convention - ManyToMany İlişkisini Oluşturmak

//public class Oyuncu
//{
//    public int Id { get; set; }
//    public string OyuncuAdi { get; set; }

//    //public List<Film> Filmler { get; set; }

//    // Aşağıdaki ilişkilerin tanımladığı alana Navigation Property deniyor.
//    public ICollection<Film> Filmler { get; set; }

//}

//public class Film
//{
//    public int Id { get; set; }
//    public string FilmAdi { get; set; }

//    //public List<Oyuncu> Oyuncular { get; set; }
//    public ICollection<Oyuncu> Oyuncular { get; set; }
//}


#endregion

#region Data Annotation - ManyToMany İlişkisini Oluşturmak

// Data Annotations ile ManyToMany ilişkisi kurulacak ise bu durumda 3. tabloyu bizim oluşturmamız gerekiyor.

public class Oyuncu
{
    [Key]
    public int Id { get; set; }
    public string OyuncuAdi { get; set; }
    public ICollection<Film> Filmler { get; set; }

}

public class Film
{
    [Key]
    public int Id { get; set; }
    public string FilmAdi { get; set; }
    public ICollection<Oyuncu> Oyuncular { get; set; }
}

// OyuncuFilm sınıfı cross table olarak oluşturulacaktır.
public class OyuncuFilm
{
    [ForeignKey("Film")]
    public int FilmId { get; set; }

    [ForeignKey("Oyuncu")]
    public int OyuncuId { get; set; }
    public Film Film { get; set; }
    public Oyuncu Oyuncu { get; set; }
}

#endregion

public class Context : DbContext
{
    public DbSet<Oyuncu> Oyuncular { get; set; }
    public DbSet<Film> Filmler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-TUMHS1A\\NA;Database=EfCoreManyToMany;Integrated Security=true");
    }
}