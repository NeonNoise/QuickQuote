using System.Text;

namespace QuickQuote.Data
{
    public class DatabaseEntry
    {
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string ProductFriendlyName { get; set; }

        public string ProductCategory { get; set; }

        public bool HasVolumeDiscount { get; set; }

        public Database ParentDatabase { get; set; }

        public int VolumeMin
        {
            get
            {
                return volumemin;
            }
            set
            {
                if (value >= 0)
                {
                    volumemin = value;
                }
                else
                {
                    throw new Exception("Volume Min Can't be set to a value less than 0");
                }
            }
        }

        public int VolumeMax
        {
            get
            {
                return volumemax;
            }
            set
            {
                if (value >= volumemin)
                {
                    volumemax = value;
                }
                else
                {
                    throw new Exception("Volume Max must be greather than or equal to Volume Min");
                }

            }
        }

        public double FlatPrice { get; set; }
        public double? Bump { get; set; }

        private int volumemin;
        private int volumemax;

        public DatabaseEntry(Database parent, string productCode, string productName, string productFriendlyName, string productCatagory, bool hasVolumeDiscount, double flatPrice){
            ParentDatabase = parent;
            ProductCode = productCode;
            ProductName = productName;
            ProductFriendlyName = productFriendlyName;
            ProductCategory = productCatagory;
            HasVolumeDiscount = hasVolumeDiscount;
            FlatPrice = flatPrice;
            }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(ProductCode);
            stringBuilder.AppendLine(ProductName);
            stringBuilder.AppendLine(ProductFriendlyName);
            stringBuilder.AppendLine(ProductCategory);
            if (HasVolumeDiscount)
            {
                stringBuilder.AppendLine("Y");
                stringBuilder.AppendLine(VolumeMin.ToString());
                stringBuilder.AppendLine(VolumeMax.ToString());
            }
            else
            {
                stringBuilder.AppendLine("N");
                stringBuilder.AppendLine();
                stringBuilder.AppendLine();
            }
            stringBuilder.AppendLine(FlatPrice.ToString());
            if(Bump != 0)
            {
                stringBuilder.AppendLine(Bump.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
