using System.ComponentModel.DataAnnotations;

namespace P06Shop.Shared
{
    //public class Product
    //{
    //    [Key]
    //    public int Code { get; set; }

    //    public int Id { get; set; }

    //    //nvarchar(50) 
    //    [MaxLength(50)]
    //    public string Title { get; set; }

    //    public string Description { get; set; }
    //}

    public class Product
    { 
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Barcode { get; set; }

        public double Price { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
