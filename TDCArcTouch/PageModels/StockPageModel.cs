﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockPageModel.cs" company="ArcTouch LLC">
//   Copyright 2016 ArcTouch LLC.
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the StockPageModel type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TDCArcTouch
{
    public class StockPageModel : BasePageModel
    {
        private bool mommSelected;
        private bool defaultSelected;
        private bool kazumiSelected;
        private string name;

        public StockPageModel()
        {
            NextButtonCommand = new Command(NextButtonTapped);
        }

        public ICommand NextButtonCommand { get; set; }
        
        public bool MommSelected
        {
            get
            {
                return this.mommSelected;
            }
            set
            {
                if (this.mommSelected != value)
                {
                    this.mommSelected = value;
                    RaisePropertyChanged();
                    
                    if(MommSelected)
                    {
                        KazumiSelected = false;
                        DefaultSelected = false;
                    }
                }
            }
        }

        public bool DefaultSelected
        {
            get
            {
                return this.defaultSelected;
            }
            set
            {
                if (this.defaultSelected != value)
                {
                    this.defaultSelected = value;
                    RaisePropertyChanged();

                    if(DefaultSelected)
                    {
                        KazumiSelected = false;
                        MommSelected = false;
                    }
                }
            }
        }

        public bool KazumiSelected
        {
            get
            {
                return this.kazumiSelected;
            }
            set
            {
                if (this.kazumiSelected != value)
                {
                    this.kazumiSelected = value;
                    RaisePropertyChanged();

                    if(KazumiSelected)
                    {
                        MommSelected = false;
                        DefaultSelected = false;
                    }
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    RaisePropertyChanged();
                }
            }
        }

        private async void NextButtonTapped()
        {
            var avatarSelected = MommSelected || KazumiSelected || DefaultSelected;
            if(avatarSelected && !string.IsNullOrWhiteSpace(Name))
            {
                await (App.Current as App).DisplayAlert("Foi.");
            }
            else
            {
                await (App.Current as App).DisplayAlert("Selecione um avatar e informe seu nome.");
            }
        }
    }
}

