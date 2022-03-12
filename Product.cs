namespace Customer_Order_CLI
{
    class Product
    {
        private int _ProductID;
        private string _ProductName;
        private int _ProductAmount;
        
        public Product()
        {
           
        }
        public Product( bool first)
        {
            string FilePath = @Path.GetFullPath("Product.txt");
            //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
            FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(1 + "     " + Car.Ferrari_sf90 + "     " + 10);
            streamWriter.WriteLine(2 + "     " + Car.Porche_911_turbo_s + "     " + 10);
            streamWriter.WriteLine(3 + "     " + Car.BMW_E60_M5 + "     " + 10);
            streamWriter.WriteLine(4 + "     " + Car.Nissan_GT_R35 + "     " + 10);
            streamWriter.WriteLine(5 + "     " + Car.Audi_R8_V10plus + "     " + 10);
            streamWriter.WriteLine(6 + "     " + Car.Bugatti_Chiron + "     " + 10);
            streamWriter.WriteLine(7 + "     " + Car.Ford_Mustang_GT_5_0 + "     " + 10);
            //Dosyaya eklenecek customer satırını oluşturduk.
            streamWriter.Flush();
            //Veriyi tampon bölgeden dosyaya aktardık.
            streamWriter.Close();
            fileStream.Close();
        }
        public int ProductID { get => _ProductID; set => _ProductID = value; }
        public string ProductName { get => _ProductName; set => _ProductName = value; }
        public int ProductAmount { get => _ProductAmount; set => _ProductAmount = value; }

        public void ProductList()
        {
            string FilePath = @Path.GetFullPath("Product.txt");
            FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            string line = streamReader.ReadLine();
            
            while (line != null)
            {
                string[] product = line.Split("     ");
                Console.WriteLine(product[0]+". ürün "+product[1] + " Adet:" + product[2]);
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            fileStream.Close();
        }
        public bool ProductSearch(int productID, int Amount)
        {
            string FilePath = @Path.GetFullPath("Product.txt");
            FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            string line = streamReader.ReadLine();

            while (line != null)
            {
                string[] product = line.Split("     ");
                if (int.Parse(product[0]) == productID && int.Parse(product[2]) >= Amount) {
                    return true;
                }
                    line = streamReader.ReadLine();
            }
            streamReader.Close();
            fileStream.Close();
            return false;
        }

        public void ProductUpdate(int productID, int Amount) {
            string SourceFilePath = @Path.GetFullPath("Product.txt");
            string DestinationFilePath = @Path.GetFullPath("Product_Dest.txt");
            FileStream fileStream = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read);
            FileStream fileStream_Dest = new FileStream(DestinationFilePath, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream_Dest);
            StreamReader streamReader = new StreamReader(fileStream);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] product = line.Split("     ");
                if (int.Parse(product[0])!= productID )
                {
                    streamWriter.WriteLine(line);
                }else
                {
                    ProductAmount = int.Parse(product[2]) - Amount;
                    streamWriter.WriteLine(product[0]  + "     " + product[1] + "     " + ProductAmount);
                }
                line = streamReader.ReadLine();
            }
            streamWriter.Close();
            streamReader.Close();
            fileStream.Close();
            fileStream_Dest.Close();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            File.Delete(SourceFilePath);
            File.Move(DestinationFilePath, SourceFilePath);

        }
    }
}
