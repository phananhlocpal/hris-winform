using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRMngt.Model;
using HRMngt.View;

namespace HRMngt.Presenter
{
    public class UserPresenter
    {
        // Fields
        private IUserView view;
        private IUserRepository repository;
        private BindingSource bindingSource;
        private IEnumerable<UserModel> userList;

        public UserPresenter(IUserView view, IUserRepository repository)
        {
            this.bindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            // Sub the event handler methods to view events
            this.view.SearchEvent += SearchUser;
            this.view.AddNewEvent += AddNewUser;
            this.view.EditEvent += LoadSelectedUserToEdit;
            this.view.DeleteEvent += DeleteSelectedUser;
            this.view.SaveEvent += SaveUser;
            this.view.CancelEvent += CancelAction;
            //Sets user binding source
            this.view.SetUserListBindingSource(bindingSource);
            //

        }

        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveUser(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedUser(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedUserToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewUser(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchUser(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
