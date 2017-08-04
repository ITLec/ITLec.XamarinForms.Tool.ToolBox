using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ITLec.XamarinForms.Tool.AdvancedProgressBar
{
    public partial class AdvancedProgressBar : ContentView
    {
        public AdvancedProgressBar()
        {
            InitializeComponent();
            Init();
            Reset();
        }

        private void Init()
        {
            if (TaskItems != null)
            {
                TaskItems = new List<TaskItem>();
            }
        }

        public List<TaskItem> TaskItems
        {
            get;
            set;
        }

        public async Task Run()
        {
            IsRunning = true;
            double counter = 0;

            double totalCounter = TaskItems.Sum(e => e.Wieght);



            foreach (var item in TaskItems)
            {
                double currentStep = counter / totalCounter;
                double currentPercentage = (currentStep * 100);
                CurrentPercentage = currentPercentage;
                lbl.Text = string.Format("{0} - (%{1})", item.TaskName, String.Format("{0:0.0}", currentPercentage));
                item.Task.RunSynchronously();
                await mainProgressBar.ProgressTo(currentStep, 0, Easing.Linear);
                counter = counter + item.Wieght;
            }

            IsRunning = false;
        }

        public double CurrentPercentage
        {
            get;
            set;

        }
        public async void Reset()
        {
            await mainProgressBar.ProgressTo(0, 0, Easing.Linear);
            lbl.Text = "%0";

            CurrentPercentage = 0;
            if (TaskItems != null)
            {
                TaskItems.Clear();
            }
        }

        public bool IsRunning
        {
            get;
            set;
        }
    }

}
