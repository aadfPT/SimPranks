using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimPranks
{
    internal partial class View : Form
    {
        internal event EventHandler UserClickedHideAndApply;
        internal event EventHandler UserClickedClose;
        internal View(ISettings viewModel)
        {
            SettingsViewModel = viewModel;
            InitializeComponent();
        }

        internal ISettings SettingsViewModel { get; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (var option in SettingsViewModel.Options)
            {
                chkLstPranks.Items.Add(option.Description, option.Active);
            }

        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Activate();
        }

        private void ApplicationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing || this.DialogResult == DialogResult.Ignore) return;

            UserClickedClose?.Invoke(this, e);
            e.Cancel = true;
        }

        private void btnHideAndApply_Click(object sender, EventArgs e)
        {
            UserClickedHideAndApply?.Invoke(this, e);
        }

        public IEnumerable<IApplicationOption> GetCheckedOptions()
        {
            var options = new List<IApplicationOption>();
            foreach (var chkLstPrank in chkLstPranks.CheckedItems)
            {
                options.Add(new ApplicationOptionViewModel(true, chkLstPrank.ToString()));
            }
            return options;
        }
    }
}
