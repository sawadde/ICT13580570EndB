using System;
using SQLite;

namespace ICT13580570EndB.Models
{
    public class Product
    {
        [PrimaryKey,AutoIncrement]
        public int Id
        { get; set; }

        public string TypeCar
        { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Brand
        {get; set;  }

		[NotNull]
		[MaxLength(100)]
        public string Class
        { get; set; }

        public string Year
        {get; set; }

        public decimal Number
        { get; set; }

        public string Color
        { get; set;}

        public Boolean Status
        {get;  set;}

		[NotNull]
		[MaxLength(200)]
        public string DetailCar
        { get; set; }

        [NotNull]
        public string Price
        {
            get;
            set;
        }

        public string City
        { get; set; }

        [MaxLength(11)]
        public string Phone
        {get; set; }
    }

}
