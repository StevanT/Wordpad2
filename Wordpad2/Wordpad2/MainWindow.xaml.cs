using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Controls;

namespace Wordpad2
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
			cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
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

		private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
			if (dlg.ShowDialog() == true)
			{
				FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
				TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
				range.Load(fileStream, DataFormats.Rtf);
			}
		}

		private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
			if (dlg.ShowDialog() == true)
			{
				FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
				TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
				range.Save(fileStream, DataFormats.Rtf);
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
				rtbEditor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, cmbFontSize.Text);
		}

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
    }
}