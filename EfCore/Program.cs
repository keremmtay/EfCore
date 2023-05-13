using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine();

#region Default Conventions - BireBir İlişki - OneToOne

//public class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }

//    // İlişkiler : Her yazarın bir biografisi olacağı için tanımlama aşağıdaki gibi oluyor.

//    public Biografi Biografi { get; set; }
//}

//public class Biografi
//{
//    public int Id { get; set; }
//    public string HayatHikayesi { get; set; }

//    // Depended Entity bu sınıf olacağı için yani bu sınıf ilişkide olacağı diğer sınıfa bağlı olduğu için, benim burada diğer sınıfı temsil eden bir property tanımlamam gerekiyor. Bu da diğer sınıfın Id'si olacak. Temel Entity kurallarından birisi Sınıf isminin yanında Id eklediğimizde EntityFramework bunu FK(Foreign Key) olarak algılıyor.

//    public int YazarId { get; set; }

//    // İlişkiler : Her biografinin 1 yazara ait olduğunu aşağıdaki gibi tanımlıyoruz.

//    public Yazar Yazar { get; set; }
//}

#endregion

#region Data Annotations - Attributes'lar ile bire bir ilişkili veritabanı oluşturma - BireBir İlişki - OneToOne

public class Yazar
{
    [Key]       // Primary Key olarak işaretleniyor
    public int Id { get; set; }
    public string YazarAdi { get; set; }
    public Biografi Biografi { get; set; }  // Her yazar bir biografiye sahip
}

public class Biografi
{
    [Key]       // Primary Key alanı
    public int Id { get; set; }
    public string HayatHikayesi { get; set; }

    [ForeignKey("Yazar")]       // Foreign Key alanı olarak işaretleniyor
    public int YazarId { get; set; }
    public Yazar Yazar { get; set; }        // Bir biografi bir yazara sahip
}

#endregion

public class Context : DbContext
{
    public DbSet<Yazar> Yazarlar { get; set; }
    public DbSet<Biografi> Biografiler { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-TUMHS1A\\NA;Database=EfCoreYazarlar;Integrated Security=true");
    }
}