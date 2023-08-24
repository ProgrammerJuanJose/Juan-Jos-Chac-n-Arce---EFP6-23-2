using FinalExamApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamApp.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User MyUser { get; set; }
        public Ask MyAsk { get; set; }
        public AskStatus MyStatus { get; set; }

        public UserViewModel()
        {
            MyAsk = new Ask();
            MyUser = new User();
            MyStatus = new AskStatus();
        }

        public async Task<List<User>> GetUserAsync()
        {
            try
            {
                List<User> users = new List<User>();
                users = await MyUser.GetAllUserAsync();
                if (users == null)
                {
                    return null;
                }
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddAskAsync(string pAsk,
                                            string pAskDetail)
        {
            if (IsBusy) return false;
            try
            {
                MyAsk = new Ask();
                MyAsk.Ask1 = pAsk;
                MyAsk.AskDetail = pAskDetail;

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
