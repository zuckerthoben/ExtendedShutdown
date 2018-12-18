// <copyright file="MainViewModel.cs" company="Christoph Nienaber">
// Copyright (c) Christoph Nienaber. All rights reserved.
// </copyright>

namespace ExtendedShutdown.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using MvvmHelpers;

    /// <summary>
    /// Main View Model.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private bool isHybrid;

        private string selectedTimeUnit;

        private int timerValue;

        private ObservableCollection<string> timeUnits = new ObservableCollection<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.TimeUnits.Add("s");
            this.TimeUnits.Add("m");
            this.TimeUnits.Add("h");
            this.TimeUnits.Add("d");
        }

        /// <summary>
        /// Gets or sets a value indicating whether indicates if the shutdown should be hybrid.
        /// </summary>
        public bool IsHybrid
        {
            get => this.isHybrid;
            set => this.SetProperty(ref this.isHybrid, value);
        }

        /// <summary>
        /// Gets or sets the selected unit.
        /// </summary>
        public string SelectedTimeUnit
        {
            get => this.selectedTimeUnit;
            set => this.SetProperty(ref this.selectedTimeUnit, value);
        }

        /// <summary>
        /// Gets or sets value of the Timer.
        /// </summary>
        public int TimerValue
        {
            get => this.timerValue;
            set => this.SetProperty(ref this.timerValue, value);
        }

        /// <summary>
        /// Gets or sets the available Units.
        /// </summary>
        public ObservableCollection<string> TimeUnits
        {
            get => this.timeUnits;
            set => this.SetProperty(ref this.timeUnits, value);
        }

        public void LogOff()
        {
            ShutdownService.LogOff(this.TimerValue);
        }

        public void Restart()
        {
            ShutdownService.Restart(this.TimerValue);
        }

        public void Shutdown()
        {
            ShutdownService.Shutdown(this.TimerValue, this.IsHybrid);
        }

        public void Cancel()
        {
            ShutdownService.Cancel();
        }
    }
}
