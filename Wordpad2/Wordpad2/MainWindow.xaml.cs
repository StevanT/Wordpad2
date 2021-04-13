﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Diagnostics;

namespace Wordpad2
{
	public partial class MainWindow : Window
	{
<<<<<<< HEAD
        public bool UseShellExecute { get; private set; }
		OpenSaveExportClass openSaveExportClass = new OpenSaveExportClass();

        public MainWindow()
=======
		private object executedCommandsList;

		public object myRichTextBox { get; private set; }

		public MainWindow()
>>>>>>> origin/Nina
		{
			InitializeComponent();
			cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
			cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
		}

		private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			openSaveExportClass.Open_Executed(sender, e, rtbEditor);
		}

		private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			openSaveExportClass.Save_Executed(sender, e, rtbEditor);
		}

		private void Export_Executed(object sender, RoutedEventArgs e)
		{
			openSaveExportClass.Export_Executed(sender, e, rtbEditor);
		}

		private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
		{
			if (!rtbEditor.Selection.IsEmpty)
			{
				object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
				btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
				temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
				btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
				temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
				btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

				temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
				cmbFontFamily.SelectedItem = temp;
                try
				{
					temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
					cmbFontSize.Text = temp.ToString();
				} catch(Exception exception) { }

			}
            else
            {
				cmbFontFamily.SelectedIndex = -1;
				cmbFontSize.Text = null;
			}
		}



		private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cmbFontFamily.SelectedItem != null)
				rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
		}

		private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (cmbFontFamily.SelectedItem != null)
				if(int.TryParse(cmbFontSize.Text, out int x)) 
				rtbEditor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, cmbFontSize.Text);
		}

<<<<<<< HEAD
        private void Button_FontPlus(object sender, RoutedEventArgs e)
        {
			if (!rtbEditor.Selection.IsEmpty)
			{
                rtbEditor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToString(Convert.ToInt32(cmbFontSize.Text) + 1));
				cmbFontSize.Text = Convert.ToString(Convert.ToInt32(cmbFontSize.Text) + 1);
			}
		}

        private void Button_FontMinus(object sender, RoutedEventArgs e)
        {
			if (!rtbEditor.Selection.IsEmpty)
			{
                rtbEditor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToString(Convert.ToInt32(cmbFontSize.Text) - 1));
				cmbFontSize.Text = Convert.ToString(Convert.ToInt32(cmbFontSize.Text) - 1);
			}
		}

        private void Button_Hyperlink(object sender, RoutedEventArgs e)
        {
			if (!rtbEditor.Selection.IsEmpty)
			{
				string inputRead = new InputBox("Enter hyperlink:", "Add hyperlink", "").ShowDialog();

				Hyperlink hlink = new Hyperlink();
				TextRange tr = new TextRange(rtbEditor.Selection.Start, rtbEditor.Selection.End);

				try
				{
					hlink.NavigateUri = new Uri(inputRead);
					hlink = new Hyperlink(tr.Start, tr.End);
					hlink.NavigateUri = new Uri(inputRead);
					hlink.RequestNavigate += Hyperlink_RequestNavigate;
					hlink.IsEnabled = true;
				} catch (Exception exception)
				{
					MessageBox.Show(exception.Message);
					
				}

			}
		}

		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			try
			{
				Process pro = new Process();
				UseShellExecute = true;
				pro.StartInfo.FileName = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
				pro.StartInfo.Arguments = e.Uri.AbsoluteUri;
				pro.Start();
				e.Handled = true;
			} catch(Exception exception) { 
				MessageBox.Show(exception.Message); }
		}


    }
}
=======
		private void foregroundToggle(object sender, RoutedEventArgs e)
		{
			if ((bool)btnForeColor.IsChecked)
			{
				rtbEditor.Selection.ApplyPropertyValue(Inline.ForegroundProperty, Brushes.Red);
			}
			else
            {
				rtbEditor.Selection.ApplyPropertyValue(Inline.ForegroundProperty, Brushes.Black);
			}

		}

		private void backgroundToggle(object sender, RoutedEventArgs e)
		{
			if ((bool)btnBackColor.IsChecked)
			{
				rtbEditor.Selection.ApplyPropertyValue(Inline.BackgroundProperty, Brushes.Yellow);
			}
			else
			{
				rtbEditor.Selection.ApplyPropertyValue(Inline.BackgroundProperty, null);
			}

		}
	}
}
	

>>>>>>> origin/Nina
