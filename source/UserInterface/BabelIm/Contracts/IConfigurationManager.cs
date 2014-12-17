using BabelIm.Configuration;
using System.Windows.Input;

namespace BabelIm.Contracts
{
    interface IConfigurationManager
    {
        #region · Properties ·

        BabelImConfiguration Configuration
        {
            get;
        }

        ICommand OpenAccountPreferencesViewCommand
        {
            get;
        }

        ICommand OpenPreferencesViewCommand
        {
            get;
        }

        ICommand OpenServerPreferencesViewCommand
        {
            get;
        }

        Account SelectedAccount
        {
            get;
            set;
        }

        #endregion

        #region · Constructors ·

        BabelImConfiguration GetConfiguration();

        #endregion
    }
}
