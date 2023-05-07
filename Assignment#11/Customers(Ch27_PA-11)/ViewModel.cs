using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Customers_Ch25_PA_11_;
using System.Net.Http;
using System.Text.Json;

namespace Customers_Ch25_PA_11_
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<Customer> customers;
        public int CustomerListCount { get => customers is null ? 0 : customers.Count; }
        private int currentCustomer;
        public int CurrentCustomerIndex { get => currentCustomer + 1; }
        public Command SearchCustomers { get; private set; }
        public Command RunQuery { get; private set; }
        public Command CancelSearch { get; private set; }
        public Command NextCustomer { get; private set; }
        public Command PreviousCustomer { get; private set; }
        public Command FirstCustomer { get; private set; }
        public Command LastCustomer { get; private set; }

        public Command MoreCustomers { get; private set; }

        public Command Reset { get; private set; }

        private const string ServerUrl = "https://adventureworksservice20230503190605.azurewebsites.net";
        private int offset = 0;
        private int count = 0;
        private HttpClient client = null;
        private JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        public ViewModel()
        {
            this.currentCustomer = 0;
            this.IsAtStart = true;
            this.IsAtEnd = false;

            this.SearchCustomers = new Command(this.Search, () => this.CanBrowse);
            this.RunQuery = new Command(this.View, () => this.CanSearch);
            this.CancelSearch = new Command(this.Cancel, () => this.CanSearch);

            this.NextCustomer = new Command(this.Next,() => this.CanBrowse && this.customers != null && this.customers.Count > 1 && !this.IsAtEnd);
            this.PreviousCustomer = new Command(this.Previous,() => this.CanBrowse && this.customers != null && this.customers.Count > 0 && !this.IsAtStart);
            this.FirstCustomer = new Command(this.First,() => this.CanBrowse && this.customers != null && this.customers.Count > 0 && !this.IsAtStart);
            this.LastCustomer = new Command(this.Last,() => this.CanBrowse && this.customers != null && this.customers.Count > 0 && !this.IsAtEnd);
            this.MoreCustomers = new Command(async () => await this.More(), () => this.CanBrowse && this.client != null);
            this.Reset = new Command(async () => { this.customers = null; await this.GetDataAsync(0, MainPage.BatchSize);}, () => this.CanBrowse && this.client != null);

            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(ServerUrl);
            this.client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task FindCustomersAsync(Customer pattern) 
        {
            try 
            {
                this.LastError = "";
                this.IsBusy = true;
                var response = await this.client.GetAsync($"api/customers/find?title={pattern.Title ?? "%"}"
                    + $"&firstName={pattern.FirstName ?? "%"}&lastName={pattern.LastName ?? "%"}"
                    + $"&email={pattern.EmailAddress ?? "%"}&phone={pattern.Phone ?? "%"}");

                if (response.IsSuccessStatusCode) 
                {
                    var customersJsonString = await response.Content.ReadAsStringAsync();
                    customers = JsonSerializer.Deserialize<List<Customer>>(customersJsonString, options);
                    this.First();
                }
                else 
                {
                    this.LastError = response.ReasonPhrase;
                }
            }
            catch (Exception e) 
            {
                this.LastError = e.Message;
            }
            finally 
            {
                this.OnPropertyChanged(nameof(CustomerListCount));
                this.IsBusy = false;
            }
        }

        private void Search() 
        {
            Customer searchPattern = new Customer { CustomerID = 0 };
            this.customers.Insert(currentCustomer, searchPattern);
            this.IsSearching = true;
            this.OnPropertyChanged(nameof(Current));
        }

        private void View() 
        {
            _ = FindCustomersAsync(Current);
            this.IsBrowsing = true;
            this.LastError = String.Empty;
        }

        private void Cancel() 
        {
            this.customers.Remove(this.Current);
            this.OnPropertyChanged(nameof(Current));
            this.IsBrowsing = true;
            this.LastError = String.Empty;
        }

        public async Task GetDataAsync(int offset, int count) 
        {
            this.offset = offset;
            this.count = count;
            try 
            {
                this.LastError = "";
                this.IsBusy = true;
                var response = await this.client.GetAsync($"api/customer?offset={offset}&count={count}");

                if (response.IsSuccessStatusCode) 
                {
                    var customersJsonString = await response.Content.ReadAsStringAsync();
                    var customersData = JsonSerializer.Deserialize<List<Customer>>(customersJsonString, options);
                    if (this.customers != null) 
                    {
                        this.customers = customersData;
                        this.First();
                    }
                    else 
                    {
                        this.customers.AddRange(customersData);
                    }
                }
                else 
                {
                    this.LastError = response.ReasonPhrase;
                }
            }
            catch (Exception e) 
            {
                this.LastError = e.Message;
            }
            finally 
            {
                this.OnPropertyChanged(nameof(CustomerListCount));
                this.IsBusy = false;
            }
        }

        private async Task More()
        {
            await this.GetDataAsync(this.offset + this.count, this.count);
            this.currentCustomer = this.customers.Count > offset ? offset : this.customers.Count - 1;
            this.OnPropertyChanged(nameof(Current));
            this.IsAtStart = (this.currentCustomer == 0);
            this.IsAtEnd = (this.customers.Count == 0 || this.customers.Count - 1 == this.currentCustomer);
        }

        private enum EditMode {Browsing, Searching };
        private EditMode editMode;

        public bool IsBrowsing 
        {
            get => this.editMode == EditMode.Browsing;
            private set 
            {
                if (value) 
                {
                    this.editMode = EditMode.Browsing;
                }
                this.OnPropertyChanged(nameof(IsBrowsing));
                this.OnPropertyChanged(nameof(IsSearching));
            }
        }
        public bool IsSearching
        {
            get => this.editMode == EditMode.Searching;
            private set
            {
                if (value)
                {
                    this.editMode = EditMode.Searching;
                }
                this.OnPropertyChanged(nameof(IsBrowsing));
                this.OnPropertyChanged(nameof(IsSearching));
            }
        }

        private bool CanBrowse 
        {
            get => this.IsBrowsing && this.client != null;
        }

        private bool CanSearch
        {
            get => this.IsSearching;
        }

        private bool _isBusy;
        public bool IsBusy 
        {
            get => this._isBusy;
            set 
            {
                this._isBusy = value;
                this.OnPropertyChanged(nameof(IsBusy));
            }
        }

        private string _lastError;
        public string LastError 
        {
            get => this._lastError;
            private set 
            {
                this._lastError = value;
                this.OnPropertyChanged(nameof(LastError));
            }
        }

        private bool _isAtStart;
        public bool IsAtStart
        {
            get => this._isAtStart;
            set
            {
                this._isAtStart = value;
                this.OnPropertyChanged(nameof(IsAtStart));
            }
        }

        private bool _isAtEnd;
        public bool IsAtEnd
        {
            get => this._isAtEnd;
            set
            {
                this._isAtEnd = value;
                this.OnPropertyChanged(nameof(IsAtEnd));
            }
        }

        public Customer Current
        {
            get => this.customers is null || this.customers.Count == 0 ? null : this.customers[currentCustomer];
        }

        private void Next()
        {
            if (this.customers.Count - 1 > this.currentCustomer)
            {
                this.currentCustomer++;
                this.OnPropertyChanged(nameof(Current));
                this.OnPropertyChanged(nameof(CurrentCustomerIndex));
                this.IsAtStart = false;
                this.IsAtEnd = (this.customers.Count == 0 || this.customers.Count - 1 == this.currentCustomer);
            }
        }

        private void Previous()
        {
            if (this.currentCustomer > 0)
            {
                this.currentCustomer--;
                this.OnPropertyChanged(nameof(Current));
                this.OnPropertyChanged(nameof(CurrentCustomerIndex));
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentCustomer == 0);
            }
        }

        private void First()
        {
            this.currentCustomer = 0;
            this.OnPropertyChanged(nameof(Current));
            this.OnPropertyChanged(nameof(CurrentCustomerIndex));
            this.IsAtStart = true;
            this.IsAtEnd = (this.customers.Count <= 1);
        }

        private void Last()
        {
            this.currentCustomer = this.customers.Count - 1;
            this.OnPropertyChanged(nameof(Current));
            this.OnPropertyChanged(nameof(CurrentCustomerIndex));
            this.IsAtEnd = true;
            this.IsAtStart = (this.customers.Count <= 1);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
