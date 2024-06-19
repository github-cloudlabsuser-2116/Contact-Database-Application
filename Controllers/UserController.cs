using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(userlist); // Returns the list of users to the Index view.
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id); // Finds the user by ID.
            if (user == null)
            {
                return HttpNotFound(); // Returns a not found result if the user doesn't exist.
            }
            return View(user); // Returns the Details view for the found user.
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View(); // Returns the Create view to create a new user.
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                userlist.Add(user); // Adds the new user to the list.
                return RedirectToAction("Index"); // Redirects to the Index action after successful creation.
            }
            catch
            {
                return View(); // Returns the Create view with the user model to display any validation errors.
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id); // Finds the user by ID.
            if (user == null)
            {
                return HttpNotFound(); // Returns a not found result if the user doesn't exist.
            }
            return View(user); // Returns the Edit view for the found user.
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                var userToUpdate = userlist.FirstOrDefault(u => u.Id == id); // Finds the user by ID.
                if (userToUpdate == null)
                {
                    return HttpNotFound(); // Returns a not found result if the user doesn't exist.
                }
                // Update the user details here.
                userToUpdate.Name = user.Name;
                userToUpdate.Email = user.Email;
                userToUpdate.Age = user.Age;

                return RedirectToAction("Index"); // Redirects to the Index action after successful update.
            }
            catch
            {
                return View(user); // Returns the Edit view with the user model to display any validation errors.
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id); // Finds the user by ID.
            if (user == null)
            {
                return HttpNotFound(); // Returns a not found result if the user doesn't exist.
            }
            return View(user); // Returns the Delete view for the found user.
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var user = userlist.FirstOrDefault(u => u.Id == id); // Finds the user by ID.
                if (user != null)
                {
                    userlist.Remove(user); // Removes the user from the list.
                }
                return RedirectToAction("Index"); // Redirects to the Index action after successful deletion.
            }
            catch
            {
                return View(); // Returns the Delete view to display any errors.
            }
        }
    }
}