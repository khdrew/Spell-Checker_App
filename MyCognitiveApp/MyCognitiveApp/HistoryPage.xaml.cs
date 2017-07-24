using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCognitiveApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{        
        Button historyButton = new Button
        {
            Text = "Look at History",
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        public HistoryPage ()
		{
            InitializeComponent();
            historyButton.Clicked += HistoryButtonClicked;
            var layout = new StackLayout();
                                    
            layout.Children.Add(historyButton);
            
            Content = layout;
        }

        void HistoryButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("History", "SQL Post request", "OK");
        }

    }
}