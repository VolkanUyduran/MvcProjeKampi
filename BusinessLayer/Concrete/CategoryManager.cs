using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericReporsitory<Category> repo = new GenericReporsitory<Category>();

        public List<Category> GetAll()
        {
            return repo.List();
        }
        public void CategoryAddBL(Category p)
        {
            if(p.CategoryName==" " || p.CategoryName.Length <= 3)
            {
                //hata mesajı 
            }
        }
    }
}
