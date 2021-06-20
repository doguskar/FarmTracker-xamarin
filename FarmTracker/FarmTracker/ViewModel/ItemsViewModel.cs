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
    class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Entity> Entities { get; set; }
        private bool isItemsRefreshing;

        public ICommand ItemsRefreshCommand { get; set; }
        public ICommand AddItemCommand { get; set; }

        private EntityRepository entityRepository;
        private CategoryRepository categoryRepository;
        public ItemsViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            entityRepository = new EntityRepository(System.IO.Path.Combine(path, "farmTracker"));
            categoryRepository = new CategoryRepository(System.IO.Path.Combine(path, "farmTracker"));

            ItemsRefreshCommand = new Command(ItemsRefresh);
            AddItemCommand = new Command(AddItem);

            LoadItems();
        }
        public bool IsItemsRefreshing
        {
            get => isItemsRefreshing;
            set
            {
                isItemsRefreshing = value;
                OnPropertyChanged();
            }
        }
        public void AddItem()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new ItemFormPage());
        }
        public void ItemsRefresh()
        {
            IsItemsRefreshing = true;
            LoadItems();
            IsItemsRefreshing = false;
        }
        private void LoadItems()
        {
            string userId = Preferences.Get("userId", null);
            if (!string.IsNullOrWhiteSpace(userId))
            {
                List<Entity> entityList = entityRepository.GetEntitiesByOwnerId(new Guid(userId));
                if (entityList != null)
                {
                    foreach (var item in entityList)
                    {
                        Category category = categoryRepository.GetCategoryById(item.CategoryId);
                        item.Image = category.Image;
                    }

                    if (Entities == null)
                    {
                        Entities = new ObservableRangeCollection<Entity>(entityList);
                    }
                    else
                    {
                        Entities.Clear();
                        foreach (var item in entityList)
                        {
                            Entities.Add(item);
                        }
                    }
                }
            }
        }
    }
}
