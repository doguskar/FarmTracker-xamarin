using FarmTracker.Data;
using FarmTracker.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FarmTracker.ViewModel
{
    class EntityViewModel : BaseViewModel
    {
        public Entity Entity { get; set; }

        private EntityRepository entityRepository;
        private CategoryRepository categoryRepository;
        public EntityViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            entityRepository = new EntityRepository(System.IO.Path.Combine(path, "farmTracker"));
            categoryRepository = new CategoryRepository(System.IO.Path.Combine(path, "farmTracker"));

            string currentEntityId = Preferences.Get("currentEntityId", null);
            if (!string.IsNullOrWhiteSpace(currentEntityId))
            {
                Entity = entityRepository.GetEntityById(new Guid(currentEntityId));
                if (Entity != null)
                {
                    Category category = categoryRepository.GetCategoryById(Entity.CategoryId);
                    Entity.Image = category.Image;
                }
            }
        }
    }
}
