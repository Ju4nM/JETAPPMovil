using JET.Data;
using JET.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Xsl;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMChangeHistory: BaseViewModel
    {
        #region variables
        ObservableCollection<MChangeHistoryBrief> history;
        MChangeHistory[] historyData;
        bool _isLoading;
        #endregion

        #region objetos
        public ObservableCollection<MChangeHistoryBrief> History
        {
            get => history;
            set => SetProperty(ref history, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }
        #endregion

        #region constructor
        public VMChangeHistory(INavigation nav) {
            Navigation = nav;
            _ = LoadHistory();
        }
        #endregion

        #region procesos
        public async Task LoadHistory ()
        {
            HttpResponseMessage response = await DChangeHistory.FindChanges();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                await DisplayAlert("Advertencia", "Ha ocurrido un problema al cargar los datos del historial de cambios", "Aceptar");
                return;
            }

            string content = await response.Content.ReadAsStringAsync();
            historyData = JsonConvert.DeserializeObject<MChangeHistory[]>(content);
            ReduceHistory();
        }

        public void ReduceHistory ()
        {
            ObservableCollection<MChangeHistoryBrief> historyCache = new ObservableCollection<MChangeHistoryBrief>();
            string message = "";
            string responsable = "";
            string date = "";
            for (int i = historyData.Length - 1; i >= 0; i--)
            {
                MChangeHistory current = historyData[i]; // Current record in the iteration

                responsable = current.user != null ? current.user.userName : "[Eliminado]";
                //date = current.dateOfChange.ToShortDateString();
                date = $"{current.dateOfChange.Day}-{current.dateOfChange.Month}-{current.dateOfChange.Year}";

                if (current.changeType == "toggledFan" && current.state != null)
                {
                    message = current.state == true ? "Encendio la ventilacion" : "Apago la ventilacion";
                }
                else if (current.changeType == "limitUpdated")
                {
                    message = $"Actualizo el limite a {current.limitTemperature.limitTemperature}°";
                } 
                
                historyCache.Add(new MChangeHistoryBrief()
                {
                    Responsable = responsable,
                    Date = date,
                    Message = message
                });
            }
            History = historyCache;
        }
        #endregion

        #region commands
        public ICommand UpdateCommand => new Command(async () => await LoadHistory());
        #endregion
    }
}
