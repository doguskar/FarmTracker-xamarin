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
    class ItemFormViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private int count = 1;
        public ICommand SubmitCommand { get; set; }
        public string FormHeader { get; set; }

        private EntityRepository entityRepository;
        private CategoryRepository categoryRepository;
        public ItemFormViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            entityRepository = new EntityRepository(System.IO.Path.Combine(path, "farmTracker"));
            categoryRepository = new CategoryRepository(System.IO.Path.Combine(path, "farmTracker"));

            FormHeader = "Add Item";
            SubmitCommand = new Command(AddItem, CanAddItem);
        }

        private void AddItem()
        {
            string userId = Preferences.Get("userId", null);
            Category category = categoryRepository.GetCategoryByName("Item");
            if (category == null)
            {
                App.Current.MainPage.DisplayAlert("Alert", "Category exception", "OK");
                return;
            }
            Guid categoryId = category.Id;
            int result = entityRepository.InsertEntity(new Entity
            {
                Name = name,
                Description = description,
                Count = count,
                LastModifiedDate = DateTime.UtcNow,
                OwnerId = new Guid(userId),
                CategoryId = categoryId,
                EntityType = EntityType.Item
            });
            if (result > 0)
            {
                App.Current.MainPage.Navigation.PopModalAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", entityRepository.StatusMessage, "OK");
            }
        }
        private bool CanAddItem()
        {
            return count >= 1 && !String.IsNullOrWhiteSpace(name);
        }
        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                (SubmitCommand as Command).ChangeCanExecute();
            }
        }
        public string Description
        {
            get => description;
            set
            {
                SetProperty(ref description, value);
            }
        }
        public int Count
        {
            get => count;
            set
            {
                SetProperty(ref count, value);
                (SubmitCommand as Command).ChangeCanExecute();
            }
        }
    }
}
