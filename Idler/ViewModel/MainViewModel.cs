namespace Idler.ViewModel
{
    using System.Windows.Input;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly RelayCommand startCommand;
        private readonly RelayCommand pauseCommand;
        private readonly RelayCommand stopCommand;

        public ICommand StartCommand => this.startCommand;

        public ICommand PauseCommand => this.pauseCommand;

        public ICommand StopCommand => this.stopCommand;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            
            this.startCommand = new RelayCommand(this.ExecuteStartCommand, this.CanExecuteStartCommand);
            this.pauseCommand = new RelayCommand(this.ExecutePauseCommand, this.CanExecutePauseCommand);
            this.stopCommand = new RelayCommand(this.ExecuteStopCommand, this.CanExecuteStopCommand);
        }

        private bool CanExecuteStopCommand()
        {
            throw new System.NotImplementedException();
        }

        private void ExecuteStopCommand()
        {
            throw new System.NotImplementedException();
        }

        private bool CanExecutePauseCommand()
        {
            throw new System.NotImplementedException();
        }

        private void ExecutePauseCommand()
        {
            throw new System.NotImplementedException();
        }

        private bool CanExecuteStartCommand()
        {
            throw new System.NotImplementedException();
        }

        private void ExecuteStartCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}