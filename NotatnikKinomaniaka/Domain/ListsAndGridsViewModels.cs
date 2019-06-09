using DatabaseLayer.Models;
using RepositoryLayer.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NotatnikKinomaniaka.Domain
{
    public class ListsAndGridsViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<SelectableViewModel> _items;
        private ObservableCollection<SelectableViewModel> _selectedItems = new ObservableCollection<SelectableViewModel>();

        public ExecuteCommands AddCommand { get; }
        public ExecuteCommands RemoveSelectedItemCommand { get; }


        //private bool? _isAllItems3Selected;

        public ListsAndGridsViewModel()
        {
            _items = CreateData();
            //AddCommand = new ExecuteCommands(
            //    _ =>
            //    {
            //        Items.Add(new Film
            //        {
            //            Code = 'M',
            //            Name = "M Jak Milosc",
            //            Description = "Masterpiece",
            //            Rating = 1
            //        });
            //    });

            //RemoveSelectedItemCommand = new ExecuteCommands(
            //    _ =>
            //    {
            //        foreach (var item in Items)
            //        {
            //            if (item.IsSelected)
            //                _selectedItems.Add(item);
            //        }

            //        foreach (var item in _selectedItems)
            //        {
            //            Items.Remove(item);
            //        }

            //    },
            //    _ => Items != null);
        }

        //public bool? IsAllItems3Selected
        //{
        //    get { return _isAllItems3Selected; }
        //    set
        //    {
        //        if (_isAllItems3Selected == value) return;

        //        _isAllItems3Selected = value;

        //        if (_isAllItems3Selected.HasValue)
        //            SelectAll(_isAllItems3Selected.Value, Items3);

        //        OnPropertyChanged();
        //    }
        //}

        private static void SelectAll(bool select, IEnumerable<SelectableViewModel> models)
        {
            foreach (var model in models) model.IsSelected = @select;
        }

        private static ObservableCollection<SelectableViewModel> CreateData()
        {
            FilmRepository filmRepository = new FilmRepository();
            ICollection<Film> films = filmRepository.GetAllFilms();


            List<string> _names = new List<string>();
            List<string> _descriptions = new List<string>();
            
            List<char> _codes = new List<char>();
            foreach (Film f in films)
            {
                _names.Add(f.Title);
                _descriptions.Add(f.Review.ReviewText);
            }
            char[] chararray = new char[_names.Count];
            
            for (int i = 0; i <_names.Count; i++)
            {
                chararray[i] = (_names[i].ToUpper().First());
                
            }
            


            ObservableCollection<SelectableViewModel> movies = new ObservableCollection<SelectableViewModel>();

            for(int i = 0; i<_names.Count; i++)
            {
                SelectableViewModel model = new SelectableViewModel
                {
                    Code = chararray[i],
                    Name = _names[i],
                    Description = _descriptions[i],
                    Rating = 4
                };
                movies.Add(model);
            }

            return movies;


            //return new ObservableCollection<SelectableViewModel>
            //{
                
            //    new SelectableViewModel
            //    {
            //        Code = chararray[0],
            //        Name = _names[0],
            //        Description = _descriptions[0],
            //        Rating = 1
            //    },
            //    new SelectableViewModel
            //    {
            //        Code = chararray[1],
            //        Name = _names[1],
            //        Description = _descriptions[1],
            //        Rating = 5
            //    },
            //    new SelectableViewModel
            //    {
            //        Code = chararray[2],
            //        Name = _names[2],
            //        Description = _descriptions[2],
            //        Rating = 4
            //    }

            //    };
        }





        /// <summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        //    return new ObservableCollection<SelectableViewModel>
        //    {

        //        new SelectableViewModel
        //        {
        //            Code = 'M',
        //            Name = "M Jak Milosc",
        //            Description = "Masterpiece",
        //            Rating = 1
        //        },
        //    new SelectableViewModel
        //    {
        //        Code = 'D',
        //        Name = "Dragon Ball",
        //        Description = "ドラゴンボール",
        //        Rating = 5
        //    },
        //    new SelectableViewModel
        //    {
        //        Code = 'P',
        //        Name = "Predator",
        //        Description = "Krkrkrkrkrkrkr...",
        //        Rating = 4
        //    }

        //    };
        //}

        //return new ObservableCollection<SelectableViewModel>
        //{
        //new SelectableViewModel
        //{
        //    Code = 'M',
        //    Name = "M Jak Milosc",
        //    Description = "Masterpiece",
        //    Rating = 1
        //},
        //new SelectableViewModel
        //{
        //    Code = 'D',
        //    Name = "Dragon Ball",
        //    Description = "ドラゴンボール",
        //    Rating = 5
        //},
        //new SelectableViewModel
        //{
        //    Code = 'P',
        //    Name = "Predator",
        //    Description = "Krkrkrkrkrkrkr...",
        //    Rating = 4
        //}
        //};


        public ObservableCollection<SelectableViewModel> Items => _items;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
