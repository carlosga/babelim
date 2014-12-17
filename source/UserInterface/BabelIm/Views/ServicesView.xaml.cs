using BabelIm.ViewModels;
using System.Windows.Controls;

namespace BabelIm.Views
{
    /// <summary>
    /// Activity view
    /// </summary>
    public partial class ServicesView 
        : UserControl
    {
        #region · Constructors ·

        public ServicesView()
        {
            InitializeComponent();

            this.DataContext = new ServicesViewModel();
        }

        #endregion
    }
}
