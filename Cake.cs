using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week1_Patika
{
    public class Cake
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CakeName { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}


