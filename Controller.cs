
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LowLevelInput.Hooks;
using LowLevelInput.WindowsHooks;

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
                model.ErrorSubscriber += LogModel.LogError;
            }
            SpecialComboTask = OpenApplicationWindow;
            SubscribeToAPIInputEvents();
            OpenApplicationWindow();
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
            var view = sender as View;
            if (view == null) return;

            var selectedPranks = view.GetCheckedOptions();
            UpdatePranksStatus(selectedPranks);
            view.DialogResult = DialogResult.Ignore;
            view.Close();
        }

        private void UpdatePranksStatus(IEnumerable<IApplicationOption> selectedPranks)
        {
            var descriptions = selectedPranks.Select(sp => sp.Description);
            PrankModels.ForEach(option =>
            {
                option.Active = descriptions.Contains(option.Description);
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