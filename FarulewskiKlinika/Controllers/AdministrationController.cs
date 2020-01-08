using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarulewskiKlinika.Models;
using FarulewskiKlinika.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FarulewskiKlinika.Controllers
{
    // Tylko użytkownik pełniący rolę Admin lub User, ma dostęp do funkcji Administratora
    [Authorize(Roles ="Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // Usuwam Usera i przekazuje w metodzie id usera. Używając tego przychodzącego id chce uzyskać określonego usera z bazy danych
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            // znajdź usera po Id
            var user = await userManager.FindByIdAsync(id);

            // jeżeli nie ma usera
            if (user == null)
            {
                ViewBag.Errormessage = $"User z ID = {id} nie został znaleziony.";
                return View("NotFound");
            }

            // w przeciwnym razie korzystam z servicu userManager i wywołuje metodę DeleteAsync w której przekazuje usera do usunięcia.
            else
            {
                var result = await userManager.DeleteAsync(user);

                // jeżeli udało się uzunąć użytkownika
                if (result.Succeeded)
                {
                    //wróc do widoku ListUsers
                    return RedirectToAction("ListUsers");
                }

                // dla każdego errora w result podczas usuwania usera
                foreach(var error in result.Errors)
                {
                    // dodaje errory do ModelState
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListUsers");
            }     
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            // szukam roli
            var role = await roleManager.FindByIdAsync(id);

            // jeżeli nie ma roli do usunięcia to pokaż widok NotFound
            if(role == null)
            {
                // 
                ViewBag.ErrorMessage = $"Rola z ID = {id} nie została znaleziona.";
                return View("NotFound");
            }
            
            // w przeciwnym razie, jeżeli znalazłem rolę z danym id w bazie danych, to przekazuje role do usunięcia
            else
            {
                var result = await roleManager.DeleteAsync(role);

                // jeżeli udało się usanąć rolę to pokazuje widok ListRoles
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                // dla każdego errora w result podczas usuwania usera
                foreach (var error in result.Errors)
                {
                    // dodaje errory do ModelState
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListRoles");
            }
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;

            return View(roles);
        }



        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.Errormessage = $"User z ID = {id} nie został znaleziony.";
                return View("NotFound");
            }

            var userClaims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);


            var model = new EditUserViewModel
            {
                Id = user.Id,
                Imie = user.Imie,
                Nazwisko = user.Nazwisko,
                Pesel = user.Pesel,
                Email = user.Email,
                UserName = user.UserName,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };
            return View(model);
        }

        // Post request - aktualizuje Usera - update
        // Modelem jest EditUserViewModel
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.Errormessage = $"User z ID = {model.Id} nie został znaleziony.";
                return View("NotFound");
            }

            else
            {
                // kopiuję UserName, Imie, Nazwisko, Pesel z obiektu model do odpowiednich propertisów w obiekcie user
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Imie = model.Imie;
                user.Nazwisko = model.Nazwisko;
                user.Pesel = model.Pesel;

                // wywołuje metodę UpdateAsync z wykorzystaniem serwisu userManager i w metodzie UpdateAsync przekazuje usera
                // UpdateAsync(user) - ten obiekt aktualizuje dane usera w bazie danych
                var result = await userManager.UpdateAsync(user);
                
                // jeżeli update się udał i został zapisany do bazy
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            };
            
        }


        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.Errormessage = $"Rola z ID = {id} nie została znaleziona.";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                RoleID = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.RoleID);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Rola z ID = {model.RoleID} nie została znaleziona.";

                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Rola z ID = {roleId} nie została znaleziona.";

                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserID = user.Id,
                    UserName = user.UserName
                };
                
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }

                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel>model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Rola z ID = {roleId} nie została znaleziona.";

                return View("NotFound");
            }
          for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserID);

                IdentityResult result = null;

                // kiedy user jest zaznaczony i nie jest juz w tej roli
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name))) 
                {
                    // dodaje usera jako członka danej roli - przekazuje 2 parametry - user którego dodaje 
                    //i nazwę roli do której przypisuje usera
                   result = await userManager.AddToRoleAsync(user, role.Name);
                }
                // jezeli user nie jest zaznaczony oraz jest już przypisany do danej roli
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))

                        continue;
                    else

                        return RedirectToAction("EditRole", new { Id = roleId });
                }

            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

    }
}