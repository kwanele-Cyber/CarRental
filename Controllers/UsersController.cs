using CarRental.DataModels;
using CarRental.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class UsersController : Controller
{
    private SnapDriveDBEntities db = new SnapDriveDBEntities();

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(Login model)
    {
        if (ModelState.IsValid)
        {
            // You should add your own logic to check the username and password
            bool isValidUser = CheckUserCredentials(model.Username, model.Password);

            if (isValidUser)
            {
                // Perform custom login logic here, such as setting a user session.
                // For example:
                Session["Username"] = model.Username;
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        return View(model);
    }

    // Custom method to check user credentials (replace with your logic)
    private bool CheckUserCredentials(string username, string password)
    {
        // Query the database to check if the user exists and the password is correct
        var user = db.Users.FirstOrDefault(u => u.Username == username);

        if (user != null)
        {
            // In a real application, you should implement password hashing and validation
            // Here, we're doing a simple string comparison for demonstration purposes.
            if (user.Password == password)
            {
                return true; // Authentication successful
            }
        }

        return false; // Authentication failed
    }

    public ActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SignUp(UserModel model)
    {
        if (ModelState.IsValid)
        {
            // Implement your custom signup logic here, such as saving the user to the database.
            // For example:
            bool isSignupSuccessful = CreateUser(model);

            if (isSignupSuccessful)
            {
                // Perform custom signup success logic, such as redirecting to a login page.
                return RedirectToAction("Login", "User"); // Assuming you have a LoginController.
            }

            ModelState.AddModelError(string.Empty, "Signup failed. Please try again.");
        }

        return View(model);
    }

    // Custom method to create a new user (replace with your logic)
    private bool CreateUser(UserModel model)
    {
        try
        {
            // Implement your logic to create a new user in the database.
            // Return true if the user is successfully created; otherwise, return false.

            // Example code:
            var newUser = new User()
            {
                Username = model.Username,
                Password = model.Password, // You should hash this password.
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                ProfilePicture = model.ProfilePicture,
                RegistrationDate = DateTime.Now,
                UserType = model.UserType,
            };

            // Add the user to your Entity Framework context and save changes.
            db.Users.Add(newUser);
            db.SaveChanges();

            return true; // User creation successful
        }
        catch (Exception)
        {
            // Handle any exceptions that occur during user creation.
            return false; // User creation failed
        }
    }

    // Other controller actions...
}






