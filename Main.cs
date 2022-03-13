using Customer_Order_CLI;
using System;
class main
{
    
    public static void Action()
    {
        Console.Clear();
        Console.WriteLine("Araç Sipariş Ekranı");
        Console.Beep();
        Console.Write("T.C numaranızı giriniz:");
        long idNum = long.Parse(Console.ReadLine());
        Customer customer = new Customer(idNum);

    }
    public static bool Continue()
    {
        Console.Clear();
        Console.Beep();
        Console.Write("Başka bir işlem yapmak ister misiniz? Y/N    ");
        char option = char.Parse(Console.ReadLine());
        if (option == 'y' || option == 'Y')
        {
            return true;
        }
        
            return false;
        
        
    }


    static void Main(string[] args)
    {

        Product product = new Product(true);
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Action();
        while(Continue())
        {
            Action();            
        }
        

    }

    
}
