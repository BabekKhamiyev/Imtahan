using Cafe.BL.Exceptions;
using Cafe.BL.ViewModels;
using Cafe.DAL.Contexts;
using Cafe.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BL.Services;

public class ChefService
{
    private readonly AppDbContext _context;

    public ChefService(AppDbContext context)
    {
        _context = context;
    }

    #region Create
    public void Create(CreateChefVM vm)
    {
        Chef chef = new Chef()
        {
            Field = vm.Field,
            Name = vm.Name,
        };

       string fileName=Path.GetFileNameWithoutExtension(vm.ImgFile.FileName);
       string fileExtension = Path.GetExtension(vm.ImgFile.FileName);
        string result=fileName+Guid.NewGuid().ToString()+fileExtension;
        string uploadedPath = @"C:\Users\I Novbe\source\repos\Cafe\Cafe.MVC\wwwroot\assets\UploadedImages";
        uploadedPath=Path.Combine(uploadedPath, result);

        using FileStream stream = new FileStream(uploadedPath, FileMode.Create);
        vm.ImgFile.CopyTo(stream);
        chef.ImgUrl=result;

        _context.chefs.Add(chef);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public Chef GetChefById(int id)
    {
        Chef? c = _context.chefs.Find(id);
        if (c is null)
        {
            throw new ChefException($"databasede {id} idli data yoxdu");
        }
        return c;
    }


    public List<Chef> GetAllChef()
    {
        return _context.chefs.ToList();
    }
    #endregion

    #region Update

    public void Update(int id, UpdateChefVM vm)
    {
        Chef c = GetChefById(id);
        
        if (c.Id != vm.Id)
        {
            throw new ChefException($"idler beraber deyil");
        }

        c.Name = vm.Name;
        c.Field = vm.Field;
        if (vm.ImgFile != null)
        {
            string fileName = Path.GetFileNameWithoutExtension(vm.ImgFile.FileName);
            string fileExtension = Path.GetExtension(vm.ImgFile.FileName);
            string result = fileName + Guid.NewGuid().ToString() + fileExtension;
            string uploadedPath = @"C:\Users\I Novbe\source\repos\Cafe\Cafe.MVC\wwwroot\assets\UploadedImages";
            uploadedPath = Path.Combine(uploadedPath, result);

            using FileStream stream = new FileStream(uploadedPath, FileMode.Create);
            vm.ImgFile.CopyTo(stream);
            c.ImgUrl = result;
        }
        _context.SaveChanges();


    }
    #endregion

    #region Delete
    public void Delete(int id)
    {
        Chef c= GetChefById(id);
        _context.chefs.Remove(c);
        _context.SaveChanges();
        
    }
    #endregion
}
