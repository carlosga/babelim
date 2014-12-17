using BabelIm.ViewModels;
using System.Windows.Controls;

namespace BabelIm.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView 
        : UserControl
    {
        #region · Constructors ·
        
        public LoginView()
        {
            InitializeComponent();

            this.DataContext = new LoginViewModel();
        }

        #endregion
    }
}
