namespace Customer_Order_CLI
{
    class Order : Product
    {
        private int _OrderID;
     


        public int OrderID { get => _OrderID; set => _OrderID = value; }

        public Order() {
            OrderID = GetOrderID();
        }
        public void AddOrder(long IdNum)
        {
            Console.Clear();
            Console.Beep();
            ProductList();
            Console.Write("\nSipariş Etmek istediğiniz aracı seçiniz: ");
            int option = int.Parse(Console.ReadLine());
            Console.Write("Bu araçtan kaç adet sipariş etmek istersiniz: ");
            int amound = int.Parse(Console.ReadLine());
            if (ProductSearch(option, amound))
            {
                SaveOrder(option, amound, IdNum);
            }
            else 
            {
                Console.WriteLine("Hatalı ürün yada miktar seçimi yaptınız..");
                System.Threading.Thread.Sleep(1500);
            }
        }
        public void SaveOrder(int ProductID, int Amount, long IdNum)
        {
            string FilePath = @Path.GetFullPath("Order.txt");
            FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine( OrderID+ "     " +
                                    ProductID + "     " +
                                    Amount + "     " +
                                    IdNum );
            
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
            ProductUpdate(ProductID, Amount);
            Console.WriteLine("Siparişiniz Alındı."); 
            Console.WriteLine("Başlangıç Ekranına aktarılıyorsunuz..");
            System.Threading.Thread.Sleep(1500);
        }
        public int GetOrderID()
        {
            string FilePath = @Path.GetFullPath("Order.txt");
            FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            string line = streamReader.ReadLine();
            int index = 1;
            while (line != null)
            {
                index = index+1;
                
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            fileStream.Close();
           
            return index;
        }

    }
}
