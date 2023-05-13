// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");

#region Default Convention - Bire Çok İlişki - OneToMany

//public class Kategori
//{
//    public int Id { get; set; }
//    public string KategoriAdı { get; set; }

//    //public ICollection<Urun> Urunler { get; set; }   OneToMany tanımlamalarında ICollection veya List kullanılabilir.
//    public List<Urun> Urunler { get; set; }


//}

//public class Urun
//{
//    public int Id { get; set; }
//    public string UrunAdi { get; set; }

//    public int KategoriId { get; set; }
//    //  İlişkiler
//    public Kategori Kategori { get; set; }
//}

#endregion

#region Data Annotation  - Bire Çok İlişki - OneToMany

public class Kategori
{
    [Key]
    public int Id { get; set; }
    public string KategoriAdı { get; set; }

    public List<Urun> Urunler { get; set; }


}

public class Urun
{
    [Key]
    public int Id { get; set; }
    public string UrunAdi { get; set; }

    [ForeignKey("Kategori")]
    public int KatId { get; set; }    
    public Kategori Kategori { get; set; }
}

#endregion

public class Context : DbContext
{
    public DbSet<Kategori> Kategoriler { get; set; }
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-TUMHS1A\\NA;Database=EfCoreOneToMany;Integrated Security=true");
    }
}