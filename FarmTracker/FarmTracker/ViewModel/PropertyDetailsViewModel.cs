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
        private DetailRepository detailRepository;
        public PropertyDetailsViewModel()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            detailRepository = new DetailRepository(System.IO.Path.Combine(path, "farmTracker"));

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
                    Details = new ObservableRangeCollection<Detail>(detailList);
                }
            }
        }
    }
}
