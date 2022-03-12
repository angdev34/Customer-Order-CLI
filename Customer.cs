namespace Customer_Order_CLI
{
    class Customer
    {
        private long _IdNum;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Phone;

        public long IdNum { get => _IdNum; set => _IdNum = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
      

        public Customer(long idNum, string firstName, string lastName, string email, string phone)
        {
             IdNum = idNum;
             FirstName = firstName;
             LastName = lastName;
             Email = email;
             Phone = phone;

        }
        public Customer(long idNum)
        {
            IdNum = idNum;
            Order order = new Order();
            if (!SearchCustomer(idNum))
            {
                AddCustomer();
            }
                order.AddOrder(IdNum);
        }

        public void AddCustomer()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Müşteri Kayıt Ekranı");
                Console.Beep();

                Console.Write("\nT.C numaranız:" + IdNum);
                Console.Write("\nAdınızı giriniz:");
                FirstName = Console.ReadLine();
                Console.Write("\nSoyadınızı giriniz:");
                LastName = Console.ReadLine();
                Console.Write("\nMail adresinizi giriniz:");
                Email = Console.ReadLine();
                Console.Write("\nTelefon numaranızı giriniz:");
                Phone = Console.ReadLine();
                SaveCustomer();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public void SaveCustomer()
        {

            string FilePath =   @Path.GetFullPath("Customers.txt");
            FileStream fileStream = new FileStream(FilePath, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine( IdNum +"     "+ 
                                    FirstName + "     " + 
                                    LastName + "     " +
                                    Email + "     " +
                                    Phone);
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
        }
        public bool SearchCustomer( long idNum)
        {
            bool isCustomerExist = false;
            string FilePath = @Path.GetFullPath("Customers.txt");
            FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] customer = line.Split("     ");
                if (long.Parse(customer[0]) == idNum) { 
                    isCustomerExist = true;
                }
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            fileStream.Close();
            return isCustomerExist; 
        }
    }

}
