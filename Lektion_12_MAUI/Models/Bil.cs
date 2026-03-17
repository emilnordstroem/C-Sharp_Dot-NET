using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lektion_12_MAUI.Models
{
	public class Bil : INotifyPropertyChanged
	{
		private string _Model;
		private int _Hestekrafter;
		private bool _Eldreven;

		public string Model 
		{ 
			get
			{
				return _Model;
			}
			set
			{
				_Model = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Model)));
			}
		}
		public int Hestekrafter 
		{ 
			get
			{
				return _Hestekrafter;
			}
			set
			{
				_Hestekrafter = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Hestekrafter)));
			}
		}
		public bool Eldreven 
		{ 
			get 
			{
				return _Eldreven;
			} 
			set 
			{
				_Eldreven = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Eldreven)));
			}
		}

		public Bil()
		{
		}

		public event PropertyChangedEventHandler? PropertyChanged = delegate { };
	}
}
