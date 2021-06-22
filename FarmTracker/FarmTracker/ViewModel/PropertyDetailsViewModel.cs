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
    class PropertyDetailsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Detail> Details { get; set; }
        private bool isItemsRefreshing;

        public ICommand ItemsRefreshCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public Command<Property> DeleteCommand { get; set; }

        private DetailRepository detailRepository;
        public PropertyDetailsViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            detailRepository = new DetailRepository(System.IO.Path.Combine(path, "farmTracker"));

            ItemsRefreshCommand = new Command(ItemsRefresh);
            AddItemCommand = new Command(AddItem);
            DeleteCommand = new Command<Property>(Delete);

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
            App.Current.MainPage.Navigation.PushModalAsync(new PropertyDetailFormPage());
        }
        public void ItemsRefresh()
        {
            IsItemsRefreshing = true;
            LoadItems();
            IsItemsRefreshing = false;
        }
        private void LoadItems()
        {
            string currentPropertyId = Preferences.Get("currentPropertyId", null);
            if (!string.IsNullOrWhiteSpace(currentPropertyId))
            {
                List<Detail> detailList = detailRepository.GetDetailsByOwnerId(new Guid(currentPropertyId));
                if (detailList != null)
                {
                    foreach (var item in detailList)
                    {
                        if (item.RemainderDate != null)
                        {
                            item.Image = "alarmclock.png";
                            item.Date = item.RemainderDate;
                        }
                        else if (item.Cost > 0)
                        {
                            if (item.IncomeFlag)
                            {
                                item.Image = "moneybag1.png";
                            }
                            else
                            {
                                item.Image = "moneybag2.png";
                            }
                        }
                        else
                        {
                            item.Image = "document.png";
                        }
                    }
                    if (Details == null)
                    {
                        Details = new ObservableRangeCollection<Detail>(detailList);
                    }
                    else
                    {
                        Details.Clear();
                        foreach (var item in detailList)
                        {
                            Details.Add(item);
                        }
                    }
                }
            }
        }
        public void Delete(Detail item)
        {
            if (item != null)
            {
                int result = detailRepository.DeleteDetailById(item.Id);
                if (result > 0)
                {
                    Details.Remove(item);
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Alert", detailRepository.StatusMessage, "OK");
                }
            }
        }
    }
}
