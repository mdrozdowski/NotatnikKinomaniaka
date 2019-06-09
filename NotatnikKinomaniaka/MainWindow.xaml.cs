using NotatnikKinomaniaka.Domain;
using System.Windows;
using MaterialDesignThemes.Wpf;
using RepositoryLayer.Repositories;
using DatabaseLayer.Models;
using System;

namespace NotatnikKinomaniaka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListsAndGridsViewModel x = new ListsAndGridsViewModel();
        public MainWindow()
        {
            DataContext = x;

            //Review review = new Review();
            //review.ReviewText = "Super";
            //review.Rating = 4;


            //ReviewRepository reviewRepository = new ReviewRepository();
            //reviewRepository.Add(review);
            //review = reviewRepository.GetReview(1);

            //Film film = new Film();

            //film.ReviewId = review.Id;
            //film.Review = review;
            //film.Title = "Pogchampik";
            //film.DateOfProduction = DateTime.Now;
            //FilmRepository filmRepository = new FilmRepository();
            //filmRepository.Add(film);

            InitializeComponent();
        }

        private void Sample1_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventargs)
        {

            if(Equals(eventargs.Parameter, true))
            {
                Review review = new Review
                {
                    ReviewText = tbMovieDesc.Text,
                    Rating = 4
                };
                ReviewRepository reviewRepository = new ReviewRepository();
                reviewRepository.Add(review);
                Film film = new Film
                {
                    ReviewId = review.Id,
                    Title = MovieNameTextBox.Text,
                    DateOfProduction = DateTime.Now
                };
                
                FilmRepository filmRepository = new FilmRepository();
                filmRepository.Add(film);

            }
        }


            //if (Equals(eventargs.Parameter, true))
            //{
            //    x.AddCommand.CanExecute(null);
            //    x.Items.Add(new SelectableViewModel
            //    {
            //        Code = 'D',
            //        Name = MovieNameTextBox.Text,
            //        Description = tbMovieDesc.Text,
            //        Rating = 1
            //    });
            //}
        //}
    }





}
