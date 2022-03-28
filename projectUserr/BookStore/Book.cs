using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Book
    {
        public int ID
        {
            get;
            set;
        }
        public String BookName
        {
            get;
            set;
        }
        public String Author
        {
            get;
            set;
        }

        public int QuantityInStock
        {
            get;
            set;
        }

        public float OriginalPrice
        {
            get;
            set;
        }

        public String Description
        {
            get;
            set;
        }

        public float SalePrice
        {
            get;
            set;
        }

        public int Discount
        {
            get;
            set;
        }

        public String PublishingYear
        {
            get;
            set;
        }

        public String PublisherName
        {
            get;
            set;
        }

        public String BookImg
        {
            get;
            set;
        }
    }
}
