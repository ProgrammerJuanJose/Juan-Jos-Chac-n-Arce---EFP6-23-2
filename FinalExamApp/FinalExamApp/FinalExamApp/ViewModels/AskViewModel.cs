using FinalExamApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamApp.ViewModels
{
    public class AskViewModel : BaseViewModel
    {
        public Ask MyAsk { get; set; }
        public User MyUser { get; set; }
        public AskStatus MyStatus { get; set; }

        public AskViewModel()
        {
            MyAsk = new Ask();
            MyUser = new User();
            MyStatus = new AskStatus();
        }

        //Función de creación de pregunta nueva
        public async Task<bool> AddAskAsync(string pAsk,
                                             string pAskDetail,
                                             int pUserID,
                                             int pAskStatusID)
        {
            if (IsBusy) return false;
            try
            {
                MyAsk = new Ask();
                MyAsk.Ask1 = pAsk;
                MyAsk.AskDetail = pAskDetail;
                MyAsk.UserId = pUserID;
                MyAsk.AskStatusId = pAskStatusID;

                bool R = await MyAsk.AddAskAsync();

                return R;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
