﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.DTOs;
using Sales.Shared.Entites;

namespace Sales.API.Helpers
{
    //la clase UserHelper implemanta la interfaz IUserHelper
    public class UserHelper : IUserHelper
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        //Creamos un contructor para inyectarle el DataContext
        public UserHelper(DataContext context, UserManager<User> userManager, 
                           RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        //Metodo para crear Usuario
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
           
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }

        }

        //Metodo para que me devuelva la cuidad
        public async Task<User> GetUserAsync(string email)
        {
            var user =  await _context.Users
                 .Include(u => u.City!) //Por cada usuario incluya la cuidad
                 .ThenInclude(c => c.State!)//por cada cuidad incluya el estado
                 .ThenInclude(s => s.Country!)//por cada estado incluya a que pais pertenece
                 .FirstOrDefaultAsync(x => x.Email == email);

            return user!;
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        //Metodo para loguearse
        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        }

        //Metodo para deloguearse
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
