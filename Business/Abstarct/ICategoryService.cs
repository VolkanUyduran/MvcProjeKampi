using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstarct
{
    public interface ICategoryService
    {
        List<Category> GetList();
        Category GetById(int id);
        void CategoryAdd(Category category);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);

    }
}
