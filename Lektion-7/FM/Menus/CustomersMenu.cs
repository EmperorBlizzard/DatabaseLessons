namespace FM.Menus;

internal class CustomersMenu
{
    public async Task ShowAsync()
    {
        var exit = false;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Show all Costumers");
            Console.WriteLine("2. Add new Customer");
            Console.WriteLine("3. Show all CustmerTypes");
            Console.WriteLine("4. Add new CustomerType");
            Console.WriteLine("0. Go Back");
            Console.Write("Choose one option: ");
            var goToOption = Console.ReadLine();

            switch (goToOption)
            {
                case "1":

                    break;

                case "2":

                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "0":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Not valid option");
                    Console.ReadKey();
                    break;
            }

        } while (exit);
    }
}
