using HW_13.Contracts;
using HW_13.Entities;
using HW_13.Enums;
using HW_13.Services;

Authentication auth = new Authentication();
IUserService UService = new UserService();
IAdminService AService = new AdminService();



bool end = false;
bool stop = false;

while (end == false)
{
    try
    {
        int options = 0;
        Console.Clear();
        Console.WriteLine("1- Login");
        Console.WriteLine("2- Register");
        Console.WriteLine("3- Exit");
        options = Convert.ToInt32(Console.ReadLine());
        switch (options)
        {
            case 1:
                Console.Clear();
                Console.Write("please enter your username : ");
                string username = Console.ReadLine();
                Console.Write("please enter your password : ");
                string password = Console.ReadLine();
                var acc = auth.Login(username, password);
                if (acc == null) { Console.WriteLine("User does not exist"); }
                else if (acc is User u) { UserMenu(u); }
                else if (acc is Admin A) { AdminMenu(A); }
                Console.ReadKey();
                break;
            case 2:
                Console.Clear();
                Console.Write("please enter your username : ");
                string Username = Console.ReadLine();
                Console.Write("please enter your password : ");
                string Password = Console.ReadLine();
                Console.Write("please enter your role (1)User,2)Admin)");
                int role = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(auth.Register(Username, Password, (RoleEnum)role));
                Console.ReadKey();
                break;
            case 3:
                Console.Clear();
                end = true;
                Console.ReadKey();
                break;

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }

}






void UserMenu(User U)
{
    stop = false;
    while (stop == false)
    {
        try
        {
            if (U.ActiveUntil<DateOnly.FromDateTime(DateTime.Now))
            {
                Console.WriteLine("your account is no longer valid");
                break;
            }

            int option = 0;
            Console.Clear();
            Console.WriteLine("1- show all the Books");
            Console.WriteLine("2- show borrowed books");
            Console.WriteLine("3- borrow Books");
            Console.WriteLine("4- return Books");
            Console.WriteLine("5- Exit");

            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Clear();
                    foreach (Book b in UService.ShowAll())
                    {
                        Console.WriteLine($"{b.Id}) {b.Title}   -{b.Description}-     |{b.Author}    {b.Price}$ |");
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.Clear();
                    foreach (Book b in UService.ShowBorrowedBooks(U.Id))
                    {
                     
                        Console.WriteLine($"{b.Id}) {b.Title}   -{b.Description}-     |{b.Author}    {b.Price}$ |"); 
                    }

                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    foreach (Book b in UService.ShowAll()) { Console.WriteLine($"{b.Id}) {b.Title}   -{b.Description}-     |{b.Author}    {b.Price}$ |"); }
                    Console.Write("please enter the id of the book : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(UService.BorrowBook(id, U.Id));
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Clear();

                    foreach (Book b in UService.ShowBorrowedBooks(U.Id))
                    {
                        Console.WriteLine($"{b.Id}) {b.Title}   -{b.Description}-     |{b.Author}    {b.Price}$ |");
                    }

                    Console.Write("please enter the id of the book : ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(UService.returnbook(Id, U.Id));

                    Console.ReadKey();
                    break;

                case 5:
                    Console.Clear();
                    stop = true;
                    break;
                default:

                    Console.WriteLine("idont know what you are saying");
                    break;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}


void AdminMenu(Admin A)
{
    stop = false;
    while (stop == false)
    {
        try
        {
            int option = 0;
            Console.Clear();
            Console.WriteLine("1- show all the Books");
            Console.WriteLine("2- show all the users");
            Console.WriteLine("3- extend user expiration date");
            Console.WriteLine("4- Exit");

            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(AService.GetAllBooks());
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();

                    foreach (User U in AService.GetUsers())
                    {
                        Console.WriteLine($"{U.Id}) {U.UserName} ({string.Join(", ", UService.ShowBorrowedBooks(U.Id).Select(b => b.Title))})");
                    }

                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    foreach (User U in AService.GetUsers())
                    {
                        if (U.ActiveUntil < DateOnly.FromDateTime(DateTime.Now))
                            { Console.WriteLine($"{U.Id}) {U.UserName}  | free trial time expired"); }
                        else {
                            var hyearsLeft = U.ActiveUntil.Year - DateOnly.FromDateTime(DateTime.Now).Year;
                            var hmounthsLeft = U.ActiveUntil.Month - DateOnly.FromDateTime(DateTime.Now).Month;
                            var hdaysLeft = (hyearsLeft* 365) + (hmounthsLeft * 30) + U.ActiveUntil.Day - DateOnly.FromDateTime(DateTime.Now).Day;
                            Console.WriteLine($"{U.Id}) {U.UserName}  | {hdaysLeft}");
                        }
                    }
                    Console.Write("please enter the id of the book : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var user= AService.GetUserById(id);
                    
                    Console.Clear() ;
                    var yearsLeft = user.ActiveUntil.Year - DateOnly.FromDateTime(DateTime.Now).Year; 
                    var mounthsLeft = user.ActiveUntil.Month - DateOnly.FromDateTime(DateTime.Now).Month ;
                    var daysLeft = (yearsLeft*365)+(mounthsLeft*30)+user.ActiveUntil.Day -DateOnly.FromDateTime(DateTime.Now).Day ;
                    Console.WriteLine($"{user.Id}) {user.UserName}  | {daysLeft}");
                    Console.Write("by how many days do you want to change the time for? : ");
                    int change = Convert.ToInt32(Console.ReadLine());
                    user.ActiveUntil = user.ActiveUntil.AddDays(change);
                    Console.WriteLine(UService.UpdateUser(user));
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    stop = true;
                    break;
                default:

                    Console.WriteLine("idont know what you are saying");
                    break;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}