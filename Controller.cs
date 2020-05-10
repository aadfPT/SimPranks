
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LowLevelInput.Hooks;
using LowLevelInput.WindowsHooks;
using System.Configuration;

namespace SimPranks
{

    internal class Controller : IDisposable
    {
        private InputManager InputManager { get; set; }
        private Action SpecialComboTask { get; set; }

        private List<PrankModel> PrankModels { get; set; }

        private WindowsHookFilter.WindowsHookFilterEventHandler Filter { get; set; }


        internal Controller()
        {
            PrankModels = ReflectiveEnumerator.GetEnumerableOfType<PrankModel>().ToList();
            foreach (var model in PrankModels)
            {
                Filter += model.FilterEventHandler;
                model.ErrorSubscriber += LogError;
            }

            SpecialComboTask = OpenApplicationWindow;
            SubscribeToAPIInputEvents();
            OpenApplicationWindow();
        }

        private void LogError(object sender, ErrorEventArgs e)
        {
            // Because the application is supposed to work invisibly, we are not showing the error to the user, and instead
            // write it to disk
            var output = new StringBuilder();
            var timeStamp = DateTime.UtcNow;
            output.AppendLine(
                $"{timeStamp.ToShortDateString()} {timeStamp.ToShortTimeString()} Error: {e.Description}");
            if (e.Exception == null)
            {
                output.AppendLine("No exception reported.");
            }
            else
            {
                var ex = e.Exception;
                while (ex != null)
                {
                    output.AppendLine(ex.GetType().FullName);
                    output.AppendLine("Message : " + ex.Message);
                    output.AppendLine("StackTrace : " + ex.StackTrace);
                    ex = ex.InnerException;
                }
            }
            var logFilename = ConfigurationManager.AppSettings["LogFilename"] ?? "ErrorsLog.txt";
            var logFilePath = Path.Combine(Environment.CurrentDirectory, logFilename);
            File.AppendAllText(logFilePath, output.ToString());
        }

        private void SubscribeToAPIInputEvents()
        {
            InputManager = new InputManager();
            InputManager.Initialize();
            WindowsHookFilter.Filter += InvokeFilterEventHandlers;
        }

        private void OpenApplicationWindow()
        {
            var thread = new Thread(() =>
            {
                Active = false;
                var settingsViewModel = new SettingsViewModel(PrankModels);
                var view = new View(settingsViewModel);
                view.UserClickedHideAndApply += HideAndApply;
                view.UserClickedClose += CloseApplication;
                Application.Run(view);
                Active = true;
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        private void CloseApplication(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exiting application",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void HideAndApply(object sender, EventArgs e)
        {
            var view = (View)sender;
            var selectedPranks = view.GetCheckedPranks();
            UpdatePranksStatus(selectedPranks);
            view.DialogResult = DialogResult.Ignore;
            view.Close();
        }

        private void UpdatePranksStatus(CheckedListBox.CheckedItemCollection selectedPranks)
        {
            PrankModels.ForEach(option =>
            {
                option.Active = selectedPranks.Contains(option.Description);
            });
        }

        private bool InvokeFilterEventHandlers(VirtualKeyCode key, KeyState state)
        {
            if (!Active) return false;
            if (key == VirtualKeyCode.Escape
                && state == KeyState.Down
                && InputManager.IsPressed(VirtualKeyCode.Lwin))
            {
                SpecialComboTask?.Invoke();
                return false;
            }
            return Filter?.Invoke(key, state) ?? false;
        }

        internal bool Active { get; set; } = true;

        public void Dispose()
        {
            InputManager?.Dispose();
        }
    }
}