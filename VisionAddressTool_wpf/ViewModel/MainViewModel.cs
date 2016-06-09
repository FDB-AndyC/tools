namespace VisionAddressTool.ViewModel
{
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    using Model;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        private string _queryOutput = string.Empty;

        private bool _isQueryError = false;

        private int _patientId;

        private readonly RelayCommand _queryCommand;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get { return this._welcomeTitle; }
            set { this.Set(ref this._welcomeTitle, value); }
        }
        
        public string QueryOutput {
            get { return this._queryOutput; }
            set { this.Set(ref this._queryOutput, value); }
        }

        public bool IsQueryError
        {
            get { return this._isQueryError; }
            set { this.Set(ref this._isQueryError, value); }
        }

        public int PatientId
        {
            get { return this._patientId; }
            set { this.Set(ref this._patientId, value); }
        }

        public ICommand QueryCommand => this._queryCommand;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            this._queryCommand = new RelayCommand(this.ExecuteQueryCommand);

            this._dataService = dataService;
        }

        private void ExecuteQueryCommand()
        {
            this._dataService.GetData(
                this.PatientId,
                (results, error) =>
                {
                    if (results != null)
                    {
                        this.PopulateResults(results);
                    }

                    if (error != null)
                    {
                        this.QueryOutput = error.Message;
                        this.IsQueryError = true;
                    }
                    else
                    {
                        this.IsQueryError = false;
                    }
                });
        }

        private void PopulateResults(QueryResults results)
        {
            throw new System.NotImplementedException();
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}